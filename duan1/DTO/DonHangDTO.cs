using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duan1.DTO
{
    internal class DonHangDTO
    {
        public string MaDH { get; set; }
        public DateTime NgayDat { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
        public string MaKH { get; set; }
        public string MaNV { get; set; }
        public string? MaVoucher { get; set; }  
    }
}
