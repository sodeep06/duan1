using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;   // THÊM USING NÀY

namespace duan1.Models
{
    public class ChiTietSanPham
    {
        [Key]
        public string MaSPCT { get; set; }
        public string MaSP { get; set; }
        public string KichThuoc { get; set; }
        public string MauSac { get; set; }
        public int SoLuongTon { get; set; }
        public string HinhAnh { get; set; }
        public decimal GiaBan { get; set; }

        [ForeignKey("MaSP")]                // THÊM DÒNG NÀY
        public virtual SanPham SanPham { get; set; }
    }
}
