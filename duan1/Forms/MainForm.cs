using duan1.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace duan1.Forms
{
    public partial class MainForm : Form
    {
        private readonly NhanVien _nguoiDung;
        private Form _current;

        public MainForm(NhanVien nv)
        {
            InitializeComponent();
            _nguoiDung = nv;

            // Hiển thị chào mừng nếu có label
            if (lblChaoMung != null && _nguoiDung != null)
                lblChaoMung.Text = $"Xin chào: {_nguoiDung.HoTen} ({_nguoiDung.VaiTro})";

            // Nền nhẹ nhàng
            BackColor = Color.WhiteSmoke;
            if (panel1 != null) panel1.BackColor = Color.White;

            // Căn lại panel1 để KHÔNG đè lên các nút
            LayoutContent();
            Load += (s, e) => LayoutContent();
            ClientSizeChanged += (s, e) => LayoutContent();
        }

        /// <summary>
        /// Đặt panel1 chiếm toàn bộ vùng còn lại, trừ vùng các Button top-level.
        /// (Bạn chỉ có 1 panel1 hiển thị form con; các nút nằm trực tiếp trên form)
        /// </summary>
        private void LayoutContent()
        {
            if (panel1 == null) return;

            // Tìm mép phải lớn nhất của tất cả Button ở cấp Form (không phải trong panel khác)
            int reserveLeft = 0;
            foreach (var b in this.Controls.OfType<Button>())
            {
                if (b.Parent == this && b.Visible)
                    reserveLeft = Math.Max(reserveLeft, b.Right + 12); // chừa 12px
            }

            // Đặt panel1 né vùng nút bên trái
            panel1.Dock = DockStyle.None; // QUAN TRỌNG: không được Dock Fill nữa
            panel1.Location = new Point(reserveLeft, 0);
            panel1.Size = new Size(Math.Max(0, ClientSize.Width - reserveLeft), ClientSize.Height);
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // đảm bảo panel1 không đè nút
            panel1.SendToBack();
        }

        /// <summary>Mở form con vào panel1.</summary>
        private void OpenChild(Form child)
        {
            if (panel1 == null)
            {
                MessageBox.Show("Không tìm thấy panel1. Hãy đặt đúng tên panel nội dung là 'panel1' trong Designer.");
                return;
            }

            if (_current != null)
            {
                _current.Close();
                _current.Dispose();
            }

            _current = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;

            panel1.SuspendLayout();
            panel1.Controls.Clear();
            panel1.Controls.Add(child);
            child.BringToFront();
            panel1.ResumeLayout();

            child.Show();
        }

        // ===== Gán các nút mở form con =====
        private void btnSanPham_Click(object sender, EventArgs e)
            => OpenChild(new FormSanPham());

        private void btn_BanHang_Click(object sender, EventArgs e)
            => OpenChild(new FormBanHang());

        private void btn_qlyNhanVien_Click(object sender, EventArgs e)
            => OpenChild(new FormQLNhanVien());

        private void btn_qlyVoucher_Click(object sender, EventArgs e)
            => OpenChild(new FormQLVoucher());

        private void btn_hoaDon_Click(object sender, EventArgs e)
            => OpenChild(new FormHoaDon());

        private void btnThongKe_Click(object sender, EventArgs e)
            => OpenChild(new FormDoanhThu());
    }
}
