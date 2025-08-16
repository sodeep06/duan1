using duan1.Repositories;
using duan1.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace duan1.Forms
{
    public partial class FormHoaDon : Form
    {
        private readonly DonHangRepo _repo = new DonHangRepo();
        private Button _btnExport;

        public FormHoaDon()
        {
            InitializeComponent();

            // Tạo panel top bar chứa cả tiêu đề + nút Export
            var topBar = new Panel { Dock = DockStyle.Top, Height = 56, BackColor = Color.White };
            Controls.Add(topBar);

            // Label tiêu đề
            _title = new Label
            {
                Text = "Hóa đơn",
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 22f, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#5B8DEF"),
                Location = new Point(16, (topBar.Height - 32) / 2)
            };

            // Nút Export
            _btnExport = new Button
            {
                Text = "Xuất PDF",
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            _btnExport.Click += btnExportPdf_Click;
            // đặt tạm, sẽ canh lại khi resize
            _btnExport.Location = new Point(topBar.Width - _btnExport.Width - 16, (topBar.Height - _btnExport.Height) / 2);

            topBar.Controls.Add(_title);
            topBar.Controls.Add(_btnExport);

            // Cập nhật vị trí nút khi resize form
            topBar.Resize += (_, __) =>
            {
                _btnExport.Left = topBar.Width - _btnExport.Width - 16;
                _btnExport.Top = (topBar.Height - _btnExport.Height) / 2;
            };

            // Event load dữ liệu
            dtg_hoaDon.DataBindingComplete += (_, __) => { SetupHoaDonGrid(); };
        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            LoadDonHang();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ApplyTheme();
            SetupHoaDonGrid();

            // canh lại vị trí nút export theo kích thước form
            _btnExport.Location = new Point(ClientSize.Width - _btnExport.Width - 16, 10);
        }

        // ================== LOAD & THEME ==================
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

            if (dtg_hoaDon.Columns.Contains("KhachHang")) dtg_hoaDon.Columns["KhachHang"].Visible = false;
            if (dtg_hoaDon.Columns.Contains("NhanVien")) dtg_hoaDon.Columns["NhanVien"].Visible = false;
            if (dtg_hoaDon.Columns.Contains("Voucher")) dtg_hoaDon.Columns["Voucher"].Visible = false;
            if (dtg_hoaDon.Columns.Contains("DonHangChiTiets")) dtg_hoaDon.Columns["DonHangChiTiets"].Visible = false;
        }

        private void dtg_hoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maDh = dtg_hoaDon.Rows[e.RowIndex].Cells["MaDH"].Value?.ToString();
                if (string.IsNullOrWhiteSpace(maDh)) return;
                var _frm = new FormChiTietDonHang(maDh);
                _frm.ShowDialog();
            }
        }

        // ===== Theme / Helpers =====
        private Label _title;
        private void ApplyTheme()
        {
            var bg = ColorTranslator.FromHtml("#F6F7FB");
            var text = ColorTranslator.FromHtml("#2B2F33");
            var primary = ColorTranslator.FromHtml("#5B8DEF");

            BackColor = bg;
            Font = new Font("Segoe UI", 9.5f);
            ForeColor = text;

            EnsureTitleControl();
            _title.Text = "Hóa đơn";
            _title.ForeColor = primary;
            _title.Font = new Font("Segoe UI Semibold", 22f, FontStyle.Bold);
            _title.Height = 56;
            _title.Dock = DockStyle.Top;
            _title.TextAlign = ContentAlignment.MiddleCenter;

            StyleGrid(dtg_hoaDon);
            SetupHoaDonGrid();
        }

        private void EnsureTitleControl()
        {
            if (_title != null && !_title.IsDisposed) return;
            _title = Controls.Find("lblTitle", true).FirstOrDefault() as Label;
            if (_title == null)
            {
                _title = new Label { Name = "lblTitle" };
                Controls.Add(_title);
                Controls.SetChildIndex(_title, 0);
            }
        }

        private void StyleGrid(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EEF2FF");
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#1F2937");
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#111827");
            dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F9FAFB");
            dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#DBEAFE");
            dgv.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#111827");

            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            // Double-buffer
            var pi = typeof(DataGridView).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            pi?.SetValue(dgv, true, null);

            if (dgv.Columns.Contains("NgayDat"))
            {
                dgv.Columns["NgayDat"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dgv.Columns["NgayDat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgv.Columns.Contains("TongTien"))
            {
                dgv.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dgv.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void SetupHoaDonGrid()
        {
            if (dtg_hoaDon == null || dtg_hoaDon.Columns.Count == 0) return;

            if (dtg_hoaDon.Columns["MaDH"] != null) dtg_hoaDon.Columns["MaDH"].HeaderText = "Mã đơn hàng";
            if (dtg_hoaDon.Columns["NgayDat"] != null) dtg_hoaDon.Columns["NgayDat"].HeaderText = "Ngày đặt";
            if (dtg_hoaDon.Columns["TongTien"] != null) dtg_hoaDon.Columns["TongTien"].HeaderText = "Tổng tiền";
            if (dtg_hoaDon.Columns["TrangThai"] != null) dtg_hoaDon.Columns["TrangThai"].HeaderText = "Trạng thái";
            if (dtg_hoaDon.Columns["MaKH"] != null) dtg_hoaDon.Columns["MaKH"].HeaderText = "Mã KH";
            if (dtg_hoaDon.Columns["MaNV"] != null) dtg_hoaDon.Columns["MaNV"].HeaderText = "Mã NV";
            if (dtg_hoaDon.Columns["MaVoucher"] != null) dtg_hoaDon.Columns["MaVoucher"].HeaderText = "Mã voucher";

            if (dtg_hoaDon.Columns.Contains("KhachHang")) dtg_hoaDon.Columns["KhachHang"].Visible = false;
            if (dtg_hoaDon.Columns.Contains("NhanVien")) dtg_hoaDon.Columns["NhanVien"].Visible = false;
            if (dtg_hoaDon.Columns.Contains("Voucher")) dtg_hoaDon.Columns["Voucher"].Visible = false;
            if (dtg_hoaDon.Columns.Contains("DonHangChiTiets")) dtg_hoaDon.Columns["DonHangChiTiets"].Visible = false;

            if (dtg_hoaDon.Columns.Contains("NgayDat"))
            {
                dtg_hoaDon.Columns["NgayDat"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                dtg_hoaDon.Columns["NgayDat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dtg_hoaDon.Columns.Contains("TongTien"))
            {
                dtg_hoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dtg_hoaDon.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dtg_hoaDon.ClearSelection();
        }

        // ================== XUẤT PDF (không cần NuGet) ==================
        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (dtg_hoaDon.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn 1 hóa đơn trước.");
                return;
            }

            var maDH = dtg_hoaDon.CurrentRow.Cells["MaDH"]?.Value?.ToString();
            if (string.IsNullOrWhiteSpace(maDH))
            {
                MessageBox.Show("Không lấy được mã đơn hàng.");
                return;
            }

            // Lấy hóa đơn đầy đủ chi tiết
            var dh = _repo.GetAllWithDetails().FirstOrDefault(x => x.MaDH == maDH);
            if (dh == null)
            {
                MessageBox.Show("Không tìm thấy dữ liệu hóa đơn.");
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "PDF file (*.pdf)|*.pdf",
                FileName = $"HoaDon_{maDH}.pdf"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                PrintHoaDonToPdf(dh, sfd.FileName);
                MessageBox.Show("Đã xuất PDF thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xuất PDF thất bại.\n" + ex.Message);
            }
        }

        //private void PrintHoaDonToPdf(DonHang dh, string outputPath)
        //{
        //    // Sử dụng máy in “Microsoft Print to PDF”
        //    var pd = new PrintDocument();
        //    pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
        //    pd.PrinterSettings.PrintToFile = true;
        //    pd.PrinterSettings.PrintFileName = outputPath;

        //    int detailIndex = 0;   // phân trang
        //    pd.PrintPage += (s, e) =>
        //    {
        //        var g = e.Graphics;
        //        var bounds = e.MarginBounds;
        //        float left = bounds.Left;
        //        float right = bounds.Right;

        //        var title = new Font("Segoe UI", 14, FontStyle.Bold);
        //        var f = new Font("Segoe UI", 10);
        //        var fb = new Font("Segoe UI", 10, FontStyle.Bold);

        //        float y = bounds.Top;

        //        // Header
        //        g.DrawString("HÓA ĐƠN BÁN HÀNG", title, Brushes.Black, left, y);
        //        y += 34;
        //        g.DrawString($"Mã đơn: {dh.MaDH}", f, Brushes.Black, left, y);
        //        g.DrawString($"Ngày: {dh.NgayDat:dd/MM/yyyy HH:mm}", f, Brushes.Black, right - 250, y);
        //        y += 22;
        //        g.DrawString($"Khách hàng: {dh?.KhachHang?.HoTen ?? dh?.MaKH ?? "-"}", f, Brushes.Black, left, y);
        //        y += 22;
        //        g.DrawString($"Nhân viên: {dh?.NhanVien?.HoTen ?? dh?.MaNV ?? "-"}", f, Brushes.Black, left, y);
        //        y += 30;

        //        // Bảng chi tiết
        //        float[] colW = { 40, 280, 80, 100, 120 }; // STT, Tên SP, SL, Đơn giá, Thành tiền
        //        string[] head = { "STT", "Sản phẩm", "SL", "Đơn giá", "Thành tiền" };

        //        float x = left;
        //        for (int i = 0; i < head.Length; i++)
        //        {
        //            g.DrawString(head[i], fb, Brushes.Black, x, y);
        //            x += colW[i];
        //        }
        //        y += 20;
        //        g.DrawLine(Pens.Black, left, y, right, y);
        //        y += 8;

        //        int stt = 0;
        //        while (detailIndex < dh.DonHangChiTiets.Count)
        //        {
        //            var ct = dh.DonHangChiTiets.ElementAt(detailIndex);
        //            string tenSP = ct?.MaSPCT ?? "-"; // nếu không có navigation tên SP, dùng mã
        //            int soLuong = ct?.SoLuong ?? 0;
        //            decimal donGia = ct?.DonGia ?? 0m;
        //            decimal thanhTien = donGia * soLuong;

        //            x = left;
        //            g.DrawString((++stt).ToString(), f, Brushes.Black, x, y); x += colW[0];
        //            g.DrawString(tenSP, f, Brushes.Black, x, y); x += colW[1];
        //            g.DrawString(soLuong.ToString(), f, Brushes.Black, x, y); x += colW[2];
        //            g.DrawString(donGia.ToString("N0"), f, Brushes.Black, x, y); x += colW[3];
        //            g.DrawString(thanhTien.ToString("N0"), f, Brushes.Black, x, y);

        //            y += 20;

        //            // gần chạm đáy trang -> sang trang
        //            if (y > bounds.Bottom - 100)
        //            {
        //                e.HasMorePages = true;
        //                return;
        //            }

        //            detailIndex++;
        //        }

        //        // Tổng cộng
        //        y += 10;
        //        g.DrawLine(Pens.Black, left, y, right, y);
        //        y += 10;
        //        g.DrawString($"Tổng cộng: {dh.TongTien:N0} đ", new Font("Segoe UI", 11, FontStyle.Bold), Brushes.Black, right - 260, y);
        //        y += 40;
        //        g.DrawString("Cảm ơn quý khách!", f, Brushes.Black, left, y);

        //        e.HasMorePages = false;
        //    };

        //    pd.Print();
        //    pd.Dispose();
        //}
        private void PrintHoaDonToPdf(DonHang dh, string outputPath)
        {
            var pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            pd.PrinterSettings.PrintToFile = true;
            pd.PrinterSettings.PrintFileName = outputPath;

            int detailIndex = 0;
            pd.PrintPage += (s, e) =>
            {
                var g = e.Graphics;
                var bounds = e.MarginBounds;
                float left = bounds.Left;
                float right = bounds.Right;

                var title = new Font("Segoe UI", 14, FontStyle.Bold);
                var f = new Font("Segoe UI", 10);
                var fb = new Font("Segoe UI", 10, FontStyle.Bold);

                float y = bounds.Top;

                // ===== Header =====
                g.DrawString("HÓA ĐƠN BÁN HÀNG", title, Brushes.Black, left, y);
                y += 34;
                g.DrawString($"Mã đơn: {dh.MaDH}", f, Brushes.Black, left, y);
                g.DrawString($"Ngày: {dh.NgayDat:dd/MM/yyyy HH:mm}", f, Brushes.Black, right - 250, y);
                y += 22;
                g.DrawString($"Khách hàng: {dh?.KhachHang?.HoTen ?? dh?.MaKH ?? "-"}", f, Brushes.Black, left, y);
                y += 22;
                g.DrawString($"Nhân viên: {dh?.NhanVien?.HoTen ?? dh?.MaNV ?? "-"}", f, Brushes.Black, left, y);
                y += 22;

                // Voucher (chỉ hiển thị mã)
                string voucherCode = string.IsNullOrWhiteSpace(dh?.MaVoucher) ? "-" : dh.MaVoucher;
                g.DrawString($"Voucher: {voucherCode}", f, Brushes.Black, left, y);
                y += 30;

                // ===== Bảng chi tiết =====
                float[] colW = { 40, 280, 80, 100, 120 }; // STT, Tên SP, SL, Đơn giá, Thành tiền
                string[] head = { "STT", "Sản phẩm", "SL", "Đơn giá", "Thành tiền" };

                float x = left;
                for (int i = 0; i < head.Length; i++)
                {
                    g.DrawString(head[i], fb, Brushes.Black, x, y);
                    x += colW[i];
                }
                y += 20;
                g.DrawLine(Pens.Black, left, y, right, y);
                y += 8;

                int stt = 0;
                while (detailIndex < dh.DonHangChiTiets.Count)
                {
                    var ct = dh.DonHangChiTiets.ElementAt(detailIndex);
                    string tenSP = ct?.MaSPCT ?? "-"; // nếu không có tên, in mã
                    int soLuong = ct?.SoLuong ?? 0;
                    decimal donGia = ct?.DonGia ?? 0m;
                    decimal thanhTien = donGia * soLuong;

                    x = left;
                    g.DrawString((++stt).ToString(), f, Brushes.Black, x, y); x += colW[0];
                    g.DrawString(tenSP, f, Brushes.Black, x, y); x += colW[1];
                    g.DrawString(soLuong.ToString(), f, Brushes.Black, x, y); x += colW[2];
                    g.DrawString(donGia.ToString("N0"), f, Brushes.Black, x, y); x += colW[3];
                    g.DrawString(thanhTien.ToString("N0"), f, Brushes.Black, x, y);

                    y += 20;

                    if (y > bounds.Bottom - 120)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    detailIndex++;
                }

                // ===== Tổng kết =====
                decimal tamTinh = dh.DonHangChiTiets.Sum(ct => (ct?.DonGia ?? 0m) * (ct?.SoLuong ?? 0));
                y += 10;
                g.DrawLine(Pens.Black, left, y, right, y);
                y += 10;

                // Tạm tính
                g.DrawString($"Tạm tính: {tamTinh:N0} đ", f, Brushes.Black, right - 260, y);
                y += 20;

                // Mã voucher (nhắc lại ở phần tổng kết)
                g.DrawString($"Mã voucher: {voucherCode}", f, Brushes.Black, right - 260, y);
                y += 24;

                // Tổng cộng (đã có/không có voucher tuỳ dữ liệu của bạn)
                g.DrawString($"Tổng cộng: {dh.TongTien:N0} đ", new Font("Segoe UI", 11, FontStyle.Bold), Brushes.Black, right - 260, y);
                y += 36;

                g.DrawString("Cảm ơn quý khách đã mua hàng tại DTHS1!", f, Brushes.Black, left, y);
                e.HasMorePages = false;
            };

            pd.Print();
            pd.Dispose();
        }


    }
}
