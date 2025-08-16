using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace duan1.Models
{
    public class DonHang
    {
        [Key]
        public string MaDH { get; set; }
        public DateTime NgayDat { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
        public string MaKH { get; set; }
        public string MaNV { get; set; }
        public string? MaVoucher { get; set; }  

        [ForeignKey("MaKH")]
        public virtual KhachHang KhachHang { get; set; }

        [ForeignKey("MaNV")]
        public virtual NhanVien NhanVien { get; set; }

        [ForeignKey("MaVoucher")]
        public virtual Voucher? Voucher { get; set; }

        public virtual ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }
    }
}
