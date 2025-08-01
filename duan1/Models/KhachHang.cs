using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duan1.Models
{
    public class KhachHang
    {
        [Key]
        public string MaKH { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }

        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
