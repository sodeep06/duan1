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
    public partial class FormChiTietDonHang : Form
    {
        DonHangChiTietRepo _repo = new DonHangChiTietRepo();
        public FormChiTietDonHang(string maDonHang)
        {
            InitializeComponent();
            _maDonHang = maDonHang;
        }
        private string _maDonHang;
        private void LoadChiTietDonHang()
        {
            var items = _repo.GetByDonHangId(_maDonHang);
            dtg_chiTietDonHang.DataSource = items;

            dtg_chiTietDonHang.Columns["MaDHCT"].HeaderText = "Mã CTHĐ";
            dtg_chiTietDonHang.Columns["MaDH"].HeaderText = "Mã HĐ";
            dtg_chiTietDonHang.Columns["MaSPCT"].HeaderText = "Mã SPCT";
            dtg_chiTietDonHang.Columns["TenSP"].HeaderText = "Tên Sản Phẩm";
            dtg_chiTietDonHang.Columns["KichThuoc"].HeaderText = "Kích Thước";
            dtg_chiTietDonHang.Columns["MauSac"].HeaderText = "Màu Sắc";
            dtg_chiTietDonHang.Columns["SoLuong"].HeaderText = "Số Lượng";
            dtg_chiTietDonHang.Columns["DonGia"].HeaderText = "Đơn Giá";
        }

        private void FormChiTietDonHang_Load(object sender, EventArgs e)
        {
            LoadChiTietDonHang();
        }
    }
}
