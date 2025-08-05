using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace duan1.Models
{
    public class SanPham
    {
        [Key]
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuong { get; set; }
        public string MoTa { get; set; }
        public string MaDM { get; set; }
        public string HinhAnh { get; set; } // <--- Thêm dòng này

        public virtual DanhMuc DanhMuc { get; set; }
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }
    }
}
