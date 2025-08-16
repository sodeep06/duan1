using duan1.Models;
using duan1.Repositories;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace duan1.Forms
{
    public partial class FormQLVoucher : Form
    {
        private readonly VoucherRepo _repo = new VoucherRepo();

        public FormQLVoucher()
        {
            InitializeComponent();

            // Grid chiếm toàn bộ vùng chứa
            dgvVoucher.Dock = DockStyle.Fill;

            // Cột responsive (theo tỉ trọng) + format
            ConfigureVoucherColumns();

            // Nạp dữ liệu
            LoadData();

            // Sự kiện
            dgvVoucher.SelectionChanged += dgvVoucher_SelectionChanged;
            dgvVoucher.DataBindingComplete += (_, __) => SetupVoucherGrid();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ApplyTheme();
            SetupVoucherGrid();
        }

        // ================== THEME ==================
        private void ApplyTheme()
        {
            var bg = ColorTranslator.FromHtml("#F6F7FB");
            var text = ColorTranslator.FromHtml("#2B2F33");
            var primary = ColorTranslator.FromHtml("#5B8DEF");
            var danger = ColorTranslator.FromHtml("#F06548");

            BackColor = bg;
            Font = new Font("Segoe UI", 9.5f);
            ForeColor = text;

            if (lblTitle != null)
            {
                lblTitle.Text = "Voucher";
                lblTitle.ForeColor = primary;
                lblTitle.Font = new Font("Segoe UI Semibold", 22f, FontStyle.Bold);
                lblTitle.AutoSize = true;
            }

            StyleButtonOwnerDraw(btnThem, primary, null, 12);
            StyleButtonOwnerDraw(btnSua, primary, null, 12);
            StyleButtonOwnerDraw(btnXoa, danger, null, 12);

            StyleTextBox(txtMaVoucher);
            StyleTextBox(txtTenVoucher);
            StyleTextBox(txtGiaTri);

            StyleDatePicker(dtpNgayBatDau);
            StyleDatePicker(dtpNgayKetThuc);

            StyleGrid(dgvVoucher);
        }

        // ================== GRID CONFIG (RESPONSIVE) ==================
        private void ConfigureVoucherColumns()
        {
            dgvVoucher.AutoGenerateColumns = false;
            dgvVoucher.Columns.Clear();

            // Dùng Fill + MinimumWidth để không bị "cụt" khi co giãn
            dgvVoucher.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVoucher.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvVoucher.ColumnHeadersHeight = 30;

            // Mã
            var colMa = new DataGridViewTextBoxColumn
            {
                Name = "MaVoucher",
                HeaderText = "Mã Voucher",
                DataPropertyName = "MaVoucher",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 120,
                MinimumWidth = 120
            };

            // Giá trị %
            var colGiaTri = new DataGridViewTextBoxColumn
            {
                Name = "GiaTri",
                HeaderText = "Giá trị (%)",
                DataPropertyName = "GiaTri",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 90,
                MinimumWidth = 90
            };
            colGiaTri.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colGiaTri.DefaultCellStyle.Format = "0'%'";

            // Ngày bắt đầu
            var colNBD = new DataGridViewTextBoxColumn
            {
                Name = "NgayBatDau",
                HeaderText = "Ngày bắt đầu",
                DataPropertyName = "NgayBatDau",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 120,
                MinimumWidth = 140
            };
            colNBD.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colNBD.DefaultCellStyle.Format = "dd/MM/yyyy";

            // Ngày kết thúc
            var colNKT = new DataGridViewTextBoxColumn
            {
                Name = "NgayKetThuc",
                HeaderText = "Ngày kết thúc",
                DataPropertyName = "NgayKetThuc",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 120,
                MinimumWidth = 140
            };
            colNKT.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colNKT.DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvVoucher.Columns.AddRange(colMa, colGiaTri, colNBD, colNKT);
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
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#111827");
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F9FAFB");
            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#DBEAFE");
            dgv.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#111827");

            dgv.RowHeadersVisible = false;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            // Khoá reorder/resize để layout ổn định
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = false;

            // Double-buffer cho mượt
            var pi = typeof(DataGridView).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi?.SetValue(dgv, true, null);
        }

        private void SetupVoucherGrid()
        {
            if (dgvVoucher == null) return;
            dgvVoucher.ClearSelection();
        }

        // ================== UI HELPERS ==================
        private void StyleTextBox(TextBox tb)
        {
            if (tb == null) return;
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.BackColor = Color.White;
            tb.Margin = new Padding(0, 2, 0, 8);
            tb.ForeColor = ColorTranslator.FromHtml("#111827");
            tb.Font = new Font("Segoe UI", 9.5f);
        }

        private void StyleDatePicker(DateTimePicker dtp)
        {
            if (dtp == null) return;
            dtp.CalendarForeColor = ColorTranslator.FromHtml("#111827");
            dtp.CalendarMonthBackground = Color.White;
            dtp.Font = new Font("Segoe UI", 9.5f);
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "dd/MM/yyyy";
            dtp.MinDate = new DateTime(2000, 1, 1);
        }

        // ==== Owner-draw button ====
        private void StyleButtonOwnerDraw(Button btn, Color bg, Color? fg = null, int radius = 10)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.UseVisualStyleBackColor = false;

            btn.BackColor = bg;
            btn.ForeColor = fg ?? Color.White;
            btn.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Padding = new Padding(12, 6, 12, 6);

            btn.Paint -= ButtonOwnerDraw_Paint;
            btn.Resize -= ButtonOwnerDraw_Resize;

            btn.Tag = radius;
            btn.Paint += ButtonOwnerDraw_Paint;
            btn.Resize += ButtonOwnerDraw_Resize;

            ButtonOwnerDraw_Resize(btn, EventArgs.Empty);
        }

        private void ButtonOwnerDraw_Resize(object? sender, EventArgs e)
        {
            if (sender is not Button btn) return;

            int r = btn.Tag is int rad ? Math.Min(rad, Math.Min(btn.Width, btn.Height) / 2) : 8;

            using (var path = new GraphicsPath())
            {
                int d = r * 2;
                var rect = btn.ClientRectangle;
                var arc = new Rectangle(rect.Location, new Size(d, d));
                path.AddArc(arc, 180, 90);
                arc.X = rect.Right - d; path.AddArc(arc, 270, 90);
                arc.Y = rect.Bottom - d; path.AddArc(arc, 0, 90);
                arc.X = rect.Left; path.AddArc(arc, 90, 90);
                path.CloseFigure();

                btn.Region?.Dispose();
                btn.Region = new Region(path);
            }
        }

        private void ButtonOwnerDraw_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Button btn) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var b = new SolidBrush(btn.BackColor))
                e.Graphics.FillRectangle(b, btn.ClientRectangle);

            TextRenderer.DrawText(
                e.Graphics, btn.Text ?? "", btn.Font, btn.ClientRectangle, btn.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        // ================== DATA ==================
        private void LoadData()
        {
            dgvVoucher.DataSource = _repo.GetAll(); // tất cả voucher
            SetupVoucherGrid();
        }

        private void ClearFields()
        {
            txtMaVoucher.Clear();
            txtTenVoucher.Clear();
            txtGiaTri.Clear();
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
        }

        private void dgvVoucher_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVoucher.CurrentRow == null || dgvVoucher.CurrentRow.Index < 0) return;

            if (dgvVoucher.CurrentRow.DataBoundItem is Voucher v)
            {
                txtMaVoucher.Text = v.MaVoucher ?? "";
                txtTenVoucher.Text = string.IsNullOrWhiteSpace(v.TenVoucher) ? $"{v.GiaTri:0}%" : v.TenVoucher;
                txtGiaTri.Text = v.GiaTri.ToString("0");
                dtpNgayBatDau.Value = v.NgayBatDau == default ? DateTime.Now : v.NgayBatDau;
                dtpNgayKetThuc.Value = v.NgayKetThuc == default ? DateTime.Now : v.NgayKetThuc;
            }
        }

        private bool ValidateInput(out decimal giaTri)
        {
            giaTri = 0;

            if (string.IsNullOrWhiteSpace(txtMaVoucher.Text) ||
                string.IsNullOrWhiteSpace(txtTenVoucher.Text) ||
                string.IsNullOrWhiteSpace(txtGiaTri.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtGiaTri.Text.Trim(), out giaTri))
            {
                MessageBox.Show("Giá trị giảm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (giaTri <= 0)
            {
                MessageBox.Show("Giá trị giảm phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DateTime ngayBatDau = dtpNgayBatDau.Value.Date;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value.Date;

            if (ngayKetThuc < ngayBatDau)
            {
                MessageBox.Show("Ngày kết thúc không được trước ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out decimal giaTri)) return;

            using (var context = new ShopDbContext())
            {
                string ma = txtMaVoucher.Text.Trim();

                if (context.Vouchers.Any(v => v.MaVoucher == ma))
                {
                    MessageBox.Show("Mã voucher đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var v = new Voucher
                {
                    MaVoucher = ma,
                    TenVoucher = txtTenVoucher.Text.Trim(),
                    GiaTri = giaTri,
                    NgayBatDau = dtpNgayBatDau.Value,
                    NgayKetThuc = dtpNgayKetThuc.Value
                };

                context.Vouchers.Add(v);
                context.SaveChanges();
            }

            LoadData();
            ClearFields();
            MessageBox.Show("Thêm voucher thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out decimal giaTri)) return;

            using (var context = new ShopDbContext())
            {
                string ma = txtMaVoucher.Text.Trim();
                var v = context.Vouchers.FirstOrDefault(x => x.MaVoucher == ma);

                if (v == null)
                {
                    MessageBox.Show("Không tìm thấy voucher để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                v.TenVoucher = txtTenVoucher.Text.Trim();
                v.GiaTri = giaTri;
                v.NgayBatDau = dtpNgayBatDau.Value;
                v.NgayKetThuc = dtpNgayKetThuc.Value;

                context.SaveChanges();
            }

            LoadData();
            ClearFields();
            MessageBox.Show("Cập nhật voucher thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaVoucher.Text.Trim();

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa voucher này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using (var context = new ShopDbContext())
            {
                var v = context.Vouchers.FirstOrDefault(x => x.MaVoucher == ma);
                if (v == null)
                {
                    MessageBox.Show("Không tìm thấy voucher để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                context.Vouchers.Remove(v);
                context.SaveChanges();
            }

            LoadData();
            ClearFields();
            MessageBox.Show("Xóa voucher thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
