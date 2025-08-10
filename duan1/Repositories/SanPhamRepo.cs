using duan1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace duan1.Repositories
{
    public class SanPhamRepo
    {
        private ShopDbContext _context = new ShopDbContext();

        public List<SanPham> GetAll()
        {
            return _context.SanPhams.ToList();
        }

        public List<SanPham> GetAllWithDetails()
        {
            return _context.SanPhams
                .Include(sp => sp.DanhMuc)
                .Include(sp => sp.ChiTietSanPhams)
                .ToList();
        }

        public SanPham GetById(string id)
        {
            return _context.SanPhams.Find(id);
        }

        public void Add(SanPham sp)
        {
            _context.SanPhams.Add(sp);
            _context.SaveChanges();
        }

        public void Update(SanPham sp)
        {
            _context.SanPhams.Update(sp);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var sp = _context.SanPhams.Find(id);
            if (sp != null)
            {
                _context.SanPhams.Remove(sp);
                _context.SaveChanges();
            }
        }
    }
}
