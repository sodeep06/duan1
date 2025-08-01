using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duan1.Models
{
    public class Voucher
    {
        [Key]   
        public string MaVoucher { get; set; }
        public string TenVoucher { get; set; }
        public decimal GiaTri { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
