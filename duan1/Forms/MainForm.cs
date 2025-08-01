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

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            var frm = new FormSanPham();
            frm.ShowDialog();
        }


        private void PhanQuyen()
        {
            lblChaoMung.Text = $"Xin chào: {_nguoiDung.HoTen} ({_nguoiDung.VaiTro})";

            if (_nguoiDung.VaiTro == "QL") // Quản lý
            {
                btnNhanVien.Enabled = true;
                btnThongKe.Enabled = true;
            }
            else // Nhân viên
            {
                btnNhanVien.Enabled = false;
                btnThongKe.Enabled = false;
            }
        }
    }
}
