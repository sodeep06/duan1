using duan1.Repositories;
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
    public partial class FormBanHang : Form
    {
        SanPhamRepo sprepo = new SanPhamRepo();
        KhachHangRepo khrepo = new KhachHangRepo();

        public FormBanHang()
        {
            InitializeComponent();
        }

        private void LoadSanPham()
        {
            dtg_sanPham.DataSource = sprepo.GetAll();
            dtg_sanPham.Columns["MaSP"].Visible = false;
            dtg_sanPham.Columns["MaDM"].Visible = false;
            dtg_sanPham.Columns["HinhAnh"].Visible = false;
            dtg_sanPham.Columns["DanhMuc"].Visible = false;
            dtg_sanPham.Columns["ChiTietSanPhams"].Visible = false;
        }
        private void LoadKhachHang()
        {
            dtg_khachHang.DataSource = khrepo.GetAll();
            dtg_khachHang.Columns["DonHangs"].Visible = false;
            dtg_khachHang.Columns["MaKH"].Visible = false;
        }

        private void LoadData()
        {
            LoadSanPham();
            LoadKhachHang();
        }

        private void FormBanHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
