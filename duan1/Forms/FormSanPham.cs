using duan1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace duan1.Forms
{
    public partial class FormSanPham : Form
    {
        ShopDbContext db = new ShopDbContext();
        public FormSanPham()
        {
            InitializeComponent();
            txtMaSP.ReadOnly = true;
            txtMaSP.TabStop = false;
            BuildLayoutLite();   // sắp xếp control vào khung bo góc
            ApplyThemeLite();
            LoadDanhMuc();
            LoadSanPham();
        }
        //
        Color ColBg = ColorTranslator.FromHtml("#F6F7FB");
        Color ColText = ColorTranslator.FromHtml("#2B2F33");
        Color ColMuted = ColorTranslator.FromHtml("#6B7280");
        Color ColPrimary = ColorTranslator.FromHtml("#5B8DEF");
        Color ColDanger = ColorTranslator.FromHtml("#F06548");

        Panel _pRight;        // chứa thanh tìm kiếm + DataGridView
        Panel _cardLeft;      // "card" bo góc ôm Ảnh + form + nút
        Panel _searchBar;     // thanh tìm kiếm

        // ======= LAYOUT không cần class mới
        private void BuildLayoutLite()
        {
            // Tiêu đề
            var lblTitle = new Label
            {
                Text = "Sản phẩm",
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 22f),
                ForeColor = ColPrimary,
                Dock = DockStyle.Top,
                Padding = new Padding(16, 12, 16, 8)
            };
            Controls.Add(lblTitle);
            lblTitle.BringToFront();

            // Card bên trái (bo góc + viền)
            _cardLeft = new Panel { Dock = DockStyle.Left, Width = 560, Padding = new Padding(16), BackColor = Color.White };
            _cardLeft.Paint += Card_Paint;
            _cardLeft.Resize += (s, e) => UpdateCardRegion(_cardLeft, 12);
            Controls.Add(_cardLeft);
            _cardLeft.BringToFront();
            UpdateCardRegion(_cardLeft, 12);

            // Khu bên phải
            _pRight = new Panel { Dock = DockStyle.Fill, BackColor = ColBg };
            Controls.Add(_pRight);
            _pRight.BringToFront();

            // Thanh search
            _searchBar = new Panel { Dock = DockStyle.Top, Height = 56, Padding = new Padding(16, 10, 16, 10), BackColor = ColBg };
            _pRight.Controls.Add(_searchBar);

            // ===== Đặt control sẵn có vào search bar
            cbDanhMuc.Parent = _searchBar;
            txtTimKiem.Parent = _searchBar;
            btnTimKiem.Parent = _searchBar;
            btnLamMoi.Parent = _searchBar;

            cbDanhMuc.SetBounds(16, 10, 170, 32);
            txtTimKiem.SetBounds(cbDanhMuc.Right + 10, 10, 260, 32);
            btnTimKiem.SetBounds(txtTimKiem.Right + 10, 10, 90, 32);
            btnLamMoi.SetBounds(btnTimKiem.Right + 10, 10, 90, 32);

            // ===== Lưới
            dgvSanPham.Parent = _pRight;
            dgvSanPham.Dock = DockStyle.Fill;

            // ===== Card: Ảnh + Chọn ảnh
            picHinhAnh.Parent = _cardLeft;
            picHinhAnh.Dock = DockStyle.Top;
            picHinhAnh.Height = 250;
            picHinhAnh.Margin = new Padding(0, 0, 0, 12);

            btnChonAnh.Parent = _cardLeft;
            btnChonAnh.Dock = DockStyle.Top;
            btnChonAnh.Height = 36;
            btnChonAnh.Margin = new Padding(0, 0, 0, 16);

            // ===== Lưới nhập 2 cột
            var grid = new TableLayoutPanel
            {
                Parent = _cardLeft,
                Dock = DockStyle.Top,
                Height = 260,
                ColumnCount = 2,
                RowCount = 7,
                Padding = new Padding(0, 0, 0, 8)
            };
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            void addRow(string label, Control input, int row)
            {
                var lb = new Label { Text = label, AutoSize = true, ForeColor = ColMuted, Margin = new Padding(0, 8, 8, 0) };
                grid.Controls.Add(lb, 0, row);
                grid.Controls.Add(input, 1, row);
                input.Margin = new Padding(0, 4, 0, 4);
                input.Width = 380;
                input.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            }

            txtMaSP.ReadOnly = true; txtMaSP.TabStop = false;
            addRow("Mã SP", txtMaSP, 0);
            addRow("Tên SP", txtTenSP, 1);
            addRow("Giá bán", txtGiaBan, 2);
            addRow("Số lượng", txtSoLuong, 3);
            addRow("Kích thước", txtKichThuoc, 4);
            addRow("Màu sắc", txtMauSac, 5);
            addRow("Mô tả", txtMoTa, 6);

            // ===== Hàng nút
            var rowButtons = new FlowLayoutPanel
            {
                Parent = _cardLeft,
                Dock = DockStyle.Top,
                Height = 46,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };
            rowButtons.Controls.AddRange(new Control[] { btnThem, btnSua, btnXoa });
            foreach (Button b in rowButtons.Controls) { b.Width = 100; b.Height = 36; b.Margin = new Padding(0, 8, 10, 0); }
        }

        // ======= THEME
        private void ApplyThemeLite()
        {
            // Form
            BackColor = ColBg; ForeColor = ColText; Font = new Font("Segoe UI", 10f);

            // Buttons
            void StyleButton(Button b, Color bg)
            {
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.BackColor = bg;
                b.ForeColor = Color.White;
                b.Font = new Font("Segoe UI Semibold", 10f);
                b.Cursor = Cursors.Hand;
                b.MouseEnter += (s, e) => b.BackColor = ControlPaint.Light(bg);
                b.MouseLeave += (s, e) => b.BackColor = bg;
            }
            StyleButton(btnChonAnh, ColPrimary);
            StyleButton(btnThem, ColPrimary);
            StyleButton(btnSua, ColPrimary);
            StyleButton(btnXoa, ColDanger);
            StyleButton(btnTimKiem, ColPrimary);
            StyleButton(btnLamMoi, ColorTranslator.FromHtml("#64748B"));

            // Inputs
            foreach (Control c in new Control[] { txtMaSP, txtTenSP, txtGiaBan, txtSoLuong, txtKichThuoc, txtMauSac, txtMoTa, txtTimKiem })
                if (c is TextBox tb) { tb.BorderStyle = BorderStyle.FixedSingle; tb.BackColor = Color.White; tb.ForeColor = ColText; }

            cbDanhMuc.FlatStyle = FlatStyle.Flat;
            cbDanhMuc.BackColor = Color.White;
            cbDanhMuc.ForeColor = ColText;

            // Picture
            picHinhAnh.BackColor = Color.White;
            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picHinhAnh.BorderStyle = BorderStyle.None;

            // Grid
            StyleGrid(dgvSanPham);
        }
        private void StyleGrid(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EEF2FF");
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#1F2937");
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10f);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#111827");
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F9FAFB");
            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#DBEAFE");
            dgv.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#111827");

            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 36;

            var pi = typeof(DataGridView).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi?.SetValue(dgv, true, null);
        }
        private void Card_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel; if (p == null) return;
            var r = p.ClientRectangle; r.Inflate(-1, -1);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var path = RoundedRect(r, 12);
            using var pen = new Pen(Color.FromArgb(210, 214, 220), 1);
            e.Graphics.DrawPath(pen, path);
        }

        private void UpdateCardRegion(Panel p, int radius)
        {
            var r = p.ClientRectangle; if (r.Width <= 0 || r.Height <= 0) return;
            using var path = RoundedRect(new Rectangle(0, 0, r.Width, r.Height), radius);
            p.Region?.Dispose();
            p.Region = new Region(path);
        }
        private GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }



        private string GenerateNextMaSP_FillGaps_FromSPCT()
        {
            var usedIds = db.ChiTietSanPhams
                            .AsNoTracking()
                            .Select(ct => ct.MaSP)
                            .Distinct()
                            .ToList();

            var usedNums = new HashSet<int>();
            foreach (var id in usedIds)
            {
                if (string.IsNullOrEmpty(id) || id.Length <= 2) continue;
                if (!id.StartsWith("SP", StringComparison.OrdinalIgnoreCase)) continue;

                if (int.TryParse(id.Substring(2), out int n) && n > 0)
                    usedNums.Add(n);
            }

            int candidate = 1;
            while (usedNums.Contains(candidate)) candidate++;

            return "SP" + (candidate < 100 ? candidate.ToString("D2") : candidate.ToString());
        }


        private bool _userClickedRow = false;
        private string _selectedMaSPCT = null;

        // Helper: lấy giá trị theo tên cột an toàn
        private string GetCellValue(DataGridViewRow row, string colName)
        {
            if (!dgvSanPham.Columns.Contains(colName)) return null;
            return row.Cells[colName].Value?.ToString();
        }
        private void ApplyModernUI()
        {
            // Form
            this.BackColor = Color.FromArgb(30, 30, 30); // Nền tối
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // DataGridView
            dgvSanPham.BackgroundColor = Color.FromArgb(45, 45, 45);
            dgvSanPham.GridColor = Color.FromArgb(70, 70, 70);
            dgvSanPham.BorderStyle = BorderStyle.None;
            dgvSanPham.EnableHeadersVisualStyles = false;

            dgvSanPham.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dgvSanPham.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvSanPham.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvSanPham.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvSanPham.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
            dgvSanPham.DefaultCellStyle.ForeColor = Color.White;
            dgvSanPham.DefaultCellStyle.SelectionBackColor = Color.FromArgb(64, 64, 64);
            dgvSanPham.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvSanPham.RowTemplate.Height = 35;

            // PictureBox
            picHinhAnh.BackColor = Color.FromArgb(50, 50, 50);
            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            picHinhAnh.BorderStyle = BorderStyle.FixedSingle;

            // Các TextBox
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.BackColor = Color.FromArgb(45, 45, 45);
                    txt.ForeColor = Color.White;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
            }

            // ComboBox
            cbDanhMuc.BackColor = Color.FromArgb(45, 45, 45);
            cbDanhMuc.ForeColor = Color.White;
            cbDanhMuc.FlatStyle = FlatStyle.Flat;

            // Buttons
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.FromArgb(0, 122, 204);
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    btn.Cursor = Cursors.Hand;

                    btn.MouseEnter += (s, e) => { btn.BackColor = Color.FromArgb(28, 151, 234); };
                    btn.MouseLeave += (s, e) => { btn.BackColor = Color.FromArgb(0, 122, 204); };
                }
            }
        }

        private void LoadDanhMuc()
        {
            var danhmucs = db.DanhMucs.ToList();
            cbDanhMuc.DataSource = danhmucs;
            cbDanhMuc.DisplayMember = "TenDM";
            cbDanhMuc.ValueMember = "MaDM";
        }

        private void LoadSanPham(string maDM = null)
        {
            var data = db.ChiTietSanPhams
        .Join(db.SanPhams, ct => ct.MaSP, sp => sp.MaSP, (ct, sp) => new { ct, sp })
        .Join(db.DanhMucs, t => t.sp.MaDM, dm => dm.MaDM, (t, dm) => new
        {
            t.ct.MaSPCT,
            t.sp.MaSP,
            t.sp.TenSP,
            GiaBan = t.ct.GiaBan,
            SoLuongTon = t.ct.SoLuongTon,
            t.sp.MoTa,
            t.sp.MaDM,
            TenDM = dm.TenDM,
            HinhAnh = t.ct.HinhAnh, // vẫn giữ để click hàng thì load ảnh
            t.ct.KichThuoc,
            t.ct.MauSac
        });

            if (!string.IsNullOrEmpty(maDM))
                data = data.Where(x => x.MaDM == maDM);

            dgvSanPham.DataSource = data.ToList();

            // Định dạng + ẩn cột sau khi bind
            SetupSanPhamGrid();

            // Clear selection
            dgvSanPham.ClearSelection();
            dgvSanPham.CurrentCell = null;
            _selectedMaSPCT = null;
            _userClickedRow = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var maSP = GenerateNextMaSP_FillGaps_FromSPCT();
            txtMaSP.Text = maSP;



            //if (string.IsNullOrWhiteSpace(txtMaSP.Text)) { MessageBox.Show("Nhập MaSP"); return; }
            if (string.IsNullOrWhiteSpace(txtTenSP.Text)) { MessageBox.Show("Nhập Tên SP"); return; }
            if (cbDanhMuc.SelectedValue == null) { MessageBox.Show("Chọn Danh mục"); return; }
            if (!decimal.TryParse(txtGiaBan.Text, out var giaBan) || giaBan < 0) { MessageBox.Show("Giá không hợp lệ"); return; }
            if (!int.TryParse(txtSoLuong.Text, out var soLuong) || soLuong < 0) { MessageBox.Show("Số lượng không hợp lệ"); return; }
            if (string.IsNullOrWhiteSpace(txtKichThuoc.Text) || string.IsNullOrWhiteSpace(txtMauSac.Text)) { MessageBox.Show("Nhập Size & Màu"); return; }

            // Bắt buộc có ảnh (SanPhams.HinhAnh và/hoặc ChiTietSanPhams.HinhAnh đang NOT NULL)
            if (picHinhAnh.Tag == null || string.IsNullOrWhiteSpace(picHinhAnh.Tag.ToString()))
            {
                MessageBox.Show("Vui lòng chọn ảnh sản phẩm trước khi lưu!", "Thiếu hình ảnh",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var hinhAnh = picHinhAnh.Tag.ToString();

            //var maSP = txtMaSP.Text.Trim();
            var tenSP = txtTenSP.Text.Trim();
            var moTa = txtMoTa.Text?.Trim();
            var maDM = cbDanhMuc.SelectedValue.ToString().Trim();
            var kichThuoc = txtKichThuoc.Text.Trim();
            var mauSac = txtMauSac.Text.Trim();

            // 0) Danh mục phải tồn tại
            if (!db.DanhMucs.Any(dm => dm.MaDM == maDM))
            {
                MessageBox.Show("Danh mục không tồn tại."); return;
            }

            // 1) Tạo/cập nhật SẢN PHẨM CHA trước, rồi SAVE để chắc chắn tồn tại
            var sp = db.SanPhams.SingleOrDefault(x => x.MaSP == maSP);
            if (sp == null)
            {
                sp = new SanPham
                {
                    MaSP = maSP,
                    TenSP = tenSP,
                    GiaBan = 0,
                    SoLuong = 0,
                    MoTa = moTa,
                    MaDM = maDM,
                    HinhAnh = hinhAnh
                };
                db.SanPhams.Add(sp);
            }
            else
            {
                sp.TenSP = tenSP;
                sp.MoTa = moTa;
                sp.MaDM = maDM;
                sp.HinhAnh = hinhAnh;
            }

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tạo/cập nhật sản phẩm gốc. Chi tiết: " + ex.Message);
                return;
            }

            // 2) Chặn trùng biến thể
            bool existed = db.ChiTietSanPhams.Any(ct =>
                ct.MaSP == maSP &&
                ct.KichThuoc.ToLower() == kichThuoc.ToLower() &&
                ct.MauSac.ToLower() == mauSac.ToLower());
            if (existed) { MessageBox.Show("San Pham nay da co size nay roi`."); return; }

            // 3) Thêm SPCT (CON) rồi SAVE
            string maSPCT = "CT" + Guid.NewGuid().ToString("N").Substring(0, 8);
            var ct = new ChiTietSanPham
            {
                MaSPCT = maSPCT,
                MaSP = maSP,      // FK tới sp vừa chắc chắn có
                KichThuoc = kichThuoc,
                MauSac = mauSac,
                SoLuongTon = soLuong,
                GiaBan = giaBan,
                HinhAnh = hinhAnh    // nếu ChiTietSanPhams.HinhAnh NOT NULL
            };
            db.ChiTietSanPhams.Add(ct);

            try
            {
                db.SaveChanges(); // 🔴 COMMIT SPCT SAU
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm: " + ex.Message);
                return;
            }

            // 4) Reload FULL (không lọc danh mục như bạn yêu cầu)
            LoadSanPham();
            dgvSanPham.ClearSelection();
            MessageBox.Show("Thêm  thành công!");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtMaSP.Text) || string.IsNullOrEmpty(_selectedMaSPCT))
            {
                MessageBox.Show("Vui lòng chọn SP.");
                return;
            }

            if (!decimal.TryParse(txtGiaBan.Text, out var giaBan) || !int.TryParse(txtSoLuong.Text, out var soLuong))
            {
                MessageBox.Show("Giá bán hoặc số lượng không hợp lệ.");
                return;
            }

            var maSP = txtMaSP.Text.Trim();
            var sp = db.SanPhams.FirstOrDefault(x => x.MaSP == maSP);
            if (sp == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm.");
                return;
            }

            sp.TenSP = txtTenSP.Text.Trim();
            sp.MoTa = txtMoTa.Text.Trim();
            sp.MaDM = cbDanhMuc.SelectedValue?.ToString();


            var ct = db.ChiTietSanPhams.FirstOrDefault(c => c.MaSPCT == _selectedMaSPCT);
            if (ct != null)
            {
                ct.GiaBan = giaBan;
                ct.SoLuongTon = soLuong;
                if (picHinhAnh.Tag != null) ct.HinhAnh = picHinhAnh.Tag.ToString();

            }

            db.SaveChanges();
            LoadSanPham();
            MessageBox.Show("Cập nhật thành công!");

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (!_userClickedRow || string.IsNullOrEmpty(_selectedMaSPCT))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước khi xóa.");
                return;
            }

            var ct = db.ChiTietSanPhams.FirstOrDefault(c => c.MaSPCT == _selectedMaSPCT);
            if (ct == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm cần xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            db.ChiTietSanPhams.Remove(ct);
            db.SaveChanges();

            _selectedMaSPCT = null;
            _userClickedRow = false; // reset cờ
            LoadSanPham();

            MessageBox.Show("Đã xóa sản phẩm!");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenSP.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            txtMoTa.Clear();
            txtKichThuoc.Clear();
            txtMauSac.Clear();
            cbDanhMuc.SelectedIndex = -1;
            if (picHinhAnh.Image != null) { picHinhAnh.Image.Dispose(); picHinhAnh.Image = null; }
            picHinhAnh.Tag = null;

            // rồi mới sinh mã mới và gán
            txtMaSP.Text = GenerateNextMaSP_FillGaps_FromSPCT();

            // refresh bảng & bỏ chọn
            LoadSanPham();
            dgvSanPham.ClearSelection();
            _selectedMaSPCT = null;
            _userClickedRow = false;
        }


        private bool isSelectingFromGrid = false;
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)

        {
            if (e.RowIndex < 0) return;
            _userClickedRow = true;                 // ✅ đánh dấu đã click thật

            var row = dgvSanPham.Rows[e.RowIndex];

            _selectedMaSPCT = GetCellValue(row, "MaSPCT");
            txtMaSP.Text = GetCellValue(row, "MaSP");
            txtTenSP.Text = GetCellValue(row, "TenSP");
            txtGiaBan.Text = GetCellValue(row, "GiaBan");
            txtSoLuong.Text = GetCellValue(row, "SoLuongTon");
            txtMoTa.Text = GetCellValue(row, "MoTa");
            txtKichThuoc.Text = GetCellValue(row, "KichThuoc") ?? "";
            txtMauSac.Text = GetCellValue(row, "MauSac") ?? "";

            // Gán danh mục nhưng KHÔNG trigger lọc
            isSelectingFromGrid = true;
            var maDM = GetCellValue(row, "MaDM") ?? "";
            if (!string.IsNullOrEmpty(maDM) && cbDanhMuc.Items.Count > 0)
                cbDanhMuc.SelectedValue = maDM;
            else
                cbDanhMuc.SelectedIndex = -1;
            isSelectingFromGrid = false;

            // Ảnh
            var hinhAnh = GetCellValue(row, "HinhAnh");
            try
            {
                if (!string.IsNullOrEmpty(hinhAnh) && System.IO.File.Exists(hinhAnh))
                {
                    if (picHinhAnh.Image != null) { picHinhAnh.Image.Dispose(); picHinhAnh.Image = null; }
                    using (var fs = new System.IO.FileStream(hinhAnh, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        picHinhAnh.Image = new Bitmap(fs);
                    }
                    picHinhAnh.Tag = hinhAnh;
                }
                else
                {
                    picHinhAnh.Image = null;
                    picHinhAnh.Tag = null;
                }
            }
            catch
            {
                // nếu file bị khoá hoặc lỗi path
                picHinhAnh.Image = null;
                picHinhAnh.Tag = null;
            }
        }



        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isSelectingFromGrid) return; // Nếu đang thao tác từ DataGridView thì bỏ qua, không lọc

            if (cbDanhMuc.SelectedIndex == -1 || cbDanhMuc.SelectedValue == null)
            {
                LoadSanPham(); // Hiển thị tất cả sản phẩm
            }
            else
            {
                LoadSanPham(cbDanhMuc.SelectedValue.ToString()); // Lọc theo mã danh mục
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // hiển thị ảnh
                    if (picHinhAnh.Image != null) { picHinhAnh.Image.Dispose(); picHinhAnh.Image = null; }
                    picHinhAnh.Image = Image.FromFile(ofd.FileName);
                    picHinhAnh.Tag = ofd.FileName;
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string kw = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(kw)) { LoadSanPham(); return; }

            var q = db.ChiTietSanPhams
                .Join(db.SanPhams, ct => ct.MaSP, sp => sp.MaSP, (ct, sp) => new { ct, sp })
                .Join(db.DanhMucs, t => t.sp.MaDM, dm => dm.MaDM, (t, dm) => new
                {
                    t.ct.MaSPCT,
                    t.sp.MaSP,
                    t.sp.TenSP,
                    GiaBan = t.ct.GiaBan,
                    SoLuongTon = t.ct.SoLuongTon,
                    t.sp.MoTa,
                    t.sp.MaDM,
                    TenDM = dm.TenDM,
                    HinhAnh = t.ct.HinhAnh,
                    t.ct.KichThuoc,
                    t.ct.MauSac
                })
                .Where(x =>
                    x.MaSP.ToLower().Contains(kw) ||
                    x.TenSP.ToLower().Contains(kw) ||
                    (x.MoTa ?? "").ToLower().Contains(kw) ||
                    (x.KichThuoc ?? "").ToLower().Contains(kw) ||
                    (x.MauSac ?? "").ToLower().Contains(kw)
                );

            dgvSanPham.DataSource = q.ToList();
            SetupSanPhamGrid();
            dgvSanPham.ClearSelection();
            _selectedMaSPCT = null;
            _userClickedRow = false;
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem.PerformClick();
            }
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {

        }

        private void SetupSanPhamGrid()
        {
            var g = dgvSanPham;
            if (g == null || g.Columns.Count == 0) return;

            // helpers
            void Hide(string c) { if (g.Columns.Contains(c)) g.Columns[c].Visible = false; }
            void Head(string c, string t) { if (g.Columns.Contains(c)) g.Columns[c].HeaderText = t; }
            void Align(string c, DataGridViewContentAlignment a) { if (g.Columns.Contains(c)) g.Columns[c].DefaultCellStyle.Alignment = a; }
            void Format(string c, string f) { if (g.Columns.Contains(c)) g.Columns[c].DefaultCellStyle.Format = f; }
            void Order(ref int i, string c) { if (g.Columns.Contains(c)) g.Columns[c].DisplayIndex = i++; }

            // header text
            Head("MaSP", "Mã SP");
            Head("TenSP", "Tên SP");
            Head("GiaBan", "Giá bán");
            Head("SoLuongTon", "Tồn");
            Head("KichThuoc", "Size");
            Head("MauSac", "Màu");
            Head("TenDM", "Danh mục");
            Head("MoTa", "Mô tả");

            // format số: KHÔNG có .00
            Format("GiaBan", "N0");        // 1000 -> 1,000
            Align("GiaBan", DataGridViewContentAlignment.MiddleRight);

            Format("SoLuongTon", "N0");
            Align("SoLuongTon", DataGridViewContentAlignment.MiddleCenter);

            Align("KichThuoc", DataGridViewContentAlignment.MiddleCenter);

            // Ẩn các cột kỹ thuật
            Hide("HinhAnh");   // <-- Ẩn cột đường dẫn ảnh
            Hide("MaSPCT");
            Hide("MaDM");

            // thứ tự cột
            int idx = 0;
            Order(ref idx, "MaSP");
            Order(ref idx, "TenSP");
            Order(ref idx, "GiaBan");
            Order(ref idx, "SoLuongTon");
            Order(ref idx, "KichThuoc");
            Order(ref idx, "MauSac");
            Order(ref idx, "TenDM");
            Order(ref idx, "MoTa");

            // hiển thị đẹp
            g.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            if (g.Columns.Contains("MoTa"))
                g.Columns["MoTa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}

