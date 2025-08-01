using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duan1.Models
{
    public class DonHangChiTiet
    {
        [Key]
        public string MaDHCT { get; set; }
        public string MaDH { get; set; }
        public string MaSPCT { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }

        [ForeignKey("MaDH")]
        public virtual DonHang DonHang { get; set; }

        [ForeignKey("MaSPCT")]
        public virtual ChiTietSanPham ChiTietSanPham { get; set; }
    }
}
