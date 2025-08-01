using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duan1.Models
{
    public class NhanVien
    {
        [Key]
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }

        [ForeignKey("VaiTro")] // Thêm dòng này để EF hiểu đây là khóa ngoại
        public virtual VaiTro VaiTroNV { get; set; }
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
