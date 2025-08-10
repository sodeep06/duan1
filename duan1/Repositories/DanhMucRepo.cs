using duan1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duan1.Repositories
{
    public class DanhMucRepo
    {
        private ShopDbContext _context = new ShopDbContext();

        public List<DanhMuc> GetAll()
        {
            return _context.DanhMucs.ToList();
        }

        public DanhMuc GetById(string id)
        {
            return _context.DanhMucs.Find(id);
        }

        public void Add(DanhMuc dm)
        {
            _context.DanhMucs.Add(dm);
            _context.SaveChanges();
        }

        public void Update(DanhMuc dm)
        {
            _context.DanhMucs.Update(dm);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var dm = _context.DanhMucs.Find(id);
            if (dm != null)
            {
                _context.DanhMucs.Remove(dm);
                _context.SaveChanges();
            }
        }
    }
}
