using duan1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace duan1.Forms
{
    public partial class FormDangNhap : Form
    {
        ShopDbContext db = new ShopDbContext();
        public FormDangNhap()
        {
            InitializeComponent();
            txtMatKhau.UseSystemPasswordChar = true; // <--- Dòng này
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string matkhau = txtMatKhau.Text.Trim();

            var nv = db.NhanViens.FirstOrDefault(x => x.Email == email && x.MatKhau == matkhau);
            if (nv != null)
            {
                // Đăng nhập thành công, mở MainForm và truyền thông tin
                this.Hide();
                var mainForm = new MainForm(nv);
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
