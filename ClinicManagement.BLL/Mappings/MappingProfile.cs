using AutoMapper;
using ClinicManagement.Common.DTOs;
using ClinicManagement.DAL.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicManagement.BLL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Patient mappings
            CreateMap<Patient, PatientDTO>();
            CreateMap<CreatePatientDTO, Patient>();
            CreateMap<UpdatePatientDTO, Patient>();

            // Doctor mappings
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<CreateDoctorDTO, Doctor>();
            CreateMap<UpdateDoctorDTO, Doctor>();

            // Appointment mappings
            CreateMap<Appointment, AppointmentDTO>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName));
            CreateMap<CreateAppointmentDTO, Appointment>();
            CreateMap<UpdateAppointmentDTO, Appointment>();

            // Medicine mappings
            CreateMap<Medicine, MedicineDTO>();
            CreateMap<CreateMedicineDTO, Medicine>();
            CreateMap<UpdateMedicineDTO, Medicine>();

            // Medical Record mappings (if needed)
            // CreateMap<MedicalRecord, MedicalRecordDTO>();
            // CreateMap<CreateMedicalRecordDTO, MedicalRecord>();

            // Prescription mappings (if needed)
            // CreateMap<Prescription, PrescriptionDTO>();
            // CreateMap<CreatePrescriptionDTO, Prescription>();

            // Payment mappings (if needed)
            // CreateMap<Payment, PaymentDTO>();
            // CreateMap<CreatePaymentDTO, Payment>();
        }
    }
}