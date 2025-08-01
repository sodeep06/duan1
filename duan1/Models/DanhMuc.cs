using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duan1.Models
{
    public class DanhMuc
    {
        [Key]
        public string MaDM { get; set; }
        public string TenDM { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
