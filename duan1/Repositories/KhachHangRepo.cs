using duan1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duan1.Repositories
{
    public class KhachHangRepo
    {
        ShopDbContext _context = new ShopDbContext();

        public List<KhachHang> GetAll()
        {
            return _context.KhachHangs.ToList();
        }
        public KhachHang GetById(string id)
        {
            return _context.KhachHangs.Find(id);
        }
        public void Add (KhachHang kh)
        {
            _context.Add(kh);
            _context.SaveChanges();
        }
        public void Update (KhachHang kh)
        {
            _context.Update(kh);
            _context.SaveChanges();
        }
        public void Delete (string id)
        {
            var kh = _context.KhachHangs.Find(id);
            _context.Remove(kh);
            _context.SaveChanges();
        }
    }
}
