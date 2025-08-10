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
        ShopDbContext db = new ShopDbContext();
        KhachHangRepo khrepo = new KhachHangRepo();
        List<DonHangChiTietDTO> gioHang = new List<DonHangChiTietDTO>();
        List<DonHangChiTiet> GioHang = new List<DonHangChiTiet>();
        DonHangChiTietRepo dhctRepo = new DonHangChiTietRepo();
        DonHangRepo dhRepo = new DonHangRepo();
        VoucherRepo vRepo = new VoucherRepo();
        ChiTietSanPhamRepo ctspRepo = new ChiTietSanPhamRepo();
        decimal tongTien = 0;
        bool daApDungVoucher = false;
        public FormBanHang()
        {
            InitializeComponent();
        }

        private void LoadSanPham()
        {
            dtg_sanPham.DataSource = sprepo.GetSanPhamHopLe();
            dtg_sanPham.Columns["MaSP"].Visible = false;
            dtg_sanPham.Columns["MaDM"].Visible = false;
            dtg_sanPham.Columns["HinhAnh"].Visible = false;
            dtg_sanPham.Columns["DanhMuc"].Visible = false;
            dtg_sanPham.Columns["ChiTietSanPhams"].Visible = false;
            dtg_sanPham.Columns["SoLuong"].Visible = false;


            dtg_sanPham.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            dtg_sanPham.Columns["GiaBan"].HeaderText = "Giá bán";
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
            dtg_gioHang.DataSource = null;

            // Nếu chưa có cột checkbox, thêm cột checkbox
            if (!dtg_gioHang.Columns.Contains("Chon"))
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Name = "Chon";
                chk.HeaderText = "Chọn";
                dtg_gioHang.Columns.Insert(0, chk);
            }

            var spChiTietList = (from ct in db.ChiTietSanPhams
                                 join sp in db.SanPhams on ct.MaSP equals sp.MaSP
                                 select new
                                 {
                                     ct.MaSPCT,
                                     TenSanPham = sp.TenSP,
                                     ct.KichThuoc,
                                     ct.MauSac
                                 }).ToList();

            var data = GioHang.Select(x => new
            {
                x.MaSPCT,
                TenSanPham = spChiTietList
                                    .Where(ct => ct.MaSPCT == x.MaSPCT)
                                    .Select(ct => $"{ct.TenSanPham} (Size: {ct.KichThuoc}, Màu: {ct.MauSac})")
                                    .FirstOrDefault() ?? "Không tìm thấy",
                x.DonGia,
                x.SoLuong,
                ThanhTien = x.DonGia * x.SoLuong
            }).ToList();

            dtg_gioHang.DataSource = data;

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
            int soLuong = (int)num_soLuong.Value;

            if (string.IsNullOrWhiteSpace(lab_tenSanPham.Text) ||
                string.IsNullOrWhiteSpace(lab_donGia.Text) ||
                string.IsNullOrWhiteSpace(lab_tenKhachHang.Text) ||
                cbo_choTietSanPham.SelectedValue == null)
            {
                lab_thongBao.Text = "Vui lòng chọn sản phẩm (kèm biến thể) và khách hàng trước khi thêm.";
                lab_thongBao.ForeColor = Color.Red;
                lab_thongBao.Visible = true;
                return;
            }

            string maSPCT = cbo_choTietSanPham.SelectedValue.ToString();
            var ctsp = db.ChiTietSanPhams.FirstOrDefault(x => x.MaSPCT == maSPCT);

            if (ctsp == null)
            {
                lab_thongBao.Text = "Biến thể sản phẩm không tồn tại.";
                lab_thongBao.ForeColor = Color.Red;
                return;
            }

            if (soLuong <= 0 || soLuong > ctsp.SoLuongTon)
            {
                lab_thongBao.Text = $"Số lượng không hợp lệ.";
                lab_thongBao.ForeColor = Color.Red;
                return;
            }

            var item = GioHang.FirstOrDefault(x => x.MaSPCT == maSPCT);
            if (item != null)
            {
                if (item.SoLuong + soLuong > ctsp.SoLuongTon)
                {
                    lab_thongBao.Text = $"Không thể thêm quá số lượng tồn ({ctsp.SoLuongTon}).";
                    lab_thongBao.ForeColor = Color.Red;
                    return;
                }
                item.SoLuong += soLuong;
            }
            else
            {
                GioHang.Add(new DonHangChiTiet
                {
                    MaDHCT = Guid.NewGuid().ToString(),
                    MaDH = string.Empty,
                    MaSPCT = maSPCT,
                    DonGia = ctsp.GiaBan,
                    SoLuong = soLuong
                });
            }

            LoadGioHang();
            ClearSanPhamFields();
            lab_thongBao.Text = "Đã thêm vào giỏ hàng.";
            lab_thongBao.ForeColor = Color.Green;
        }
        private void ClearSanPhamFields()
        {
            lab_tenSanPham.Text = string.Empty;
            lab_donGia.Text = string.Empty;
            num_soLuong.Value = 0;
            lab_soLuongTon.Text = string.Empty;
            lab_maSanPham.Text = string.Empty;
            cbo_choTietSanPham.DataSource = null;
        }
        private void ClearKhachHangFields()
        {
            lab_tenKhachHang.Text = string.Empty;
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

                var listChiTiet = db.ChiTietSanPhams
                    .Where(ct => ct.MaSP == maSp)
                    .Select(ct => new
                    {
                        ct.MaSPCT,
                        MoTa = $"Size: {ct.KichThuoc} - Màu: {ct.MauSac} - Còn: {ct.SoLuongTon}"
                    })
                    .ToList();
                cbo_choTietSanPham.DataSource = listChiTiet;
                cbo_choTietSanPham.DisplayMember = "MoTa";
                cbo_choTietSanPham.ValueMember = "MaSPCT";
            }
        }

        private void dtg_khachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maKhachHangMoi = dtg_khachHang.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();

                if (GioHang.Count > 0 && lab_maKhachHang.Text != "" && lab_maKhachHang.Text != maKhachHangMoi)
                {
                    var result = MessageBox.Show(
                        "Bạn đang có giỏ hàng với khách hàng khác. Thay đổi khách hàng sẽ xóa giỏ hàng hiện tại. Bạn có chắc không?",
                        "Xác nhận thay đổi khách hàng",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        GioHang.Clear();
                        LoadGioHang();
                    }
                }

                lab_tenKhachHang.Text = dtg_khachHang.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
                lab_maKhachHang.Text = maKhachHangMoi;
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
            if (string.IsNullOrWhiteSpace(lab_maKhachHang.Text))
            {
                lab_thongBao.Text = "Vui lòng chọn khách hàng trước khi thanh toán.";
                lab_thongBao.ForeColor = Color.Red;
                lab_thongBao.Visible = true;
                return;
            }

            string? maVoucher = null;
            decimal tongTien = GioHang.Sum(x => x.DonGia * x.SoLuong);

            if (!string.IsNullOrWhiteSpace(txt_voucher.Text))
            {
                var voucher = vRepo.GetValidVouchers()
                    .FirstOrDefault(x => x.MaVoucher.ToLower() == txt_voucher.Text.Trim().ToLower());
                if (voucher != null)
                {
                    maVoucher = voucher.MaVoucher;
                    tongTien -= tongTien * voucher.GiaTri / 100;
                }
            }

            string maDh = Guid.NewGuid().ToString();
            DonHang dh = new DonHang
            {
                MaDH = maDh,
                NgayDat = DateTime.Now,
                TongTien = tongTien,
                TrangThai = "Đã thanh toán",
                MaKH = lab_maKhachHang.Text,
                MaNV = PhienDangNhap.MaNV,
                MaVoucher = maVoucher
            };

            bool isSuccess = dhRepo.Add(dh);
            if (!isSuccess)
            {
                lab_thongBao.Text = "Lỗi khi tạo đơn hàng. Vui lòng thử lại.";
                lab_thongBao.ForeColor = Color.Red;
                return;
            }

            foreach (var item in GioHang)
            {
                item.MaDH = maDh;
                bool isAdded = dhctRepo.Add(item);
                if (!isAdded)
                {
                    lab_thongBao.Text = "Lỗi khi thêm sản phẩm vào đơn hàng. Vui lòng thử lại.";
                    lab_thongBao.ForeColor = Color.Red;
                    return;
                }
                ctspRepo.TruTonKho(item.MaSPCT, item.SoLuong);
            }

            lab_thongBao.Text = "Thanh toán thành công!";
            lab_thongBao.ForeColor = Color.Green;

            LoadData();
            GioHang.Clear();
            ClearInputFields();
            daApDungVoucher = false;
        }
        private void ClearInputFields()
        {
            ClearSanPhamFields();
            ClearKhachHangFields();
            LoadGioHang();
            txt_tongTien.Text = "0";
            txt_voucher.Text = string.Empty;
            lab_tenVoucher.Text = string.Empty;
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

        private void dtg_sanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maSP = dtg_sanPham.Rows[e.RowIndex].Cells["MaSP"].Value.ToString();
                var formCTSP = new FormChiTietSanPham(maSP);

                if (formCTSP.ShowDialog() == DialogResult.OK)
                {
                    string maSPCT = formCTSP.SelectedMaSPCT;
                    cbo_choTietSanPham.SelectedValue = maSPCT;
                    lab_thongBaoChon.Text = "Đã chọn nâng cao";
                    lab_thongBaoChon.ForeColor = Color.Green;
                }
            }
        }

        private void dtg_sanPham_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dtg_gioHang.Columns[e.ColumnIndex].Name == "SoLuong")
            {
                int newSoLuong;
                dtg_gioHang.Columns["SoLuong"].ReadOnly = false;
                var cell = dtg_gioHang.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (int.TryParse(cell.Value?.ToString(), out newSoLuong) && newSoLuong > 0)
                {
                    var tenSanPhamFull = dtg_gioHang.Rows[e.RowIndex].Cells["TenSanPham"].Value.ToString();
                    var item = GioHang[e.RowIndex];

                    int tonKho = ctspRepo.GetSoLuongTon(item.MaSPCT);
                    if (newSoLuong <= tonKho)
                    {
                        item.SoLuong = newSoLuong;
                        LoadGioHang();
                        lab_thongBao.Text = "Cập nhật số lượng thành công.";
                        lab_thongBao.ForeColor = Color.Green;
                    }
                    else
                    {
                        lab_thongBao.Text = $"Số lượng vượt quá tồn kho ({tonKho}).";
                        lab_thongBao.ForeColor = Color.Red;
                        cell.Value = item.SoLuong;
                    }
                }
                else
                {
                    lab_thongBao.Text = "Số lượng không hợp lệ.";
                    lab_thongBao.ForeColor = Color.Red;
                    cell.Value = GioHang[e.RowIndex].SoLuong;
                }
            }
        }

        private void btn_xoaSanPham_Click(object sender, EventArgs e)
        {
            if (dtg_gioHang.CurrentRow != null)
            {
                int rowIndex = dtg_gioHang.CurrentRow.Index;
                GioHang.RemoveAt(rowIndex);
                LoadGioHang();
                lab_thongBao.Text = "Đã xóa sản phẩm khỏi giỏ hàng.";
                lab_thongBao.ForeColor = Color.Green;
            }
        }

        private void lab_soLuongTon_Click(object sender, EventArgs e)
        {

        }

        private void dtg_gioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dtg_gioHang.Rows[e.RowIndex];
                var soLuongStr = row.Cells["SoLuong"].Value?.ToString();
                int soLuong = 0;
                int.TryParse(soLuongStr, out soLuong);

                num_soLuongSua.Value = soLuong;
            }
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            if (dtg_gioHang.CurrentRow != null)
            {
                int rowIndex = dtg_gioHang.CurrentRow.Index;
                var item = GioHang[rowIndex];
                int soLuongMoi = (int)num_soLuongSua.Value;

                int tonKho = ctspRepo.GetSoLuongTon(item.MaSPCT);
                if (soLuongMoi <= 0)
                {
                    lab_thongBao.Text = "Số lượng phải lớn hơn 0.";
                    lab_thongBao.ForeColor = Color.Red;
                    return;
                }
                if (soLuongMoi > tonKho)
                {
                    lab_thongBao.Text = $"Số lượng vượt quá tồn kho ({tonKho}).";
                    lab_thongBao.ForeColor = Color.Red;
                    return;
                }

                item.SoLuong = soLuongMoi;

                LoadGioHang();

                lab_thongBao.Text = "Cập nhật số lượng thành công.";
                lab_thongBao.ForeColor = Color.Green;
            }
        }
    }
}
