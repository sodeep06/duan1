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

        private void LoadSanPham()
        {
            var data = db.SanPhams
                .Select(sp => new
                {
                    sp.MaSP,
                    sp.TenSP,
                    sp.GiaBan,
                    sp.SoLuong,
                    sp.MoTa,
                    sp.MaDM,                // <-- thêm mã danh mục
                    TenDM = sp.DanhMuc.TenDM
                }).ToList();
            dgvSanPham.DataSource = data;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            var sp = new SanPham
            {
                MaSP = txtMaSP.Text,
                TenSP = txtTenSP.Text,
                GiaBan = decimal.Parse(txtGiaBan.Text),
                SoLuong = int.Parse(txtSoLuong.Text),
                MoTa = txtMoTa.Text,
                MaDM = cbDanhMuc.SelectedValue.ToString()
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
            cbDanhMuc.SelectedIndex = 0;
        }

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

                // Gán mã danh mục nếu tồn tại trong ComboBox
                var maDM = row.Cells[5].Value?.ToString();
                var danhMucList = cbDanhMuc.DataSource as List<DanhMuc>;
                if (maDM != null && danhMucList != null && danhMucList.Any(dm => dm.MaDM == maDM))
                    cbDanhMuc.SelectedValue = maDM;
                else
                    cbDanhMuc.SelectedIndex = -1;
            }
        }

        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDanhMuc.SelectedValue != null)
            {
                var maDM = cbDanhMuc.SelectedValue.ToString();
                var data = db.SanPhams
                    .Where(sp => sp.MaDM == maDM)
                    .Select(sp => new
                    {
                        sp.MaSP,
                        sp.TenSP,
                        sp.GiaBan,
                        sp.SoLuong,
                        sp.MoTa,
                        sp.MaDM,
                        TenDM = sp.DanhMuc.TenDM
                    })
                    .ToList();
                dgvSanPham.DataSource = data;
            }
            else
            {
                // Nếu không hợp lệ thì không làm gì hoặc load tất cả sản phẩm
                // LoadSanPham();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
