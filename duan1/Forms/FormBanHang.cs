using duan1.DTO;
using duan1.Models;
using duan1.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace duan1.Forms
{
    public partial class FormBanHang : Form
    {
        // ==== Repos / Db ====
        SanPhamRepo sprepo = new SanPhamRepo();              // giữ lại nếu nơi khác cần
        ShopDbContext db = new ShopDbContext();
        KhachHangRepo khrepo = new KhachHangRepo();
        DonHangChiTietRepo dhctRepo = new DonHangChiTietRepo();
        DonHangRepo dhRepo = new DonHangRepo();
        VoucherRepo vRepo = new VoucherRepo();
        ChiTietSanPhamRepo ctspRepo = new ChiTietSanPhamRepo();

        // ==== Models in-memory ====
        private class SPCTView
        {
            public string MaSPCT { get; set; }
            public string MaSP { get; set; }
            public string TenSP { get; set; }
            public string KichThuoc { get; set; }
            public string MauSac { get; set; }
            public decimal GiaBan { get; set; }
            public int SoLuongTon { get; set; }
        }

        private List<SPCTView> _spctCache = new List<SPCTView>();
        private List<KhachHang> _khCache = new List<KhachHang>();

        private readonly List<DonHangChiTiet> GioHang = new List<DonHangChiTiet>();
        private string _maVoucherDangApDung = null;
        private bool daApDungVoucher = false;

        // helper
        int soLuongTon = 0;
        string maSp = string.Empty;

        public FormBanHang()
        {
            InitializeComponent();
        }

        // ================== LOAD DATA ==================
        private void LoadSanPham()
        {
            // CHỈ lấy từ ChiTietSanPhams + tên SP
            _spctCache = db.ChiTietSanPhams
                .Join(db.SanPhams, ct => ct.MaSP, sp => sp.MaSP, (ct, sp) => new SPCTView
                {
                    MaSPCT = ct.MaSPCT,
                    MaSP = sp.MaSP,
                    TenSP = sp.TenSP,
                    KichThuoc = ct.KichThuoc,
                    MauSac = ct.MauSac,
                    GiaBan = ct.GiaBan,
                    SoLuongTon = ct.SoLuongTon
                })
                .OrderBy(x => x.TenSP).ThenBy(x => x.KichThuoc).ThenBy(x => x.MauSac)
                .ToList();

            dtg_sanPham.AutoGenerateColumns = true;
            dtg_sanPham.DataSource = _spctCache;
            SetupSanPhamGrid();
        }

        private void ApplySanPhamFilter(string keyword)
        {
            keyword = (keyword ?? "").Trim().ToLower();

            var q = _spctCache.AsEnumerable();
            if (!string.IsNullOrEmpty(keyword))
            {
                q = q.Where(x =>
                    (x.MaSP ?? "").ToLower().Contains(keyword) ||
                    (x.TenSP ?? "").ToLower().Contains(keyword) ||
                    (x.KichThuoc ?? "").ToLower().Contains(keyword) ||
                    (x.MauSac ?? "").ToLower().Contains(keyword));
            }

            dtg_sanPham.DataSource = q.ToList();
            SetupSanPhamGrid();
        }

        private void SetupSanPhamGrid()
        {
            var g = dtg_sanPham;
            if (g == null || g.Columns.Count == 0) return;

            // Ẩn khóa nếu muốn
            if (g.Columns["MaSPCT"] != null) { g.Columns["MaSPCT"].Visible = false; g.Columns["MaSPCT"].HeaderText = "Mã SPCT"; }
            if (g.Columns["MaSP"] != null) { g.Columns["MaSP"].Visible = false; g.Columns["MaSP"].HeaderText = "Mã SP"; }

            if (g.Columns["TenSP"] != null) g.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            if (g.Columns["KichThuoc"] != null) g.Columns["KichThuoc"].HeaderText = "Size";
            if (g.Columns["MauSac"] != null) g.Columns["MauSac"].HeaderText = "Màu";

            if (g.Columns["GiaBan"] != null)
            {
                g.Columns["GiaBan"].HeaderText = "Đơn giá";
                g.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
                g.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (g.Columns["SoLuongTon"] != null)
            {
                g.Columns["SoLuongTon"].HeaderText = "Tồn";
                g.Columns["SoLuongTon"].DefaultCellStyle.Format = "N0";
                g.Columns["SoLuongTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            g.ClearSelection();
        }

        private void LoadKhachHang()
        {
            _khCache = khrepo.GetAll();
            dtg_khachHang.AutoGenerateColumns = true;
            dtg_khachHang.DataSource = _khCache;

            if (dtg_khachHang.Columns["DonHangs"] != null)
                dtg_khachHang.Columns["DonHangs"].Visible = false;

            if (dtg_khachHang.Columns["HoTen"] != null)
                dtg_khachHang.Columns["HoTen"].HeaderText = "Họ tên";
            if (dtg_khachHang.Columns["SDT"] != null)
                dtg_khachHang.Columns["SDT"].HeaderText = "Số điện thoại";
            if (dtg_khachHang.Columns["DiaChi"] != null)
                dtg_khachHang.Columns["DiaChi"].HeaderText = "Địa chỉ";

            dtg_khachHang.ClearSelection();
        }

        private void ApplyKhachHangFilter(string keyword)
        {
            keyword = (keyword ?? "").Trim().ToLower();

            var filtered = _khCache.Where(x =>
                (x.MaKH ?? "").ToLower().Contains(keyword) ||
                (x.HoTen ?? "").ToLower().Contains(keyword) ||
                (x.SDT ?? "").ToLower().Contains(keyword) ||
                (x.Email ?? "").ToLower().Contains(keyword) ||
                (x.DiaChi ?? "").ToLower().Contains(keyword)
            ).ToList();

            dtg_khachHang.DataSource = filtered;
        }

        private void LoadGioHang()
        {
            dtg_gioHang.DataSource = null;

            if (!dtg_gioHang.Columns.Contains("Chon"))
            {
                var chk = new DataGridViewCheckBoxColumn { Name = "Chon", HeaderText = "Chọn" };
                dtg_gioHang.Columns.Insert(0, chk);
            }

            var spChiTietList = (from ct in db.ChiTietSanPhams
                                 join sp in db.SanPhams on ct.MaSP equals sp.MaSP
                                 select new
                                 {
                                     ct.MaSPCT,
                                     TenSanPham = sp.TenSP,
                                     ct.KichThuoc,
                                     ct.MauSac
                                 }).ToList();

            var data = GioHang.Select(x => new
            {
                x.MaSPCT,
                TenSanPham = spChiTietList
                                .Where(ct => ct.MaSPCT == x.MaSPCT)
                                .Select(ct => $"{ct.TenSanPham} (Size: {ct.KichThuoc}, Màu: {ct.MauSac})")
                                .FirstOrDefault() ?? "Không tìm thấy",
                x.DonGia,
                x.SoLuong,
                ThanhTien = x.DonGia * x.SoLuong
            }).ToList();

            dtg_gioHang.DataSource = data;

            if (dtg_gioHang.Columns["TenSanPham"] != null) dtg_gioHang.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            if (dtg_gioHang.Columns["DonGia"] != null) dtg_gioHang.Columns["DonGia"].HeaderText = "Đơn giá";
            if (dtg_gioHang.Columns["SoLuong"] != null) dtg_gioHang.Columns["SoLuong"].HeaderText = "Số lượng";
            if (dtg_gioHang.Columns["ThanhTien"] != null) dtg_gioHang.Columns["ThanhTien"].HeaderText = "Thành tiền";

            SetupGioHangGrid();

            txt_tongTien.Text = GioHang.Sum(x => (x.DonGia * x.SoLuong)).ToString("N0");
        }

        private void LoadNhanVien()
        {
            var ten = PhienDangNhap.HoTen;
            var email = PhienDangNhap.Email;
            lab_tenNhanVien.Text = $"@{ten} ({email})";
        }

        private void LoadData()
        {
            LoadSanPham();
            LoadKhachHang();
            LoadNhanVien();
            LoadGioHang();
            ApplyTheme();
        }

        // ================== THEME / STYLE ==================
        private void ApplyTheme()
        {
            var bg = ColorTranslator.FromHtml("#F6F7FB");
            var primary = ColorTranslator.FromHtml("#5B8DEF");
            var danger = ColorTranslator.FromHtml("#F06548");
            var muted = ColorTranslator.FromHtml("#6B7280");

            this.BackColor = bg;
            this.Font = new Font("Segoe UI", 9.5F);

            lab_tenNhanVien.ForeColor = primary;
            lab_thongBao.ForeColor = muted;
            lab_thongBaoChon.ForeColor = muted;

            StyleButton(btn_themGioHang, primary);
            StyleButton(btn_thanhToan, primary);
            StyleButton(btn_apDungVoucher, primary);
            StyleButton(btn_xoaSanPham, danger);
            StyleButton(btn_them, primary);

            StyleTextBox(txt_timKiem);
            StyleTextBox(txt_timKhach);
            StyleTextBox(txt_voucher);
            StyleTextBox(txt_tongTien, readOnly: true);

            StyleGrid(dtg_sanPham);
            StyleGrid(dtg_khachHang);
            StyleGrid(dtg_gioHang);

            StyleNumeric(num_soLuong);
            StyleNumeric(num_soLuongSua);
        }

        private void StyleButton(Button btn, Color bg)
        {
            if (btn == null) return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = bg;
            btn.ForeColor = Color.White;
            btn.Cursor = Cursors.Hand;
            btn.Padding = new Padding(8, 4, 8, 4);
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(bg);
            btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(bg);
        }

        private void StyleTextBox(TextBox tb, bool readOnly = false)
        {
            if (tb == null) return;
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.BackColor = readOnly ? ColorTranslator.FromHtml("#F3F4F6") : Color.White;
            tb.ReadOnly = readOnly;
            tb.Margin = new Padding(0, 2, 0, 8);
        }

        private void StyleGrid(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EEF2FF");
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#1F2937");
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#111827");
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F9FAFB");
            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#DBEAFE");
            dgv.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#111827");

            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            // double buffer
            var pi = dgv.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi?.SetValue(dgv, true, null);
        }

        private void StyleNumeric(NumericUpDown nud)
        {
            if (nud == null) return;
            nud.DecimalPlaces = 0;
            nud.ThousandsSeparator = true;
            nud.Minimum = 0;
            nud.Maximum = 1000000000;
            nud.TextAlign = HorizontalAlignment.Right;
        }

        private void SetupGioHangGrid()
        {
            var g = dtg_gioHang;
            if (g == null || g.Columns.Count == 0) return;

            if (g.Columns.Contains("DonGia"))
            {
                g.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                g.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (g.Columns.Contains("SoLuong"))
            {
                g.Columns["SoLuong"].DefaultCellStyle.Format = "N0";
                g.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (g.Columns.Contains("ThanhTien"))
            {
                g.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                g.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (g.Columns.Contains("TenSanPham"))
            {
                g.Columns["TenSanPham"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        // ================== EVENTS ==================
        private void FormBanHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtg_sanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dtg_sanPham.Rows[e.RowIndex];
            string maSPCT = row.Cells["MaSPCT"]?.Value?.ToString();
            maSp = row.Cells["MaSP"]?.Value?.ToString();
            string tenSP = row.Cells["TenSP"]?.Value?.ToString();
            string size = row.Cells["KichThuoc"]?.Value?.ToString();
            string mau = row.Cells["MauSac"]?.Value?.ToString();

            decimal gia = 0; decimal.TryParse(row.Cells["GiaBan"]?.Value?.ToString(), out gia);
            int ton = 0; int.TryParse(row.Cells["SoLuongTon"]?.Value?.ToString(), out ton);

            lab_tenSanPham.Text = $"{tenSP} (Size: {size}, Màu: {mau})";
            lab_donGia.Text = gia.ToString("N0");
            lab_soLuongTon.Text = ton.ToString("N0");
            lab_maSanPham.Text = maSp;
            soLuongTon = ton;

            // Combo: có thể chỉ 1 biến thể (đang chọn), hoặc liệt kê tất cả biến thể cùng MaSP
            var listChiTiet = db.ChiTietSanPhams
                .Where(ct => ct.MaSP == maSp)
                .Select(ct => new
                {
                    ct.MaSPCT,
                    MoTa = $"Size: {ct.KichThuoc} - Màu: {ct.MauSac} - Còn: {ct.SoLuongTon}"
                })
                .ToList();

            cbo_choTietSanPham.DataSource = listChiTiet;
            cbo_choTietSanPham.DisplayMember = "MoTa";
            cbo_choTietSanPham.ValueMember = "MaSPCT";
            cbo_choTietSanPham.SelectedValue = maSPCT;
        }

        private void dtg_sanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maSP = dtg_sanPham.Rows[e.RowIndex].Cells["MaSP"].Value.ToString();
            var formCTSP = new FormChiTietSanPham(maSP);

            if (formCTSP.ShowDialog() == DialogResult.OK)
            {
                string maSPCT = formCTSP.SelectedMaSPCT;
                cbo_choTietSanPham.SelectedValue = maSPCT;
                lab_thongBaoChon.Text = "Đã chọn nâng cao";
                lab_thongBaoChon.ForeColor = Color.Green;
            }
        }

        private void dtg_sanPham_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Không cho sửa trực tiếp bảng sản phẩm (giữ trống handler hoặc remove trong Designer)
        }

        private void dtg_khachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maKhachHangMoi = dtg_khachHang.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();

            if (GioHang.Count > 0 && lab_maKhachHang.Text != "" && lab_maKhachHang.Text != maKhachHangMoi)
            {
                var result = MessageBox.Show(
                    "Bạn đang có giỏ hàng với khách hàng khác. Thay đổi khách hàng sẽ xóa giỏ hàng hiện tại. Bạn có chắc không?",
                    "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel) return;

                GioHang.Clear();
                LoadGioHang();
            }

            lab_tenKhachHang.Text = dtg_khachHang.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
            lab_maKhachHang.Text = maKhachHangMoi;
        }

        private void dtg_gioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dtg_gioHang.Rows[e.RowIndex];
            int soLuong = 0;
            int.TryParse(row.Cells["SoLuong"]?.Value?.ToString(), out soLuong);
            num_soLuongSua.Value = soLuong;
        }

        // ================== BUTTONS ==================
        private void btn_themGioHang_Click(object sender, EventArgs e)
        {
            int soLuong = (int)num_soLuong.Value;

            if (string.IsNullOrWhiteSpace(lab_tenSanPham.Text) ||
                string.IsNullOrWhiteSpace(lab_donGia.Text) ||
                string.IsNullOrWhiteSpace(lab_tenKhachHang.Text) ||
                cbo_choTietSanPham.SelectedValue == null)
            {
                lab_thongBao.Text = "Vui lòng chọn sản phẩm (kèm biến thể) và khách hàng trước khi thêm.";
                lab_thongBao.ForeColor = Color.Red;
                lab_thongBao.Visible = true;
                return;
            }

            string maSPCT = cbo_choTietSanPham.SelectedValue.ToString();
            var ctsp = db.ChiTietSanPhams.FirstOrDefault(x => x.MaSPCT == maSPCT);
            if (ctsp == null)
            {
                lab_thongBao.Text = "Biến thể sản phẩm không tồn tại.";
                lab_thongBao.ForeColor = Color.Red;
                return;
            }

            if (soLuong <= 0 || soLuong > ctsp.SoLuongTon)
            {
                lab_thongBao.Text = "Số lượng không hợp lệ.";
                lab_thongBao.ForeColor = Color.Red;
                return;
            }

            var item = GioHang.FirstOrDefault(x => x.MaSPCT == maSPCT);
            if (item != null)
            {
                if (item.SoLuong + soLuong > ctsp.SoLuongTon)
                {
                    lab_thongBao.Text = $"Không thể thêm quá số lượng tồn ({ctsp.SoLuongTon}).";
                    lab_thongBao.ForeColor = Color.Red;
                    return;
                }
                item.SoLuong += soLuong;
            }
            else
            {
                GioHang.Add(new DonHangChiTiet
                {
                    MaDHCT = Guid.NewGuid().ToString(),
                    MaDH = string.Empty,
                    MaSPCT = maSPCT,
                    DonGia = ctsp.GiaBan,
                    SoLuong = soLuong
                });
            }

            LoadGioHang();
            ClearSanPhamFields();
            lab_thongBao.Text = "Đã thêm vào giỏ hàng.";
            lab_thongBao.ForeColor = Color.Green;
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            if (dtg_gioHang.CurrentRow == null) return;

            int rowIndex = dtg_gioHang.CurrentRow.Index;
            var item = GioHang[rowIndex];
            int soLuongMoi = (int)num_soLuongSua.Value;

            int tonKho = ctspRepo.GetSoLuongTon(item.MaSPCT);
            if (soLuongMoi <= 0)
            {
                lab_thongBao.Text = "Số lượng phải lớn hơn 0.";
                lab_thongBao.ForeColor = Color.Red;
                return;
            }
            if (soLuongMoi > tonKho)
            {
                lab_thongBao.Text = $"Số lượng vượt quá tồn kho ({tonKho}).";
                lab_thongBao.ForeColor = Color.Red;
                return;
            }

            item.SoLuong = soLuongMoi;
            LoadGioHang();
            CapNhatTongTienHienThi();
            lab_thongBao.Text = "Cập nhật số lượng thành công.";
            lab_thongBao.ForeColor = Color.Green;
        }

        private void btn_xoaSanPham_Click(object sender, EventArgs e)
        {
            if (dtg_gioHang.CurrentRow == null) return;

            int rowIndex = dtg_gioHang.CurrentRow.Index;
            GioHang.RemoveAt(rowIndex);
            LoadGioHang();
            lab_thongBao.Text = "Đã xóa sản phẩm khỏi giỏ hàng.";
            lab_thongBao.ForeColor = Color.Green;
        }

        private void btn_thanhToan_Click(object sender, EventArgs e)
        {
            if (GioHang.Count == 0)
            {
                lab_thongBao.Text = "Giỏ hàng trống, không thể thanh toán.";
                lab_thongBao.ForeColor = Color.Red;
                lab_thongBao.Visible = true;
                return;
            }
            if (string.IsNullOrWhiteSpace(lab_maKhachHang.Text))
            {
                lab_thongBao.Text = "Vui lòng chọn khách hàng trước khi thanh toán.";
                lab_thongBao.ForeColor = Color.Red;
                lab_thongBao.Visible = true;
                return;
            }

            string maVoucher = null;
            decimal tongTien = GioHang.Sum(x => x.DonGia * x.SoLuong);

            if (!string.IsNullOrWhiteSpace(txt_voucher.Text))
            {
                var voucher = vRepo.GetValidVouchers()
                    .FirstOrDefault(x => x.MaVoucher.Equals(txt_voucher.Text.Trim(), StringComparison.OrdinalIgnoreCase));
                if (voucher != null)
                {
                    maVoucher = voucher.MaVoucher;
                    tongTien -= tongTien * voucher.GiaTri / 100m;
                }
            }

            string maDh = Guid.NewGuid().ToString();
            var dh = new DonHang
            {
                MaDH = maDh,
                NgayDat = DateTime.Now,
                TongTien = tongTien,
                TrangThai = "Đã thanh toán",
                MaKH = lab_maKhachHang.Text,
                MaNV = PhienDangNhap.MaNV,
                MaVoucher = maVoucher
            };

            if (!dhRepo.Add(dh))
            {
                lab_thongBao.Text = "Lỗi khi tạo đơn hàng. Vui lòng thử lại.";
                lab_thongBao.ForeColor = Color.Red;
                return;
            }

            foreach (var item in GioHang)
            {
                item.MaDH = maDh;
                if (!dhctRepo.Add(item))
                {
                    lab_thongBao.Text = "Lỗi khi thêm sản phẩm vào đơn hàng. Vui lòng thử lại.";
                    lab_thongBao.ForeColor = Color.Red;
                    return;
                }
                ctspRepo.TruTonKho(item.MaSPCT, item.SoLuong);
            }

            lab_thongBao.Text = "Thanh toán thành công!";
            lab_thongBao.ForeColor = Color.Green;

            LoadData();
            GioHang.Clear();
            ClearInputFields();
            daApDungVoucher = false;
        }

        private void btn_apDungVoucher_Click(object sender, EventArgs e)
        {
            if (GioHang.Count == 0)
            {
                lab_thongBao.Text = "Giỏ hàng trống, không thể áp dụng voucher.";
                lab_thongBao.ForeColor = Color.Red;
                lab_thongBao.Visible = true;
                return;
            }

            var code = txt_voucher.Text.Trim();
            if (string.IsNullOrEmpty(code))
            {
                lab_thongBao.Text = "Vui lòng nhập mã voucher.";
                lab_thongBao.ForeColor = Color.Red;
                lab_thongBao.Visible = true;
                return;
            }

            var voucher = vRepo.GetValidVouchers()
                .FirstOrDefault(x => x.MaVoucher.Equals(code, StringComparison.OrdinalIgnoreCase));

            if (voucher == null)
            {
                lab_thongBao.Text = "Mã voucher không hợp lệ hoặc đã hết hạn.";
                lab_thongBao.ForeColor = Color.Red;
                lab_thongBao.Visible = true;
                return;
            }

            if (daApDungVoucher && string.Equals(_maVoucherDangApDung, voucher.MaVoucher, StringComparison.OrdinalIgnoreCase))
            {
                lab_thongBao.Text = "Voucher này đã được áp dụng.";
                lab_thongBao.ForeColor = Color.Red;
                lab_thongBao.Visible = true;
                return;
            }

            _maVoucherDangApDung = voucher.MaVoucher;
            daApDungVoucher = true;
            lab_tenVoucher.Text = voucher.TenVoucher;

            CapNhatTongTienHienThi();

            lab_thongBao.Text = "Áp dụng voucher thành công!";
            lab_thongBao.ForeColor = Color.Green;
            lab_thongBao.Visible = true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            using (var f = new FormKhachHang())
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this);
            }
        }

        private void txt_timKhach_TextChanged(object sender, EventArgs e)
        {
            ApplyKhachHangFilter(txt_timKhach.Text);
        }

        private void txt_timKiem_TextChanged(object sender, EventArgs e)
        {
            ApplySanPhamFilter(txt_timKiem.Text);
        }

        private void txt_voucher_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var validVoucher = vRepo.GetValidVouchers()
                    .FirstOrDefault(x => x.MaVoucher.Equals(txt_voucher.Text.Trim(), StringComparison.OrdinalIgnoreCase));
                lab_tenVoucher.Text = validVoucher?.TenVoucher ?? "";
            }
            catch
            {
                lab_tenVoucher.Text = "";
            }
        }

        // ================== HELPERS ==================
        private void CapNhatTongTienHienThi()
        {
            decimal subtotal = GioHang.Sum(x => x.DonGia * x.SoLuong);

            if (!string.IsNullOrEmpty(_maVoucherDangApDung))
            {
                var voucher = vRepo.GetValidVouchers()
                    .FirstOrDefault(x => x.MaVoucher.Equals(_maVoucherDangApDung, StringComparison.OrdinalIgnoreCase));
                if (voucher != null)
                {
                    var giam = subtotal * voucher.GiaTri / 100m;
                    subtotal -= giam;
                }
                else
                {
                    _maVoucherDangApDung = null;
                    daApDungVoucher = false;
                }
            }

            if (subtotal < 0) subtotal = 0;
            txt_tongTien.Text = subtotal.ToString("N0");
        }

        private void ClearSanPhamFields()
        {
            lab_tenSanPham.Text = string.Empty;
            lab_donGia.Text = string.Empty;
            num_soLuong.Value = 0;
            lab_soLuongTon.Text = string.Empty;
            lab_maSanPham.Text = string.Empty;
            cbo_choTietSanPham.DataSource = null;
        }

        private void ClearKhachHangFields()
        {
            lab_tenKhachHang.Text = string.Empty;
            lab_maKhachHang.Text = string.Empty;
        }

        private void ClearInputFields()
        {
            ClearSanPhamFields();
            ClearKhachHangFields();
            LoadGioHang();
            txt_tongTien.Text = "0";
            txt_voucher.Text = string.Empty;
            lab_tenVoucher.Text = string.Empty;
        }
    }
}
