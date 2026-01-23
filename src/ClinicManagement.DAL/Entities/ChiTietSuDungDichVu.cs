using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.DAL.Entities
{
    public class ChiTietSuDungDichVu
    {
        [Key]
        public int Id { get; set; }
        public string MaPhieuKham { get; set; } // Khóa ngoại
        public string MaDichVu { get; set; }     // Khóa ngoại
        public string KetQua { get; set; }       // Vd: "Gan nhiễm mỡ nhẹ"
        public decimal GiaTienLucLam { get; set; } // Lưu lại giá tại thời điểm làm

        // Relationship
        public virtual PhieuKham PhieuKham { get; set; }
        public virtual DichVu DichVu { get; set; }
    }
}
