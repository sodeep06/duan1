using duan1.Models;
using Microsoft.EntityFrameworkCore;
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
    public partial class FormKhachHang : Form
    {
        private ShopDbContext _context = new ShopDbContext();

        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ClearInputs()
        {
            txtMaKH.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            txtEmail.Clear();

            // Bật lại cho phép nhập MãKH
            txtMaKH.Enabled = true;

            // Bỏ chọn trên DataGridView
            dgvKhachHang.ClearSelection();

            // Đưa con trỏ về ô MãKH
            txtMaKH.Focus();
        }
        private void LoadData()
        {
            var data = _context.KhachHangs
                                  .AsNoTracking()
                                  .OrderBy(x => x.MaKH)
                                  .ToList();
            dgvKhachHang.AutoGenerateColumns = true;
            dgvKhachHang.DataSource = data;

            // Ẩn cột DonHangs (nếu EF tự tạo)
            if (dgvKhachHang.Columns["DonHangs"] != null)
                dgvKhachHang.Columns["DonHangs"].Visible = false;

            // Mặc định không chọn dòng nào để tránh đổ lên textbox khi vừa load
            dgvKhachHang.ClearSelection();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            var ma = txtMaKH.Text?.Trim();
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Mã KH và Họ Tên là bắt buộc.");
                return;
            }

            // Tìm khách hàng theo MaKH
            var existing = _context.KhachHangs.FirstOrDefault(k => k.MaKH == ma);

            if (existing == null)
            {
                // ======= Thêm mới =======
                var kh = new KhachHang
                {
                    MaKH = ma,
                    HoTen = txtHoTen.Text.Trim(),
                    SDT = txtSDT.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                _context.KhachHangs.Add(kh);
            }
            else
            {
                // ======= Cập nhật =======
                existing.HoTen = txtHoTen.Text.Trim();
                existing.SDT = txtSDT.Text.Trim();
                existing.DiaChi = txtDiaChi.Text.Trim();
                existing.Email = txtEmail.Text.Trim();

                _context.KhachHangs.Update(existing);
            }

            _context.SaveChanges();
            LoadData();       // Tải lại DataGridView
            ClearInputs();    // Xoá trắng form
            txtMaKH.Enabled = true; // Cho phép nhập mã mới sau khi lưu
            MessageBox.Show("Đã lưu thành công!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var ma = txtMaKH.Text?.Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa.");
                return;
            }

            var kh = _context.KhachHangs.FirstOrDefault(k => k.MaKH == ma);
            if (kh != null)
            {
                var confirm = MessageBox.Show(
                    $"Bạn có chắc muốn xóa khách hàng {kh.HoTen}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    _context.KhachHangs.Remove(kh);
                    _context.SaveChanges();
                    LoadData();
                    ClearInputs();
                    MessageBox.Show("Đã xóa thành công!");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng cần xóa.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
            ClearInputs();
            txtSearch.Clear();
        }

        private void ApplyFilter(string keyword)
        {
            keyword = (keyword ?? "").Trim();

            // Rỗng → tải lại tất cả
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
                return;
            }

            // Tìm không phân biệt hoa thường, lọc theo nhiều cột
            var k = keyword.ToLower();

            var filtered = _context.KhachHangs
                .AsNoTracking()
                .Where(x =>
                    (x.MaKH ?? "").ToLower().Contains(k) ||
                    (x.HoTen ?? "").ToLower().Contains(k) ||
                    (x.SDT ?? "").ToLower().Contains(k) ||
                    (x.Email ?? "").ToLower().Contains(k) ||
                    (x.DiaChi ?? "").ToLower().Contains(k)
                )
                .OrderBy(x => x.MaKH)
                .ToList();

            dgvKhachHang.DataSource = filtered;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter(txtSearch.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilter(txtSearch.Text);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var ma = txtMaKH.Text?.Trim();
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Mã KH và Họ Tên là bắt buộc.");
                return;
            }

            // KHÔNG cho trùng khóa chính
            var exists = _context.KhachHangs.Any(x => x.MaKH == ma);
            if (exists)
            {
                MessageBox.Show("Mã KH đã tồn tại. Vui lòng nhập mã khác.");
                txtMaKH.Focus();
                return;
            }

            var kh = new KhachHang
            {
                MaKH = ma,
                HoTen = txtHoTen.Text.Trim(),
                SDT = txtSDT.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                Email = txtEmail.Text.Trim()
            };

            _context.KhachHangs.Add(kh);
            _context.SaveChanges();

            LoadData();     // reload lưới
            ClearInputs();  // xóa trắng form
            MessageBox.Show("Đã thêm khách hàng mới!");
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvKhachHang.Rows[e.RowIndex].DataBoundItem is KhachHang kh)
            {
                txtMaKH.Text = kh.MaKH;
                txtHoTen.Text = kh.HoTen;
                txtSDT.Text = kh.SDT;
                txtDiaChi.Text = kh.DiaChi;
                txtEmail.Text = kh.Email;
                txtMaKH.Enabled = false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
            txtMaKH.Enabled = true; // cho phép nhập mã mới
            txtMaKH.Focus();
            dgvKhachHang.ClearSelection();
        }
    }
}
