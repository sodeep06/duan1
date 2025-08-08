using duan1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duan1.Repositories
{
    public class SanPhamRepo
    {
        ShopDbContext _context = new ShopDbContext();

        public List<SanPham> GetAll()
        {
            return _context.SanPhams.ToList();
        }
        public SanPham GetById(string id)
        {
            return _context.SanPhams.Find(id);
        }
        public void Add(SanPham sanPham)
        {
            _context.Add(sanPham);
            _context.SaveChanges();
        }
        public void Update(SanPham sanPham)
        {
            _context.Update(sanPham);
            _context.SaveChanges();
        }
        public void Delete(string id)
        {
            _context.Remove(id);
            _context.SaveChanges();
        }
    }
}
