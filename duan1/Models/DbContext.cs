using Microsoft.EntityFrameworkCore;

namespace duan1.Models
{
    public class ShopDbContext : DbContext
    {
        public DbSet<DanhMuc> DanhMucs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<VaiTro> VaiTros { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }

        // Constructor không tham số, tự thiết lập connection string
        public ShopDbContext() : base(GetOptions())
        {
        }

        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

        private static DbContextOptions<ShopDbContext> GetOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=duan1;User Id=sa;Password=12345678;TrustServerCertificate=True;");
            return optionsBuilder.Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Có thể bổ sung cấu hình đặc biệt ở đây nếu cần!
        }
    }
}
