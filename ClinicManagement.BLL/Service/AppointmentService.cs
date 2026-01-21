using AutoMapper;
using ClinicManagement.Common.DTOs;
using ClinicManagement.DAL.Entities;
using ClinicManagement.DAL.Repositories;

namespace ClinicManagement.BLL.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsAsync();
        Task<AppointmentDTO> GetAppointmentByIdAsync(int id);
        Task<AppointmentDTO> CreateAppointmentAsync(CreateAppointmentDTO dto);
        Task<AppointmentDTO> UpdateAppointmentAsync(int id, UpdateAppointmentDTO dto);
        Task<bool> DeleteAppointmentAsync(int id);
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatientIdAsync(int patientId);
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctorIdAsync(int doctorId);
        Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDateRangeAsync(DateTime startDate, DateTime endDate);
    }

    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsAsync()
        {
            var appointments = await _repository.GetAllAsync();
            return appointments.Select(a => MapToDTO(a));
        }

        public async Task<AppointmentDTO> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);
            if (appointment == null)
                throw new KeyNotFoundException($"Appointment with ID {id} not found");

            return MapToDTO(appointment);
        }

        public async Task<AppointmentDTO> CreateAppointmentAsync(CreateAppointmentDTO dto)
        {
            // Check for scheduling conflicts
            var hasConflict = await _repository.HasConflictAsync(
                dto.DoctorId,
                dto.AppointmentDate,
                dto.AppointmentTime);

            if (hasConflict)
                throw new InvalidOperationException("This time slot is already booked for the selected doctor");

            var appointment = _mapper.Map<Appointment>(dto);
            var created = await _repository.CreateAsync(appointment);

            // Reload to get navigation properties
            created = await _repository.GetByIdAsync(created.AppointmentId);
            return MapToDTO(created);
        }

        public async Task<AppointmentDTO> UpdateAppointmentAsync(int id, UpdateAppointmentDTO dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Appointment with ID {id} not found");

            // Check for conflicts (excluding current appointment)
            var hasConflict = await _repository.HasConflictAsync(
                dto.DoctorId,
                dto.AppointmentDate,
                dto.AppointmentTime,
                id);

            if (hasConflict)
                throw new InvalidOperationException("This time slot is already booked for the selected doctor");

            _mapper.Map(dto, existing);
            var updated = await _repository.UpdateAsync(existing);

            // Reload to get navigation properties
            updated = await _repository.GetByIdAsync(updated.AppointmentId);
            return MapToDTO(updated);
        }

        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            var exists = await _repository.GetByIdAsync(id);
            if (exists == null)
                throw new KeyNotFoundException($"Appointment with ID {id} not found");

            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatientIdAsync(int patientId)
        {
            var appointments = await _repository.GetByPatientIdAsync(patientId);
            return appointments.Select(a => MapToDTO(a));
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctorIdAsync(int doctorId)
        {
            var appointments = await _repository.GetByDoctorIdAsync(doctorId);
            return appointments.Select(a => MapToDTO(a));
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var appointments = await _repository.GetByDateRangeAsync(startDate, endDate);
            return appointments.Select(a => MapToDTO(a));
        }

        private AppointmentDTO MapToDTO(Appointment appointment)
        {
            return new AppointmentDTO
            {
                AppointmentId = appointment.AppointmentId,
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient?.FullName,
                DoctorId = appointment.DoctorId,
                DoctorName = appointment.Doctor?.FullName,
                AppointmentDate = appointment.AppointmentDate,
                AppointmentTime = appointment.AppointmentTime,
                Status = appointment.Status,
                Reason = appointment.Reason,
                Notes = appointment.Notes,
                CreatedAt = appointment.CreatedAt
            };
        }
    }
}