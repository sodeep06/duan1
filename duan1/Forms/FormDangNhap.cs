using duan1.DTO;
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
        private void ClearInputFields()
        {
            txtEmail.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
            lab_thongBao.Text = string.Empty;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string matkhau = txtMatKhau.Text.Trim();

            var nv = db.NhanViens.FirstOrDefault(x => x.Email == email);
            if (nv != null && matkhau == nv.MatKhau)
            {
                PhienDangNhap.MaNV = nv.MaNV;
                PhienDangNhap.HoTen = nv.HoTen;
                PhienDangNhap.Email = nv.Email;
                PhienDangNhap.VaiTro = nv.VaiTro;

                lab_thongBao.Text = "Dang nhap thanh cong...";
                lab_thongBao.ForeColor = Color.Green;
                if (nv.VaiTro == "QL")
                {
                    // vai tro QL -> mo main form
                    this.Hide();
                    MainForm f = new MainForm(nv);
                    f.FormClosed += (s, args) => this.Show();
                    f.Show();
                }
                else
                {
                    // vai tro nhan vien -> mo ban hang
                    this.Hide();
                    FormBanHang f = new FormBanHang();
                    f.FormClosed += (s, args) => this.Show();
                    f.Show();
                }
                ClearInputFields();
            }
            else if (nv == null)
            {
                lab_thongBao.Text = "Tai khoan khong ton tai!";
                lab_thongBao.ForeColor = Color.Red;
            }
            else
            {
                var mk = nv.MatKhau;
                lab_thongBao.Text = $"Mat khau phai la: {mk}";
                lab_thongBao.ForeColor = Color.Red;
            }
        }

        private void lab_login_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string matkhau = txtMatKhau.Text.Trim();

            var nv = db.NhanViens.FirstOrDefault(x => x.Email == email);
            if (nv != null && matkhau == nv.MatKhau)
            {
                PhienDangNhap.MaNV = nv.MaNV;
                PhienDangNhap.HoTen = nv.HoTen;
                PhienDangNhap.Email = nv.Email;
                PhienDangNhap.VaiTro = nv.VaiTro;
                lab_thongBao.Text = "Dang nhap thanh cong...";
                lab_thongBao.ForeColor = Color.Green;
                if (nv.VaiTro == "QL")
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
                ClearInputFields();
            }
            else if (nv == null)
            {
                lab_thongBao.Text = "Tai khoan khong ton tai!";
                lab_thongBao.ForeColor = Color.Red;
            }
            else
            {
                var mk = nv.MatKhau;
                lab_thongBao.Text = $"Mat khau phai la: {mk}";
                lab_thongBao.ForeColor = Color.Red;
            }
        }
    }
}
