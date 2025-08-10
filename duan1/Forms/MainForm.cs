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
    public partial class MainForm : Form
    {
        private NhanVien _nguoiDung;
        public MainForm(NhanVien nv)
        {
            InitializeComponent();
            _nguoiDung = nv;
            PhanQuyen();
        }

        Form curenForm = new Form();
        void ChangForm(Form form)
        {
            curenForm.Controls.Clear();
            curenForm = form;
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panel1.Controls.Add(curenForm);
            form.BringToFront();
            form.Show();

        }

        //Quản lý nhân viên
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            ChangForm(new FormSanPham());
        }



        //Quản lý nhân viên
        private void btnQuanLyNV_Click(object sender, EventArgs e)
        {
            ChangForm(new FormQLNhanVien());
        }

        private void PhanQuyen()
        {
            lblChaoMung.Text = $"Xin chào: {_nguoiDung.HoTen} ({_nguoiDung.VaiTro})";

            if (_nguoiDung.VaiTro == "QL") // Quản lý
            {
                btnNhanVien.Enabled = true;
                btnThongKe.Enabled = true;
                btnVoucher.Enabled = true;
            }
            else // Nhân viên
            {
                btnNhanVien.Enabled = false;
                btnThongKe.Enabled = false;
                btnVoucher.Enabled = false;
            }
        }

        //Quản lý Voucher
        private void btnQLVoucher_Click(object sender, EventArgs e)
        {
            ChangForm(new FormQLVoucher());
        }
        private void btn_qlyNhanVien_Click(object sender, EventArgs e)
        {
            ChangForm(new FormQLNhanVien());
        }

        private void btn_qlyVoucher_Click(object sender, EventArgs e)
        {
            ChangForm(new FormQLVoucher());
        }

        private void btn_hoaDon_Click(object sender, EventArgs e)
        {
            ChangForm(new FormHoaDon());
        }
    }
}
