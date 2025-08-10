using duan1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duan1.Repositories
{
    public class NhanVienRepo
    {
        private ShopDbContext _context = new ShopDbContext();

        public List<NhanVien> GetAll()
        {
            return _context.NhanViens.ToList();
        }
        public List<NhanVien> GetAllWithDetails()
        {
            return _context.NhanViens
                .Include(nv => nv.VaiTroNV)
                .Include(nv => nv.DonHangs)
                .ToList();
        }
        public NhanVien GetById(string id)
        {
            return _context.NhanViens.Find(id);
        }

        public void Add(NhanVien nv)
        {
            _context.NhanViens.Add(nv);
            _context.SaveChanges();
        }

        public void Update(NhanVien nv)
        {
            _context.NhanViens.Update(nv);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var nv = _context.NhanViens.Find(id);
            if (nv != null)
            {
                _context.NhanViens.Remove(nv);
                _context.SaveChanges();
            }
        }
    }
}
