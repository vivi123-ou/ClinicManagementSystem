using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.DAL.Entities
{
    public class DichVu
    {
        [Key]
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; } // Vd: Siêu âm ổ bụng
        public decimal DonGia { get; set; }
        public string DonViTinh { get; set; }
    }
}
