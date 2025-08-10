using duan1.Repositories;
using QuestPDF.Fluent;
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
    public partial class FormHoaDon : Form
    {
        DonHangRepo _repo = new DonHangRepo();
        DonHangChiTietRepo dhctRepo = new DonHangChiTietRepo();
        public FormHoaDon()
        {
            InitializeComponent();
        }
        private void LoadDonHang()
        {
            var items = _repo.GetAllWithDetails();
            dtg_hoaDon.DataSource = items;
            dtg_hoaDon.Columns["MaDH"].HeaderText = "Mã Đơn Hàng";
            dtg_hoaDon.Columns["NgayDat"].HeaderText = "Ngày đặt";
            dtg_hoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";
            dtg_hoaDon.Columns["TrangThai"].HeaderText = "Trạng thái";
            dtg_hoaDon.Columns["MaKH"].HeaderText = "Mã khách hàng";
            dtg_hoaDon.Columns["MaNV"].HeaderText = "Mã nhân viên";
            dtg_hoaDon.Columns["MaVoucher"].HeaderText = "Mã voucher";
            dtg_hoaDon.Columns["KhachHang"].Visible = false;
            dtg_hoaDon.Columns["NhanVien"].Visible = false;
            dtg_hoaDon.Columns["Voucher"].Visible = false;
            dtg_hoaDon.Columns["DonHangChiTiets"].Visible = false;
        }
        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            LoadDonHang();
        }

        private void dtg_hoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maDh = dtg_hoaDon.Rows[e.RowIndex].Cells["MaDH"].Value.ToString();
                var _frm = new FormChiTietDonHang(maDh);
                _frm.ShowDialog();
            }
        }

        private void btn_xuatPDF_Click(object sender, EventArgs e)
        {
            if (dtg_hoaDon.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng để xuất PDF.");
                return;
            }
            string maDh = dtg_hoaDon.CurrentRow.Cells["MaDH"].Value.ToString();
            var donHang = _repo.GetById(maDh);
            var chiTiet = dhctRepo.GetByDonHangId(maDh);

            var invoice = new InvoiceDocument(donHang, chiTiet);

            using (var stream = new System.IO.MemoryStream())
            {
                invoice.GeneratePdf(stream);
                stream.Position = 0;

                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF file (*.pdf)|*.pdf";
                    saveFileDialog.FileName = $"HoaDon_{maDh}.pdf";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.File.WriteAllBytes(saveFileDialog.FileName, stream.ToArray());
                        MessageBox.Show("Xuất PDF thành công!");
                    }
                }
            }

        }

        private void dtg_hoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if( e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                lab_maHoaDon.Text = dtg_hoaDon.Rows[e.RowIndex].Cells["MaDH"].Value.ToString();
            }
        }
    }
}
