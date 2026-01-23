namespace ClinicManagement.Common.DTOs
{
    // 1. DTO để hiển thị danh sách dịch vụ (cho Bác sĩ chọn)
    public class DichVuDTO
    {
        public string MaDichVu { get; set; } = null!;
        public string TenDichVu { get; set; } = null!;
        public decimal DonGia { get; set; }
        public string? DonViTinh { get; set; }
    }

    // 2. DTO để Lưu chỉ định dịch vụ (Bác sĩ tích chọn -> Gửi về Server)
    public class ChiDinhDichVuCreateDTO
    {
        public string MaPhieuKham { get; set; } = null!;
        public string MaDichVu { get; set; } = null!;
    }

    // 3. DTO để Nhập kết quả (Ví dụ: Nhập kết quả siêu âm)
    public class KetQuaDichVuUpdateDTO
    {
        public int Id { get; set; } // Id của dòng ChiTietSuDungDichVu
        public string KetQua { get; set; } = null!; // Bác sĩ nhập text vào đây
    }

    // 4. DTO để Hiển thị danh sách dịch vụ ĐÃ LÀM của bệnh nhân (kèm kết quả)
    public class KetQuaDichVuViewDTO
    {
        public int Id { get; set; }
        public string TenDichVu { get; set; } = null!;
        public string? KetQua { get; set; }
        public decimal GiaTien { get; set; }
    }
}