using duan1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace duan1.Repositories
{
    public class VoucherRepo
    {
        // ===== READ =====
        public List<Voucher> GetAll()
        {
            using var db = new ShopDbContext();
            return db.Vouchers
                     .AsNoTracking()
                     .ToList();
        }

        // Chỉ trả về voucher dùng được "ngay bây giờ"
        public List<Voucher> GetValidVouchersNow()
        {
            var now = DateTime.Now;
            using var db = new ShopDbContext();
            return db.Vouchers
                     .AsNoTracking()
                     .Where(v => v.NgayBatDau <= now && now <= v.NgayKetThuc && v.GiaTri > 0)
                     .OrderBy(v => v.NgayKetThuc)
                     .ToList();
        }

        // Nếu vẫn muốn giữ tên cũ: sửa lại điều kiện cho đúng
        public List<Voucher> GetValidVouchers()
        {
            var now = DateTime.Now;
            using var db = new ShopDbContext();
            return db.Vouchers
                     .AsNoTracking()
                     .Where(v => v.NgayBatDau <= now && now <= v.NgayKetThuc && v.GiaTri > 0)
                     .OrderBy(v => v.NgayKetThuc)
                     .ToList();
        }

        public Voucher? GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;
            using var db = new ShopDbContext();
            // Find không NoTracking; dùng FirstOrDefault để NoTracking
            return db.Vouchers
                     .AsNoTracking()
                     .FirstOrDefault(v => v.MaVoucher == id);
        }

        public bool Exists(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) return false;
            using var db = new ShopDbContext();
            return db.Vouchers.Any(v => v.MaVoucher == code);
        }

        /// <summary>
        /// Kiểm tra mã voucher có dùng được tại thời điểm atTime không.
        /// Trả về (ok, reason, voucher).
        /// </summary>
        public (bool ok, string reason, Voucher? voucher) ValidateForUse(string code, DateTime atTime)
        {
            if (string.IsNullOrWhiteSpace(code))
                return (false, "Chưa nhập mã voucher.", null);

            using var db = new ShopDbContext();
            var v = db.Vouchers.FirstOrDefault(x => x.MaVoucher == code.Trim());
            if (v == null) return (false, "Không tìm thấy voucher.", null);

            if (v.GiaTri <= 0) return (false, "Giá trị voucher không hợp lệ.", v);
            if (atTime < v.NgayBatDau) return (false, $"Voucher chỉ dùng từ {v.NgayBatDau:dd/MM/yyyy}.", v);
            if (atTime > v.NgayKetThuc) return (false, "Voucher đã hết hạn.", v);

            return (true, "", v);
        }

        // ===== WRITE =====
        public (bool ok, string message) Add(Voucher voucher)
        {
            if (voucher == null) return (false, "Dữ liệu trống.");
            if (string.IsNullOrWhiteSpace(voucher.MaVoucher)) return (false, "Thiếu mã voucher.");
            if (voucher.NgayKetThuc < voucher.NgayBatDau) return (false, "Ngày kết thúc phải >= ngày bắt đầu.");
            if (voucher.GiaTri <= 0) return (false, "Giá trị voucher phải > 0.");

            using var db = new ShopDbContext();
            if (db.Vouchers.Any(v => v.MaVoucher == voucher.MaVoucher))
                return (false, "Mã voucher đã tồn tại.");

            try
            {
                db.Vouchers.Add(voucher);
                db.SaveChanges();
                return (true, "Thêm voucher thành công.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi thêm voucher: " + ex.Message);
            }
        }

        public (bool ok, string message) Update(Voucher voucher)
        {
            if (voucher == null) return (false, "Dữ liệu trống.");
            if (string.IsNullOrWhiteSpace(voucher.MaVoucher)) return (false, "Thiếu mã voucher.");
            if (voucher.NgayKetThuc < voucher.NgayBatDau) return (false, "Ngày kết thúc phải >= ngày bắt đầu.");
            if (voucher.GiaTri <= 0) return (false, "Giá trị voucher phải > 0.");

            using var db = new ShopDbContext();
            var exist = db.Vouchers.FirstOrDefault(v => v.MaVoucher == voucher.MaVoucher);
            if (exist == null) return (false, "Không tìm thấy voucher để cập nhật.");

            try
            {
                db.Entry(exist).CurrentValues.SetValues(voucher);
                db.SaveChanges();
                return (true, "Cập nhật voucher thành công.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi cập nhật voucher: " + ex.Message);
            }
        }

        public (bool ok, string message) Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return (false, "Thiếu mã voucher.");

            using var db = new ShopDbContext();
            var v = db.Vouchers.FirstOrDefault(x => x.MaVoucher == id);
            if (v == null) return (false, "Không tìm thấy voucher để xoá.");

            try
            {
                db.Vouchers.Remove(v);
                db.SaveChanges();
                return (true, "Xoá voucher thành công.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi khi xoá voucher: " + ex.Message);
            }
        }
    }
}
