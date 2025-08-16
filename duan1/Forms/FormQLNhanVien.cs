using duan1.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace duan1.Forms
{
    public partial class FormQLNhanVien : Form
    {
        private List<NhanVien> danhSachNhanVien = new List<NhanVien>();

        public FormQLNhanVien()
        {
            InitializeComponent();

            LoadData();
            dgvNhanVien.SelectionChanged += dgvNhanVien_SelectionChanged;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            // ErrorProvider
            _err.ContainerControl = this;
            _err.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // Gõ tới đâu xóa lỗi tới đó + bật/tắt nút Thêm
            txtHoTen.TextChanged += ClearErrorOnChange;
            txtEmail.TextChanged += ClearErrorOnChange;
            txtMatKhau.TextChanged += ClearErrorOnChange;
        }

        private void ClearErrorOnChange(object sender, EventArgs e)
        {
            if (sender is Control c) _err.SetError(c, "");
 
        }

        private void UpdateAddButtonEnabled()
        {
            btnThem.Enabled = true;
        }
        private bool ValidateRequired(out Control firstInvalid)
        {
            firstInvalid = null;

            // xóa lỗi cũ
            _err.SetError(txtHoTen, "");
            _err.SetError(txtEmail, "");
            _err.SetError(txtMatKhau, "");

            bool ok = true;

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                _err.SetError(txtHoTen, "Bắt buộc");
                if (firstInvalid == null) firstInvalid = txtHoTen;
                ok = false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                _err.SetError(txtEmail, "Bắt buộc");
                if (firstInvalid == null) firstInvalid = txtEmail;
                ok = false;
            }
            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                _err.SetError(txtMatKhau, "Bắt buộc");
                if (firstInvalid == null) firstInvalid = txtMatKhau;
                ok = false;
            }

            return ok;
        }
        private readonly ErrorProvider _err = new ErrorProvider();
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ApplyTheme();
            SetupNhanVienGrid();
            ClearFields();
            btnThem.Enabled = true;
        }

        // ====== THEME / STYLE ======
        private void ApplyTheme()
        {
            // Palette
            var bg = ColorTranslator.FromHtml("#F6F7FB");
            var text = ColorTranslator.FromHtml("#2B2F33");
            var primary = ColorTranslator.FromHtml("#5B8DEF");
            var danger = ColorTranslator.FromHtml("#F06548");

            // Form
            this.BackColor = bg;
            this.Font = new Font("Segoe UI", 9.5f);
            this.ForeColor = text;

            // ⭐ Style NÚT (gọi owner-draw ở đây)
            StyleButtonOwnerDraw(btnThem, primary, null, 12);
            StyleButtonOwnerDraw(btnSua, primary, null, 12);
            StyleButtonOwnerDraw(btnXoa, danger, null, 12);

            // TextBox
            StyleTextBox(txtMaNhanVien);
            StyleTextBox(txtHoTen);
            StyleTextBox(txtEmail);
            StyleTextBox(txtMatKhau, isPassword: true);
            StyleTextBox(txtTimKiem);

            // Grid
            StyleGrid(dgvNhanVien);
            SetupNhanVienGrid();
        }

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

            // Bỏ mọi Region cũ (nếu có) để tránh cắt chữ
            if (btn.Region != null) { btn.Region.Dispose(); btn.Region = null; }

            // Gỡ handler cũ (nếu gọi nhiều lần)
            btn.Paint -= ButtonOwnerDraw_Paint;
            btn.Resize -= ButtonOwnerDraw_Resize;

            // Lưu radius vào Tag để Paint đọc
            btn.Tag = radius;

            btn.Paint += ButtonOwnerDraw_Paint;
            btn.Resize += ButtonOwnerDraw_Resize;

            // Gọi Resize 1 lần để bo góc theo kích thước hiện tại
            ButtonOwnerDraw_Resize(btn, EventArgs.Empty);
        }

        private void ButtonOwnerDraw_Resize(object? sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;
            int r = btn.Tag is int rad ? Math.Min(rad, Math.Min(btn.Width, btn.Height) / 2) : 8;

            // Tạo Region bo góc (chỉ để “mask” nền, không ảnh hưởng text)
            using (var path = RoundedRect(btn.ClientRectangle, r))
            {
                btn.Region?.Dispose();
                btn.Region = new Region(path);
            }
        }

        private void ButtonOwnerDraw_Paint(object? sender, PaintEventArgs e)
        {
            var btn = sender as Button;
            if (btn == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Tô nền (theo BackColor hiện tại)
            using (var b = new SolidBrush(btn.BackColor))
                e.Graphics.FillRectangle(b, btn.ClientRectangle);

            // Vẽ chữ chính giữa – KHÔNG BAO GIỜ “MẤT”
            TextRenderer.DrawText(
                e.Graphics,
                btn.Text ?? "",
                btn.Font,
                btn.ClientRectangle,
                btn.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis
            );
        }

        // Tạo đường cong bo góc cho Region
        private GraphicsPath RoundedRect(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            var arc = new Rectangle(rect.Location, new Size(d, d));

            // TL
            path.AddArc(arc, 180, 90);
            // TR
            arc.X = rect.Right - d;
            path.AddArc(arc, 270, 90);
            // BR
            arc.Y = rect.Bottom - d;
            path.AddArc(arc, 0, 90);
            // BL
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private void StyleTextBox(TextBox tb, bool isPassword = false)
        {
            if (tb == null) return;
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.BackColor = Color.White;
            tb.Margin = new Padding(0, 2, 0, 8);
            tb.PasswordChar = isPassword ? '•' : '\0';
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

            // Double buffer để cuộn mượt hơn
            var pi = typeof(DataGridView).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi?.SetValue(dgv, true, null);
        }

        private void SetupNhanVienGrid()
        {
            if (dgvNhanVien.Columns["MaNV"] != null) dgvNhanVien.Columns["MaNV"].HeaderText = "Mã NV";
            if (dgvNhanVien.Columns["HoTen"] != null) dgvNhanVien.Columns["HoTen"].HeaderText = "Họ tên";
            if (dgvNhanVien.Columns["Email"] != null) dgvNhanVien.Columns["Email"].HeaderText = "Email";
            if (dgvNhanVien.Columns["MatKhau"] != null) dgvNhanVien.Columns["MatKhau"].HeaderText = "Mật khẩu";
            if (dgvNhanVien.Columns["VaiTro"] != null) dgvNhanVien.Columns["VaiTro"].HeaderText = "Vai trò";

        

            dgvNhanVien.ClearSelection();
        }


        private void LoadData()
        {
            using (var context = new ShopDbContext())
            {
                danhSachNhanVien = context.NhanViens.ToList();

                dgvNhanVien.DataSource = danhSachNhanVien
                    .Select(nv => new
                    {
                        nv.MaNV,
                        nv.HoTen,
                        nv.Email,
                        nv.MatKhau,
                        VaiTro = nv.VaiTro
                    })

                    .ToList();
                dgvNhanVien.ClearSelection();
            }
        }

        private void ClearFields()
        {
            txtMaNhanVien.Text = GenerateNextMaNV();  
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtMatKhau.Text = "";
            txtMaNhanVien.ReadOnly = true;             
            dgvNhanVien.ClearSelection();
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null && dgvNhanVien.CurrentRow.Index >= 0)
            {
                txtMaNhanVien.Text = dgvNhanVien.CurrentRow.Cells["MaNV"].Value?.ToString();
                txtHoTen.Text = dgvNhanVien.CurrentRow.Cells["HoTen"].Value?.ToString();
                txtEmail.Text = dgvNhanVien.CurrentRow.Cells["Email"].Value?.ToString();
                txtMatKhau.Text = dgvNhanVien.CurrentRow.Cells["MatKhau"].Value?.ToString();
                txtMaNhanVien.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateRequired(out var first))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường bắt buộc.", "Thiếu thông tin",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                first?.Focus();
                return;
            }
            try
            {
                using (var context = new ShopDbContext())
                {
                    var maNV = GenerateNextMaNV();  // ⬅️ luôn sinh mới

                    var nv = new NhanVien
                    {
                        MaNV = maNV,
                        HoTen = txtHoTen.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        MatKhau = txtMatKhau.Text.Trim(),
                        VaiTro = "NV"
                    };

                    context.NhanViens.Add(nv);
                    context.SaveChanges();
                }

                MessageBox.Show("Thêm nhân viên thành công.");
                LoadData();
                ClearFields(); // ⬅️ chuẩn bị NV kế tiếp (NV03, NV04…)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Thêm: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)

        {
            if (!ValidateRequired(out var first))
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường bắt buộc.", "Thiếu thông tin",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                first?.Focus();
                return;
            }
            try
            {
                using (var context = new ShopDbContext())
                {
                    var maNV = txtMaNhanVien.Text.Trim();
                    var nv = context.NhanViens.FirstOrDefault(n => n.MaNV == maNV);

                    if (nv == null)
                    {
                        MessageBox.Show("Không tìm thấy nhân viên để sửa.");
                        return;
                    }

                    nv.HoTen = txtHoTen.Text.Trim();
                    nv.Email = txtEmail.Text.Trim();
                    nv.MatKhau = txtMatKhau.Text.Trim();
                    context.SaveChanges();
                }

                MessageBox.Show("Sửa thông tin nhân viên thành công.");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Sửa: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ShopDbContext())
                {
                    var maNV = (txtMaNhanVien.Text ?? "").Trim();
                    var nv = context.NhanViens.FirstOrDefault(n => n.MaNV == maNV);

                    if (nv == null)
                    {
                        MessageBox.Show("Không tìm thấy nhân viên để xóa.");
                        return;
                    }

                    // ❌ Không cho xóa vai trò QL
                    if (string.Equals(nv.VaiTro?.Trim(), "QL", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Tài khoản có vai trò QL không được phép xóa.");
                        return;
                    }

                    var confirm = MessageBox.Show(
                        $"Bạn có chắc muốn xóa nhân viên {nv.HoTen} ({nv.MaNV})?",
                        "Xác nhận xóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );
                    if (confirm != DialogResult.Yes) return;

                    context.NhanViens.Remove(nv);
                    context.SaveChanges();
                }

                MessageBox.Show("Xóa nhân viên thành công.");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Xóa: " + ex.Message);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = (txtTimKiem.Text ?? "").Trim().ToLower();

            var filteredList = danhSachNhanVien
                .Where(nv =>
                    (!string.IsNullOrEmpty(nv.MaNV) && nv.MaNV.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(nv.HoTen) && nv.HoTen.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(nv.Email) && nv.Email.ToLower().Contains(keyword)))
                .Select(nv => new
                {
                    nv.MaNV,
                    nv.HoTen,
                    nv.Email,
                    nv.MatKhau,
                    VaiTro = nv.VaiTro
                })
                .ToList();

            dgvNhanVien.DataSource = filteredList;
            SetupNhanVienGrid();
            dgvNhanVien.ClearSelection();
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private string GenerateNextMaNV()
        {
            using (var context = new ShopDbContext())
            {
                // Lấy tất cả mã hợp lệ dạng NV\d+
                var matches = context.NhanViens
                    .Select(n => n.MaNV)
                    .AsEnumerable() // xử lý regex ở client
                    .Select(id => Regex.Match(id ?? "", @"^NV(\d+)$", RegexOptions.IgnoreCase))
                    .Where(m => m.Success)
                    .ToList();

                int maxNum = matches.Any() ? matches.Max(m => int.Parse(m.Groups[1].Value)) : 0;
                int width = matches.Any() ? matches.Max(m => m.Groups[1].Value.Length) : 2; // giữ số chữ số
                if (width < 2) width = 2;

                int next = maxNum + 1;
                return "NV" + next.ToString(new string('0', width)); // ví dụ "NV02"
            }
        }

    }
}
