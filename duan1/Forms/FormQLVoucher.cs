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
    public partial class FormQLVoucher : Form
    {
        public FormQLVoucher()
        {
            InitializeComponent();
            LoadData();
            dgvVoucher.SelectionChanged += dgvVoucher_SelectionChanged;
        }

        private void LoadData()
        {
            using (var context = new ShopDbContext())
            {
                var data = context.Vouchers
                    .Select(v => new
                    {
                        MaVoucher = v.MaVoucher,
                        TenVoucher = v.TenVoucher,
                        GiaTri = v.GiaTri,
                        NgayBatDau = v.NgayBatDau,
                        NgayKetThuc = v.NgayKetThuc
                    })
                    .ToList();

                dgvVoucher.DataSource = data;

                // Đặt lại header nếu cần (tùy chỉnh giao diện)
                dgvVoucher.Columns["MaVoucher"].HeaderText = "Mã Voucher";
                dgvVoucher.Columns["TenVoucher"].HeaderText = "Tên Voucher";
                dgvVoucher.Columns["GiaTri"].HeaderText = "Giá Trị";
                dgvVoucher.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
                dgvVoucher.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";
            }
        }

        private void ClearFields()
        {
            txtMaVoucher.Clear();
            txtTenVoucher.Clear();
            txtGiaTri.Clear();
            dtpNgayBatDau.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
        }

        private void dgvVoucher_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVoucher.CurrentRow != null && dgvVoucher.CurrentRow.Index >= 0)
            {
                txtMaVoucher.Text = dgvVoucher.CurrentRow.Cells["MaVoucher"].Value?.ToString();
                txtTenVoucher.Text = dgvVoucher.CurrentRow.Cells["TenVoucher"].Value?.ToString();
                txtGiaTri.Text = dgvVoucher.CurrentRow.Cells["GiaTri"].Value?.ToString();

                if (DateTime.TryParse(dgvVoucher.CurrentRow.Cells["NgayBatDau"].Value?.ToString(), out var nbd))
                    dtpNgayBatDau.Value = nbd;

                if (DateTime.TryParse(dgvVoucher.CurrentRow.Cells["NgayKetThuc"].Value?.ToString(), out var nkt))
                    dtpNgayKetThuc.Value = nkt;
            }
        }

        private bool ValidateInput(out decimal giaTri)
        {
            giaTri = 0;

            if (string.IsNullOrWhiteSpace(txtMaVoucher.Text) ||
                string.IsNullOrWhiteSpace(txtTenVoucher.Text) ||
                string.IsNullOrWhiteSpace(txtGiaTri.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtGiaTri.Text.Trim(), out giaTri))
            {
                MessageBox.Show("Giá trị giảm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (giaTri <= 0)
            {
                MessageBox.Show("Giá trị giảm phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DateTime now = DateTime.Now.Date;
            DateTime ngayBatDau = dtpNgayBatDau.Value.Date;
            DateTime ngayKetThuc = dtpNgayKetThuc.Value.Date;

            if (ngayBatDau < now)
            {
                MessageBox.Show("Ngày bắt đầu không được nhỏ hơn ngày hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ngayKetThuc < ngayBatDau)
            {
                MessageBox.Show("Ngày kết thúc không được trước ngày bắt đầu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out decimal giaTri)) return;

            using (var context = new ShopDbContext())
            {
                string ma = txtMaVoucher.Text.Trim();

                if (context.Vouchers.Any(v => v.MaVoucher == ma))
                {
                    MessageBox.Show("Mã voucher đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var v = new Voucher
                {
                    MaVoucher = ma,
                    TenVoucher = txtTenVoucher.Text.Trim(),
                    GiaTri = giaTri,
                    NgayBatDau = dtpNgayBatDau.Value,
                    NgayKetThuc = dtpNgayKetThuc.Value
                };

                context.Vouchers.Add(v);
                context.SaveChanges();
            }

            LoadData();
            ClearFields();
            MessageBox.Show("Thêm voucher thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out decimal giaTri)) return;

            using (var context = new ShopDbContext())
            {
                string ma = txtMaVoucher.Text.Trim();
                var v = context.Vouchers.FirstOrDefault(x => x.MaVoucher == ma);

                if (v == null)
                {
                    MessageBox.Show("Không tìm thấy voucher để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                v.TenVoucher = txtTenVoucher.Text.Trim();
                v.GiaTri = giaTri;
                v.NgayBatDau = dtpNgayBatDau.Value;
                v.NgayKetThuc = dtpNgayKetThuc.Value;

                context.SaveChanges();
            }

            LoadData();
            ClearFields();
            MessageBox.Show("Cập nhật voucher thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaVoucher.Text.Trim();

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa voucher này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using (var context = new ShopDbContext())
            {
                var v = context.Vouchers.FirstOrDefault(x => x.MaVoucher == ma);
                if (v == null)
                {
                    MessageBox.Show("Không tìm thấy voucher để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                context.Vouchers.Remove(v);
                context.SaveChanges();
            }

            LoadData();
            ClearFields();
            MessageBox.Show("Xóa voucher thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
