using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duan1.DTO
{
    internal class SanPhamTrongGioHangDTO
    {
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public string TenKhachHang { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien
        {
            get { return SoLuong * DonGia; }
        }
    }
}
