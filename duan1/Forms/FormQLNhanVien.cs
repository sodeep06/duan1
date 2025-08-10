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
    public partial class FormQLNhanVien : Form
    {
        private List<NhanVien> danhSachNhanVien = new List<NhanVien>();

        public FormQLNhanVien()
        {
            InitializeComponent();
            LoadData();
            dgvNhanVien.SelectionChanged += dgvNhanVien_SelectionChanged;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }

        // Load dữ liệu vào DataGridView
        private void LoadData()
        {
            using (var context = new ShopDbContext())
            {
                danhSachNhanVien = context.NhanViens.ToList();

                dgvNhanVien.DataSource = danhSachNhanVien
                    .Select(nv => new
                    {
                        nv.MaNV,
                        nv.HoTen,
                        nv.Email,
                        nv.MatKhau,
                        VaiTro = nv.VaiTro
                    })
                    .ToList();
            }
        }

        // Xóa thông tin trong các textbox
        private void ClearFields()
        {
            txtMaNhanVien.Text = "";
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtMatKhau.Text = "";
        }

        // Khi chọn dòng → đổ dữ liệu vào textbox
        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null && dgvNhanVien.CurrentRow.Index >= 0)
            {
                txtMaNhanVien.Text = dgvNhanVien.CurrentRow.Cells["MaNV"].Value?.ToString();
                txtHoTen.Text = dgvNhanVien.CurrentRow.Cells["HoTen"].Value?.ToString();
                txtEmail.Text = dgvNhanVien.CurrentRow.Cells["Email"].Value?.ToString();
                txtMatKhau.Text = dgvNhanVien.CurrentRow.Cells["MatKhau"].Value?.ToString();
            }
        }

        // Thêm nhân viên
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ShopDbContext())
                {
                    string maNV = txtMaNhanVien.Text.Trim();

                    if (string.IsNullOrEmpty(maNV))
                    {
                        MessageBox.Show("Vui lòng nhập mã nhân viên.");
                        return;
                    }

                    if (context.NhanViens.Any(nv => nv.MaNV == maNV))
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại.");
                        return;
                    }

                    var nv = new NhanVien
                    {
                        MaNV = maNV,
                        HoTen = txtHoTen.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        MatKhau = txtMatKhau.Text.Trim(),
                        VaiTro = "NV" // Gán mặc định là nhân viên (tồn tại trong bảng VaiTro)
                    };

                    context.NhanViens.Add(nv);
                    context.SaveChanges();
                }

                MessageBox.Show("Thêm nhân viên thành công.");
                LoadData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Thêm: " + ex.Message);
            }
        }

        // Sửa nhân viên
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ShopDbContext())
                {
                    string maNV = txtMaNhanVien.Text.Trim();
                    var nv = context.NhanViens.FirstOrDefault(n => n.MaNV == maNV);

                    if (nv != null)
                    {
                        nv.HoTen = txtHoTen.Text.Trim();
                        nv.Email = txtEmail.Text.Trim();
                        nv.MatKhau = txtMatKhau.Text.Trim();
                        context.SaveChanges();

                        MessageBox.Show("Sửa thông tin nhân viên thành công.");
                        LoadData();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên để sửa.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Sửa: " + ex.Message);
            }
        }

        // Xóa nhân viên
        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new ShopDbContext())
                {
                    string maNV = txtMaNhanVien.Text.Trim();
                    var nv = context.NhanViens.FirstOrDefault(n => n.MaNV == maNV);

                    if (nv != null)
                    {
                        context.NhanViens.Remove(nv);
                        context.SaveChanges();

                        MessageBox.Show("Xóa nhân viên thành công.");
                        LoadData();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên để xóa.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Xóa: " + ex.Message);
            }
        }

        // Tìm kiếm realtime trên list
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            var filteredList = danhSachNhanVien
                .Where(nv =>
                    (!string.IsNullOrEmpty(nv.MaNV) && nv.MaNV.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(nv.HoTen) && nv.HoTen.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(nv.Email) && nv.Email.ToLower().Contains(keyword)))
                .Select(nv => new
                {
                    nv.MaNV,
                    nv.HoTen,
                    nv.Email,
                    nv.MatKhau,
                    VaiTro = nv.VaiTro
                })
                .ToList();

            dgvNhanVien.DataSource = filteredList;
        }

        private void FormQLNhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}
