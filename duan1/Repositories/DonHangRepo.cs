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
    public class DonHangRepo
    {
        private ShopDbContext _context = new ShopDbContext();

        public List<DonHang> GetAll()
        {
            return _context.DonHangs.ToList();
        }
        public List<DonHang> GetAllWithDetails()
        {
            return _context.DonHangs
                .Include(d => d.KhachHang)
                .Include(d => d.NhanVien)
                .Include(d => d.Voucher)
                .Include(d => d.DonHangChiTiets)
                .ToList();
        }
        public DonHang GetById(string id)
        {
            return _context.DonHangs.Find(id);
        }

        public bool Add(DonHang dh)
        {
            if(dh == null || string.IsNullOrEmpty(dh.MaDH))
            {
                return false;
            }
            _context.DonHangs.Add(dh);
            _context.SaveChanges();
            return true; 
        }

        public void Update(DonHang dh)
        {
            _context.DonHangs.Update(dh);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var dh = _context.DonHangs.Find(id);
            if (dh != null)
            {
                _context.DonHangs.Remove(dh);
                _context.SaveChanges();
            }
        }
    }
}
