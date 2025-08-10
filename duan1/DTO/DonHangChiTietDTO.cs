using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duan1.DTO
{
    public class DonHangChiTietDTO
    {
        public string MaDHCT { get; set; }
        public string MaDH { get; set; }
        public string MaSPCT { get; set; }
        public string TenSP { get; set; }   
        public string KichThuoc { get; set; }   
        public string MauSac { get; set; }      
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }

}
