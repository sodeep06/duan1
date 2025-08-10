using duan1.DTO;
using duan1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duan1.Repositories
{
    public class DonHangChiTietRepo
    {
        private ShopDbContext _context = new ShopDbContext();

        public List<DonHangChiTiet> GetAll()
        {
            return _context.DonHangChiTiets.ToList();
        }
        public List<DonHangChiTiet> GetAllWithDetails()
        {
            return _context.DonHangChiTiets
                .Include(ct => ct.DonHang)
                .Include(ct => ct.ChiTietSanPham)
                .ToList();
        }
        public List<DonHangChiTietDTO> GetByDonHangId(string donHangId)
        {
            return _context.DonHangChiTiets
                .Where(ct => ct.MaDH == donHangId)
                .Include(ct => ct.ChiTietSanPham)
                    .ThenInclude(spct => spct.SanPham)
                .Select(ct => new DonHangChiTietDTO
                {
                    MaDHCT = ct.MaDHCT,
                    MaDH = ct.MaDH,
                    MaSPCT = ct.MaSPCT,
                    TenSP = ct.ChiTietSanPham.SanPham.TenSP,
                    KichThuoc = ct.ChiTietSanPham.KichThuoc,
                    MauSac = ct.ChiTietSanPham.MauSac,
                    SoLuong = ct.SoLuong,
                    DonGia = ct.DonGia
                })
                .ToList();
        }
        public DonHangChiTiet GetById(string id)
        {
            return _context.DonHangChiTiets.Find(id);
        }

        public bool Add(DonHangChiTiet dhct)
        {
            if(dhct == null || string.IsNullOrEmpty(dhct.MaDHCT))
            {
                return false;
            }
            if (dhct.SoLuong <= 0 || dhct.DonGia <= 0)
            {
                return false;
            }

            _context.DonHangChiTiets.Add(dhct);
            _context.SaveChanges();
            return true;
        }

        public void Update(DonHangChiTiet dhct)
        {
            _context.DonHangChiTiets.Update(dhct);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var dhct = _context.DonHangChiTiets.Find(id);
            if (dhct != null)
            {
                _context.DonHangChiTiets.Remove(dhct);
                _context.SaveChanges();
            }
        }
    }
}
