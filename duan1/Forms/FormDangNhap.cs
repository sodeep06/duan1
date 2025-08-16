using System.Windows.Forms;
using System.Linq;
using duan1.DTO;
using duan1.Models;

namespace duan1.Forms
{
    public partial class FormDangNhap : Form
    {
        ShopDbContext db = new ShopDbContext();

        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void ClearInputFields()
        {
            txtEmail.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
        }

        // Gọi từ cả 2 sự kiện
        private void DoLogin(bool openModally)
        {
            string email = txtEmail.Text.Trim();
            string matkhau = txtMatKhau.Text.Trim();

            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(matkhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Email và Mật khẩu.",
                                "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nv = db.NhanViens.FirstOrDefault(x => x.Email == email);

            // Sai email hoặc mật khẩu
            if (nv == null || nv.MatKhau != matkhau)
            {
                MessageBox.Show("Email hoặc mật khẩu không đúng.",
                                "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                txtMatKhau.SelectAll();
                return;
            }

            // Thành công
            MessageBox.Show($"Xin chào {nv.HoTen}!\nĐăng nhập thành công.",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Lưu phiên
            PhienDangNhap.MaNV = nv.MaNV;
            PhienDangNhap.HoTen = nv.HoTen;
            PhienDangNhap.Email = nv.Email;
            PhienDangNhap.VaiTro = nv.VaiTro;

            // Mở form theo vai trò
            this.Hide();
            if (nv.VaiTro == "QL")
            {
                var f = new MainForm(nv);
                if (openModally) { f.ShowDialog(); this.Close(); }
                else { f.FormClosed += (s, args) => this.Show(); f.Show(); }
            }
            else
            {
                var f = new FormBanHang();
                if (openModally) { f.ShowDialog(); this.Close(); }
                else { f.FormClosed += (s, args) => this.Show(); f.Show(); }
            }

            ClearInputFields();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DoLogin(openModally: false); // mở không modal, quay lại màn login khi form kia đóng
        }

        private void lab_login_Click(object sender, EventArgs e)
        {
            DoLogin(openModally: true);  // mở modal và đóng luôn màn login sau khi xong
        }
    }
}
