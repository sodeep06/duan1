using duan1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duan1.Repositories
{
    public class VoucherRepo
    {
        private ShopDbContext _context = new ShopDbContext();

        public List<Voucher> GetAll()
        {
            return _context.Vouchers.ToList();
        }
        public List<Voucher> GetValidVouchers()
        {
            var today = DateTime.Today;
            return _context.Vouchers
                .Where(v => v.NgayKetThuc >= today)
                .ToList();
        }

        public Voucher GetById(string id)
        {
            return _context.Vouchers.Find(id);
        }

        public void Add(Voucher voucher)
        {
            _context.Vouchers.Add(voucher);
            _context.SaveChanges();
        }

        public void Update(Voucher voucher)
        {
            _context.Vouchers.Update(voucher);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var voucher = _context.Vouchers.Find(id);
            if (voucher != null)
            {
                _context.Vouchers.Remove(voucher);
                _context.SaveChanges();
            }
        }
    }
}
