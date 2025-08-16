using duan1.DTO;
using duan1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace duan1.Repositories
{
    public class DonHangRepo
    {
        private readonly ShopDbContext _context = new ShopDbContext();

        // ===== CRUD cơ bản =====
        public List<DonHang> GetAll() => _context.DonHangs.ToList();

        public List<DonHang> GetAllWithDetails()
        {
            return _context.DonHangs
                .Include(d => d.KhachHang)
                .Include(d => d.NhanVien)
                .Include(d => d.Voucher)
                .Include(d => d.DonHangChiTiets)
                .ToList();
        }

        public DonHang GetById(string id) => _context.DonHangs.Find(id);

        public bool Add(DonHang dh)
        {
            if (dh == null || string.IsNullOrEmpty(dh.MaDH)) return false;
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

        // ===== Analytics / Báo cáo =====

        /// <summary>
        /// Doanh thu theo NGÀY trong khoảng [fromDate..toDate]
        /// </summary>
        public List<RevenuePointVm> GetRevenueByDay(DateTime fromDate, DateTime toDate)
        {
            var from = fromDate.Date;
            var toExclusive = toDate.Date.AddDays(1); // so sánh < ngày kế tiếp

            var data = _context.DonHangs
                .Where(d => d.NgayDat >= from && d.NgayDat < toExclusive)
                .Select(d => new { d.NgayDat, d.TongTien })
                .AsEnumerable() // ⇦ chuyển sang client để tạo DateTime & group
                .GroupBy(x => x.NgayDat.Date)
                .Select(g => new RevenuePointVm
                {
                    Ngay = g.Key,
                    DoanhThu = g.Sum(x => x.TongTien)
                })
                .OrderBy(x => x.Ngay)
                .ToList();

            return data;
        }

        /// <summary>
        /// Doanh thu theo THÁNG của 1 năm
        /// </summary>
        public List<RevenuePointVm> GetRevenueByMonth(int year)
        {
            var start = new DateTime(year, 1, 1);
            var endExclusive = start.AddYears(1);

            var data = _context.DonHangs
                .Where(d => d.NgayDat >= start && d.NgayDat < endExclusive)
                .Select(d => new { d.NgayDat, d.TongTien })
                .AsEnumerable() // ⇦ xử lý client
                .GroupBy(x => new DateTime(x.NgayDat.Year, x.NgayDat.Month, 1))
                .Select(g => new RevenuePointVm
                {
                    Ngay = g.Key,
                    DoanhThu = g.Sum(x => x.TongTien)
                })
                .OrderBy(x => x.Ngay)
                .ToList();

            return data;
        }

        /// <summary>
        /// Top N sản phẩm bán chạy trong khoảng [fromDate..toDate]
        /// </summary>
        public List<TopProductVm> GetTopProducts(DateTime fromDate, DateTime toDate, int topN = 5)
        {
            var q =
                from dh in _context.DonHangs
                where dh.NgayDat >= fromDate && dh.NgayDat <= toDate
                join ct in _context.DonHangChiTiets on dh.MaDH equals ct.MaDH
                join spct in _context.ChiTietSanPhams on ct.MaSPCT equals spct.MaSPCT
                join sp in _context.SanPhams on spct.MaSP equals sp.MaSP
                group new { ct, sp } by new { sp.MaSP, sp.TenSP } into g
                select new TopProductVm
                {
                    MaSP = g.Key.MaSP,
                    TenSP = g.Key.TenSP,
                    SoLuongBan = g.Sum(x => x.ct.SoLuong),
                    DoanhThu = g.Sum(x => x.ct.SoLuong * x.ct.DonGia)
                };

            return q.OrderByDescending(x => x.SoLuongBan)
                    .ThenByDescending(x => x.DoanhThu)
                    .Take(topN)
                    .ToList();
        }
    }
}

// ===== DTO dùng cho báo cáo =====
namespace duan1.DTO
{
    public class RevenuePointVm
    {
        public DateTime Ngay { get; set; }
        public decimal DoanhThu { get; set; }
    }

    public class TopProductVm
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuongBan { get; set; }
        public decimal DoanhThu { get; set; }
    }
}
