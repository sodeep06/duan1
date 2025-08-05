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
    public partial class FormSanPham : Form
    {
        ShopDbContext db = new ShopDbContext();
        public FormSanPham()
        {
            InitializeComponent();
            LoadDanhMuc();
            LoadSanPham();
        }
        private void LoadDanhMuc()
        {
            var danhmucs = db.DanhMucs.ToList();
            cbDanhMuc.DataSource = danhmucs;
            cbDanhMuc.DisplayMember = "TenDM";
            cbDanhMuc.ValueMember = "MaDM";
        }

        private void LoadSanPham(string maDM = null)
        {
            var query = db.SanPhams.AsQueryable();
            if (!string.IsNullOrEmpty(maDM))
                query = query.Where(sp => sp.MaDM == maDM);

            var data = query.Select(sp => new
            {
                sp.MaSP,
                sp.TenSP,
                sp.GiaBan,
                sp.SoLuong,
                sp.MoTa,
                sp.MaDM,
                TenDM = sp.DanhMuc.TenDM,
                sp.HinhAnh
            }).ToList();

            dgvSanPham.DataSource = data;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var hinhAnh = picHinhAnh.Tag != null ? picHinhAnh.Tag.ToString() : null;
            var sp = new SanPham
            {
                MaSP = txtMaSP.Text,
                TenSP = txtTenSP.Text,
                GiaBan = decimal.Parse(txtGiaBan.Text),
                SoLuong = int.Parse(txtSoLuong.Text),
                MoTa = txtMoTa.Text,
                MaDM = cbDanhMuc.SelectedValue.ToString(),
                HinhAnh = hinhAnh
            };

            db.SanPhams.Add(sp);
            db.SaveChanges();
            LoadSanPham();
            MessageBox.Show("Thêm sản phẩm thành công!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var ma = txtMaSP.Text;
            var sp = db.SanPhams.FirstOrDefault(x => x.MaSP == ma);
            if (sp != null)
            {
                sp.TenSP = txtTenSP.Text;
                sp.GiaBan = decimal.Parse(txtGiaBan.Text);
                sp.SoLuong = int.Parse(txtSoLuong.Text);
                sp.MoTa = txtMoTa.Text;
                sp.MaDM = cbDanhMuc.SelectedValue.ToString();
                if (picHinhAnh.Tag != null)
                    sp.HinhAnh = picHinhAnh.Tag.ToString();

                db.SaveChanges();
                LoadSanPham();
                MessageBox.Show("Cập nhật thành công!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var ma = txtMaSP.Text;
            var sp = db.SanPhams.FirstOrDefault(x => x.MaSP == ma);
            if (sp != null)
            {
                db.SanPhams.Remove(sp);
                db.SaveChanges();
                LoadSanPham();
                MessageBox.Show("Đã xóa!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            txtMoTa.Clear();
            cbDanhMuc.SelectedIndex = -1; // Bỏ chọn danh mục
            picHinhAnh.Image = null;
            picHinhAnh.Tag = null;

            LoadSanPham(); // Hiển thị tất cả sản phẩm trên DataGridView
            dgvSanPham.ClearSelection(); // (Tùy chọn) Bỏ chọn dòng trên DGV
        }


        private bool isSelectingFromGrid = false;
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)

        {
            if (e.RowIndex >= 0)
            {
                var row = dgvSanPham.Rows[e.RowIndex];
                txtMaSP.Text = row.Cells[0].Value?.ToString();
                txtTenSP.Text = row.Cells[1].Value?.ToString();
                txtGiaBan.Text = row.Cells[2].Value?.ToString();
                txtSoLuong.Text = row.Cells[3].Value?.ToString();
                txtMoTa.Text = row.Cells[4].Value?.ToString();

                // Gán mã danh mục vào ComboBox nhưng KHÔNG TRIGGER lọc
                isSelectingFromGrid = true; // Đặt cờ để không lọc
                var maDM = row.Cells[5].Value?.ToString();
                var danhMucList = cbDanhMuc.DataSource as List<DanhMuc>;
                if (!string.IsNullOrEmpty(maDM) && danhMucList != null && danhMucList.Any(dm => dm.MaDM == maDM))
                    cbDanhMuc.SelectedValue = maDM;
                else
                    cbDanhMuc.SelectedIndex = -1;
                isSelectingFromGrid = false;

                // Chỉ lấy hình ảnh nếu đủ cột!
                string hinhAnh = null;
                if (row.Cells.Count > 7)
                    hinhAnh = row.Cells[7].Value?.ToString();

                if (!string.IsNullOrEmpty(hinhAnh) && System.IO.File.Exists(hinhAnh))
                {
                    picHinhAnh.Image = Image.FromFile(hinhAnh);
                    picHinhAnh.Tag = hinhAnh;
                }
                else
                {
                    picHinhAnh.Image = null;
                    picHinhAnh.Tag = null;
                }
            }
        }



        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isSelectingFromGrid) return; // Nếu đang thao tác từ DataGridView thì bỏ qua, không lọc

            if (cbDanhMuc.SelectedIndex == -1 || cbDanhMuc.SelectedValue == null)
            {
                LoadSanPham(); // Hiển thị tất cả sản phẩm
            }
            else
            {
                LoadSanPham(cbDanhMuc.SelectedValue.ToString()); // Lọc theo mã danh mục
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picHinhAnh.Image = Image.FromFile(ofd.FileName);
                    picHinhAnh.Tag = ofd.FileName; // Lưu đường dẫn tạm vào Tag để xử lý khi lưu DB
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(tuKhoa))
            {
                LoadSanPham(); // Nếu không nhập gì thì hiển thị full sản phẩm
                return;
            }

            var data = db.SanPhams
                .Where(sp =>
                    sp.MaSP.ToLower().Contains(tuKhoa) ||
                    sp.TenSP.ToLower().Contains(tuKhoa) ||
                    sp.MoTa.ToLower().Contains(tuKhoa)
                )
                .Select(sp => new
                {
                    sp.MaSP,
                    sp.TenSP,
                    sp.GiaBan,
                    sp.SoLuong,
                    sp.MoTa,
                    sp.MaDM,
                    TenDM = sp.DanhMuc.TenDM,
                    sp.HinhAnh
                }).ToList();

            dgvSanPham.DataSource = data;
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem.PerformClick();
            }
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {

        }


    }
}

