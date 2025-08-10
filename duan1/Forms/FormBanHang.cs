using duan1.DTO;
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
    public partial class FormBanHang : Form
    {
        SanPhamRepo sprepo = new SanPhamRepo();
        KhachHangRepo khrepo = new KhachHangRepo();
        List<DonHangChiTietDTO> gioHang = new List<DonHangChiTietDTO>();
        List<DonHangChiTiet> GioHang = new List<DonHangChiTiet>();
        DonHangChiTietRepo dhctRepo = new DonHangChiTietRepo();
        DonHangRepo dhRepo = new DonHangRepo();
        VoucherRepo vRepo = new VoucherRepo();
        decimal tongTien = 0;
        bool daApDungVoucher = false;
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


            dtg_sanPham.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dtg_sanPham.Columns["GiaBan"].HeaderText = "Giá bán";
            dtg_sanPham.Columns["SoLuong"].HeaderText = "Còn lại";
            dtg_sanPham.Columns["MoTa"].HeaderText = "Mô tả";
        }
        private void LoadKhachHang()
        {
            dtg_khachHang.DataSource = khrepo.GetAll();
            dtg_khachHang.Columns["DonHangs"].Visible = false;
            dtg_khachHang.Columns["MaKH"].Visible = false;

            dtg_khachHang.Columns["HoTen"].HeaderText = "Họ tên";
            dtg_khachHang.Columns["SDT"].HeaderText = "Số điện thoại";
            dtg_khachHang.Columns["DiaChi"].HeaderText = "Địa chỉ";
        }
        private void LoadNhanVien()
        {
            var ten = PhienDangNhap.HoTen;
            var email = PhienDangNhap.Email;
            lab_tenNhanVien.Text = $"@{ten} ({email})";
        }
        private void LoadGioHang()
        {
            var spList = sprepo.GetAll();
            dtg_gioHang.DataSource = null;
            dtg_gioHang.DataSource = GioHang.Select(x => new
            {
                TenSanPham = spList.FirstOrDefault(sp => sp.MaSP == x.MaSPCT)?.TenSP ?? "Không tìm thấy",
                x.DonGia,
                x.SoLuong,
                ThanhTien = x.DonGia * x.SoLuong,
            }
            ).ToList();
            dtg_gioHang.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dtg_gioHang.Columns["DonGia"].HeaderText = "Đơn giá";
            dtg_gioHang.Columns["SoLuong"].HeaderText = "Số lượng";
            dtg_gioHang.Columns["ThanhTien"].HeaderText = "Thành tiền";
            txt_tongTien.Text = GioHang.Sum(x => (x.DonGia * x.SoLuong)).ToString("N0");

        }
        private void LoadData()
        {
            LoadSanPham();
            LoadKhachHang();
            LoadNhanVien();
            LoadGioHang();
        }

        private void FormBanHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        int soLuongTon = 0;
        private void btn_themGioHang_Click(object sender, EventArgs e)
        {
            //string tenSanPham = lab_tenSanPham.Text;
            //int soLuong = (int)num_soLuong.Value;
            //string tenKhachHang = lab_tenKhachHang.Text;
            //double donGia = double.Parse(lab_donGia.Text);

            //SanPhamTrongGioHangDTO sp = new SanPhamTrongGioHangDTO
            //{
            //    TenSanPham = tenSanPham,
            //    SoLuong = soLuong,
            //    TenKhachHang = tenKhachHang,
            //    DonGia = donGia

            //};
            //gioHang.Add(sp);
            //dtg_gioHang.DataSource = gioHang.ToList();
            //txt_tongTien.Text = gioHang.Sum(x => x.ThanhTien).ToString("N0");
            //ClearInputFields();
            int soLuong = (int)num_soLuong.Value;

            if (string.IsNullOrWhiteSpace(lab_tenSanPham.Text)
        || string.IsNullOrWhiteSpace(lab_donGia.Text)
        || string.IsNullOrWhiteSpace(lab_tenKhachHang.Text)
        || lab_tenSanPham.Text == "@@@"
        || lab_tenKhachHang.Text == "@@@"
        || lab_donGia.Text == "@@@")
            {
                lab_thongBao.Text = "Vui lòng chọn sản phẩm và khách hàng trước khi thêm vào giỏ hàng.";
                lab_thongBao.ForeColor = Color.Red;
                lab_thongBao.Visible = true;
                return;
            }
            if (soLuong <= 0 || soLuong > soLuongTon)
            {
                lab_thongBao.Text = "Số lượng không hợp lệ hoặc vượt quá số lượng tồn kho.";
                lab_thongBao.ForeColor = Color.Red;
                lab_thongBao.Visible = true;
                return;
            }
            var item = GioHang.FirstOrDefault(x => x.MaSPCT == lab_maSanPham.Text);
            if (item != null)
            {
                item.SoLuong += soLuong;
                if (item.SoLuong > soLuongTon)
                {
                    lab_thongBao.Text = "Số lượng không hợp lệ hoặc vượt quá số lượng tồn kho.";
                    lab_thongBao.ForeColor = Color.Red;
                    lab_thongBao.Visible = true;
                    return;
                }
                LoadGioHang();
            }
            else
            {
                var dhct = new DonHangChiTiet
                {
                    MaDHCT = Guid.NewGuid().ToString(),
                    MaDH = string.Empty,
                    MaSPCT = lab_maSanPham.Text,
                    DonGia = decimal.Parse(lab_donGia.Text),
                    SoLuong = (int)num_soLuong.Value,
                };
                GioHang.Add(dhct);
                LoadGioHang();
                ClearInputFields();
            }
        }
        private void ClearInputFields()
        {
            lab_tenSanPham.Text = string.Empty;
            lab_donGia.Text = string.Empty;
            lab_tenKhachHang.Text = string.Empty;
            num_soLuong.Value = 0;
            lab_soLuongTon.Text = string.Empty;
            lab_maSanPham.Text = string.Empty;
            lab_thongBao.Text = string.Empty;
            lab_maKhachHang.Text = string.Empty;
        }
        string maSp = string.Empty;
        private void dtg_sanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtg_sanPham.Rows[e.RowIndex];
                maSp = row.Cells["MaSP"].Value.ToString();
                lab_tenSanPham.Text = row.Cells["TenSP"].Value.ToString();
                lab_donGia.Text = row.Cells["GiaBan"].Value.ToString();
                lab_soLuongTon.Text = row.Cells["SoLuong"].Value.ToString();
                soLuongTon = (int)row.Cells["SoLuong"].Value;
                lab_maSanPham.Text = maSp;
            }
        }

        private void dtg_khachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtg_khachHang.Rows[e.RowIndex];
                lab_tenKhachHang.Text = row.Cells["HoTen"].Value.ToString();
                lab_maKhachHang.Text = row.Cells["MaKH"].Value.ToString();
            }
        }

        private void llab_dangXuat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PhienDangNhap.MaNV = string.Empty;
            PhienDangNhap.HoTen = string.Empty;
            PhienDangNhap.Email = string.Empty;
            PhienDangNhap.VaiTro = string.Empty;
            this.Close();
        }

        private void btn_thanhToan_Click(object sender, EventArgs e)
        {
            if (GioHang.Count == 0)
            {
                lab_thongBao.Text = "Giỏ hàng trống, không thể thanh toán.";
                lab_thongBao.ForeColor = Color.Red;
                lab_thongBao.Visible = true;
                return;
            }
            string maDh = Guid.NewGuid().ToString();
            DonHang dh = new DonHang
            {
                MaDH = maDh,
                NgayDat = DateTime.Now,
                TongTien = decimal.Parse(txt_tongTien.Text),
                TrangThai = "Chờ xử lý",
                MaKH = lab_maKhachHang.Text,
                MaNV = PhienDangNhap.MaNV,
                MaVoucher = txt_voucher.Text.Trim()
            };
            bool isSuccess = dhRepo.Add(dh);
            if(isSuccess != true)
            {
                lab_thongBao.Text = "Lỗi khi tạo đơn hàng. Vui lòng thử lại.";
            }
            foreach (var item in GioHang)
            {
                item.MaDH = maDh;
                bool isAdded = dhctRepo.Add(item);
                if (!isAdded)
                {
                    lab_thongBao.Text = "Lỗi khi thêm sản phẩm vào đơn hàng. Vui lòng thử lại.";
                    return;
                }
                sprepo.TruTonKho(item.MaSPCT, item.SoLuong);
                lab_thongBao.Text = "Thanh toán thành công!";
                lab_thongBao.ForeColor = Color.Green;
                LoadData();
                ClearInputFields();
                daApDungVoucher = false;
            }
        }

        private void btn_apDungVoucher_Click(object sender, EventArgs e)
        {
            if (daApDungVoucher)
            {
                lab_thongBao.Text = "Voucher đã được áp dụng cho hóa đơn này.";
                lab_thongBao.ForeColor = Color.Red;
                lab_thongBao.Visible = true;
                return;
            }
            tongTien = decimal.Parse(txt_tongTien.Text);
            var validVoucher = vRepo.GetValidVouchers()
                            .Where(x => x.MaVoucher.ToLower() == txt_voucher.Text.Trim().ToLower())
                            .FirstOrDefault();
            if (validVoucher != null)
            {
                var giaTriGiam = tongTien * validVoucher.GiaTri / 100;
                txt_tongTien.Text = (tongTien - giaTriGiam).ToString("N0");
                lab_thongBao.Text = "Voucher đã được áp dụng thành công!";
                lab_thongBao.ForeColor = Color.Green;
                daApDungVoucher = true;

            }
        }

        private void txt_voucher_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var validVoucher = vRepo.GetValidVouchers().FirstOrDefault(x => x.MaVoucher.ToLower() == txt_voucher.Text.Trim().ToLower());
                if (validVoucher != null)
                {
                    lab_tenVoucher.Text = validVoucher.TenVoucher;
                }
                else
                {
                    lab_tenVoucher.Text = "";
                }
            }
            catch (Exception ex)
            {
                lab_tenVoucher.Text = "";
            }
        }
    }
}
