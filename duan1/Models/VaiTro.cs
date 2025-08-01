using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duan1.Models
{
    public class VaiTro
    {
        [Key]
        public string MaVaiTro { get; set; }
        public string TenVaiTro { get; set; }

        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
