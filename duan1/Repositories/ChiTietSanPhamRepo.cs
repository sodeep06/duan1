using duan1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace duan1.Repositories
{
    public class ChiTietSanPhamRepo
    {
        ShopDbContext _context = new ShopDbContext();

        public List<ChiTietSanPham> GetAll()
        {
            return _context.ChiTietSanPhams
                .ToList();
        }

        public List<ChiTietSanPham> GetByMaSP(string maSP)
        {
            return _context.ChiTietSanPhams
                .Where(ct => ct.MaSP == maSP)
                .ToList();
        }

        public ChiTietSanPham GetById(string maSPCT)
        {
            return _context.ChiTietSanPhams
                .FirstOrDefault(ct => ct.MaSPCT == maSPCT);
        }

        public bool Add(ChiTietSanPham entity)
        {
            try
            {
                _context.ChiTietSanPhams.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(ChiTietSanPham entity)
        {
            try
            {
                _context.ChiTietSanPhams.Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string maSPCT)
        {
            try
            {
                var item = GetById(maSPCT);
                if (item != null)
                {
                    _context.ChiTietSanPhams.Remove(item);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool TruTonKho(string maSPCT, int soLuong)
        {
            var ctsp = _context.ChiTietSanPhams.FirstOrDefault(x => x.MaSPCT == maSPCT);
            if (ctsp == null || ctsp.SoLuongTon < soLuong)
            {
                return false;
            }
            ctsp.SoLuongTon -= soLuong;

            var sp = _context.SanPhams.FirstOrDefault(s => s.MaSP == ctsp.MaSP);
            if (sp != null)
            {
                sp.SoLuong = _context.ChiTietSanPhams
                                .Where(x => x.MaSP == sp.MaSP)
                                .Sum(x => x.SoLuongTon);
            }

            _context.SaveChanges();
            return true;
        }

    }
}
