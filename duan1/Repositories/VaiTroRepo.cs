using duan1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace duan1.Repositories
{
    public class VaiTroRepo
    {
        private ShopDbContext _context = new ShopDbContext();

        public List<VaiTro> GetAll()
        {
            return _context.VaiTros.ToList();
        }

        public VaiTro GetById(string id)
        {
            return _context.VaiTros.Find(id);
        }

        public void Add(VaiTro vt)
        {
            _context.VaiTros.Add(vt);
            _context.SaveChanges();
        }

        public void Update(VaiTro vt)
        {
            _context.VaiTros.Update(vt);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var vt = _context.VaiTros.Find(id);
            if (vt != null)
            {
                _context.VaiTros.Remove(vt);
                _context.SaveChanges();
            }
        }
    }
}
