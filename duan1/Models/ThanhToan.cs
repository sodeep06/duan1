using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duan1.Models
{
    public class ThanhToan
    {
        [Key]
        public string MaTT { get; set; }
        public string MaDH { get; set; }
        public string PhuongThuc { get; set; }
        public decimal? SoTienKhachDua { get; set; }
        public decimal SoTienThanhToan { get; set; }
        public DateTime NgayThanhToan { get; set; }

        [ForeignKey("MaDH")]
        public virtual DonHang DonHang { get; set; }
    }

}
