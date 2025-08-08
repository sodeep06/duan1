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
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string matkhau = txtMatKhau.Text.Trim();

            var nv = db.NhanViens.FirstOrDefault(x => x.Email == email && x.MatKhau == matkhau);
            if (nv != null)
            {
                lab_thongBao.Text = "Dang nhap thanh cong...";
                lab_thongBao.ForeColor = Color.Green;
                if(nv.VaiTro == "QL")
                {
                    // vai tro QL -> mo main form
                    this.Hide();
                    var mainForm = new MainForm(nv);
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    // vai tro nhan vien -> mo ban hang
                    this.Hide();
                    var banHangForm = new FormBanHang();
                    banHangForm.ShowDialog();
                    this.Close();
                }
                
            }
            else
            {
                
                lab_thongBao.Text = "Tai khoan hoac mat khau sai!";
                lab_thongBao.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
