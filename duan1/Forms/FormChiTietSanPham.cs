using duan1.Models;
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
    public partial class FormChiTietSanPham : Form
    {
        ChiTietSanPhamRepo _repo = new ChiTietSanPhamRepo();
        public FormChiTietSanPham(string maSP)
        {
            InitializeComponent();
            _maSP = maSP;
        }
        private string _maSP;
        public string SelectedMaSPCT { get; private set; }

        private void FormChiTietSanPham_Load(object sender, EventArgs e)
        {
            var data = _repo.GetByMaSP(_maSP);
            dtg_chiTietSanPham.DataSource = data;
            dtg_chiTietSanPham.Columns["MaSPCT"].HeaderText = "Mã Chi Tiết Sản Phẩm";
            dtg_chiTietSanPham.Columns["MaSP"].HeaderText = "Mã Sản Phẩm";
            dtg_chiTietSanPham.Columns["SoLuongTon"].HeaderText = "Số Lượng tồn";
            dtg_chiTietSanPham.Columns["GiaBan"].HeaderText = "Giá Bán";
            dtg_chiTietSanPham.Columns["HinhAnh"].HeaderText = "Hình Ảnh";
            dtg_chiTietSanPham.Columns["KichThuoc"].HeaderText = "Kích Thước";
            dtg_chiTietSanPham.Columns["MauSac"].HeaderText = "Màu Sắc";
            dtg_chiTietSanPham.Columns["SanPham"].Visible = false; 
        }

        private void dtg_chiTietSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedMaSPCT = dtg_chiTietSanPham.Rows[e.RowIndex].Cells["MaSPCT"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


    }
}
