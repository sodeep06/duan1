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
        public List<SanPham> GetSanPhamHopLe()
        {
            var query = _context.SanPhams
         .Where(sp => sp.ChiTietSanPhams.Sum(ct => ct.SoLuongTon) > 0)
         .Include(sp => sp.DanhMuc)
         .Include(sp => sp.ChiTietSanPhams);

            return query.ToList();

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
        public bool TruTonKho(string maSPCT, int soLuong)
        {
            var ctsp = _context.ChiTietSanPhams.FirstOrDefault(x => x.MaSPCT == maSPCT);
            if (ctsp == null || ctsp.SoLuongTon < soLuong)
            {
                return false;
            }

            var sp = _context.SanPhams.Find(ctsp.MaSP);
            if (sp == null || sp.SoLuong < soLuong)
            {
                return false;
            }

            ctsp.SoLuongTon -= soLuong;
            if (ctsp.SoLuongTon == 0)
            {
                _context.ChiTietSanPhams.Remove(ctsp);

            }
            else
            {
                _context.ChiTietSanPhams.Update(ctsp);
            }

            sp.SoLuong -= soLuong;
            _context.SanPhams.Update(sp);

            _context.SaveChanges();

            return true;
        }

    }
}
