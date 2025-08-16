namespace duan1.Forms
{
    partial class FormBanHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dtg_sanPham = new DataGridView();
            label1 = new Label();
            txt_timKiem = new TextBox();
            txt_timKhach = new TextBox();
            label2 = new Label();
            dtg_khachHang = new DataGridView();
            btn_them = new Button();
            dtg_gioHang = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            txt_tongTien = new TextBox();
            btn_apDungVoucher = new Button();
            txt_voucher = new TextBox();
            label5 = new Label();
            btn_thanhToan = new Button();
            lab_thongBao = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            num_soLuong = new NumericUpDown();
            lab_tenSanPham = new Label();
            lab_donGia = new Label();
            lab_tenKhachHang = new Label();
            label10 = new Label();
            btn_themGioHang = new Button();
            lab_soLuongTon = new Label();
            label11 = new Label();
            lab_maSanPham = new Label();
            lab_maKhachHang = new Label();
            lab_tenNhanVien = new Label();
            label9 = new Label();
            llab_dangXuat = new LinkLabel();
            lab_tenVoucher = new Label();
            groupBox1 = new GroupBox();
            lab_thongBaoChon = new Label();
            label12 = new Label();
            cbo_choTietSanPham = new ComboBox();
            label13 = new Label();
            btn_xoaSanPham = new Button();
            num_soLuongSua = new NumericUpDown();
            btn_CapNhat = new Button();
            ((System.ComponentModel.ISupportInitialize)dtg_sanPham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtg_khachHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtg_gioHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_soLuong).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_soLuongSua).BeginInit();
            SuspendLayout();
            // 
            // dtg_sanPham
            // 
            dtg_sanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_sanPham.BackgroundColor = SystemColors.Control;
            dtg_sanPham.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtg_sanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtg_sanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_sanPham.Cursor = Cursors.Hand;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtg_sanPham.DefaultCellStyle = dataGridViewCellStyle2;
            dtg_sanPham.Location = new Point(30, 172);
            dtg_sanPham.Margin = new Padding(3, 4, 3, 4);
            dtg_sanPham.Name = "dtg_sanPham";
            dtg_sanPham.ReadOnly = true;
            dtg_sanPham.RowHeadersWidth = 51;
            dtg_sanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_sanPham.Size = new Size(778, 200);
            dtg_sanPham.TabIndex = 0;
            dtg_sanPham.CellClick += dtg_sanPham_CellClick;
            dtg_sanPham.CellDoubleClick += dtg_sanPham_CellDoubleClick;
            dtg_sanPham.CellEndEdit += dtg_sanPham_CellEndEdit;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 107);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 1;
            label1.Text = "Tìm kiếm";
            // 
            // txt_timKiem
            // 
            txt_timKiem.Location = new Point(101, 103);
            txt_timKiem.Margin = new Padding(3, 4, 3, 4);
            txt_timKiem.Name = "txt_timKiem";
            txt_timKiem.Size = new Size(707, 27);
            txt_timKiem.TabIndex = 2;
            txt_timKiem.TextChanged += txt_timKiem_TextChanged;
            // 
            // txt_timKhach
            // 
            txt_timKhach.Location = new Point(101, 413);
            txt_timKhach.Margin = new Padding(3, 4, 3, 4);
            txt_timKhach.Name = "txt_timKhach";
            txt_timKhach.Size = new Size(554, 27);
            txt_timKhach.TabIndex = 5;
            txt_timKhach.TextChanged += txt_timKhach_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 417);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 4;
            label2.Text = "Tìm kiếm";
            // 
            // dtg_khachHang
            // 
            dtg_khachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_khachHang.BackgroundColor = SystemColors.Control;
            dtg_khachHang.BorderStyle = BorderStyle.None;
            dtg_khachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_khachHang.Cursor = Cursors.Hand;
            dtg_khachHang.Location = new Point(30, 467);
            dtg_khachHang.Margin = new Padding(3, 4, 3, 4);
            dtg_khachHang.Name = "dtg_khachHang";
            dtg_khachHang.ReadOnly = true;
            dtg_khachHang.RowHeadersWidth = 51;
            dtg_khachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_khachHang.Size = new Size(778, 200);
            dtg_khachHang.TabIndex = 3;
            dtg_khachHang.CellClick += dtg_khachHang_CellClick;
            dtg_khachHang.CellEndEdit += dtg_sanPham_CellEndEdit;
            // 
            // btn_them
            // 
            btn_them.Location = new Point(662, 413);
            btn_them.Margin = new Padding(3, 4, 3, 4);
            btn_them.Name = "btn_them";
            btn_them.Size = new Size(146, 31);
            btn_them.TabIndex = 6;
            btn_them.Text = "Thêm khách hàng";
            btn_them.UseVisualStyleBackColor = true;
            btn_them.Click += btn_them_Click;
            // 
            // dtg_gioHang
            // 
            dtg_gioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_gioHang.BackgroundColor = SystemColors.Control;
            dtg_gioHang.BorderStyle = BorderStyle.None;
            dtg_gioHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_gioHang.Cursor = Cursors.Hand;
            dtg_gioHang.Location = new Point(863, 460);
            dtg_gioHang.Margin = new Padding(3, 4, 3, 4);
            dtg_gioHang.Name = "dtg_gioHang";
            dtg_gioHang.ReadOnly = true;
            dtg_gioHang.RowHeadersWidth = 51;
            dtg_gioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_gioHang.Size = new Size(680, 200);
            dtg_gioHang.TabIndex = 7;
            dtg_gioHang.CellClick += dtg_gioHang_CellClick;
            dtg_gioHang.CellEndEdit += dtg_sanPham_CellEndEdit;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(826, 436);
            label3.Name = "label3";
            label3.Size = new Size(96, 20);
            label3.TabIndex = 8;
            label3.Text = "Giỏ hàng của";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1034, 743);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 9;
            label4.Text = "Tổng tiền:";
            // 
            // txt_tongTien
            // 
            txt_tongTien.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_tongTien.ForeColor = Color.DarkOrchid;
            txt_tongTien.Location = new Point(1141, 734);
            txt_tongTien.Margin = new Padding(3, 4, 3, 4);
            txt_tongTien.Name = "txt_tongTien";
            txt_tongTien.PlaceholderText = "@@@";
            txt_tongTien.ReadOnly = true;
            txt_tongTien.Size = new Size(382, 29);
            txt_tongTien.TabIndex = 10;
            // 
            // btn_apDungVoucher
            // 
            btn_apDungVoucher.Location = new Point(1438, 778);
            btn_apDungVoucher.Margin = new Padding(3, 4, 3, 4);
            btn_apDungVoucher.Name = "btn_apDungVoucher";
            btn_apDungVoucher.Size = new Size(86, 31);
            btn_apDungVoucher.TabIndex = 11;
            btn_apDungVoucher.Text = "Ap dung";
            btn_apDungVoucher.UseVisualStyleBackColor = true;
            btn_apDungVoucher.Click += btn_apDungVoucher_Click;
            // 
            // txt_voucher
            // 
            txt_voucher.Location = new Point(1142, 780);
            txt_voucher.Margin = new Padding(3, 4, 3, 4);
            txt_voucher.Name = "txt_voucher";
            txt_voucher.Size = new Size(290, 27);
            txt_voucher.TabIndex = 12;
            txt_voucher.TextChanged += txt_voucher_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1040, 783);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 13;
            label5.Text = "Voucher: ";
            // 
            // btn_thanhToan
            // 
            btn_thanhToan.BackColor = Color.Gainsboro;
            btn_thanhToan.FlatStyle = FlatStyle.Flat;
            btn_thanhToan.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_thanhToan.Location = new Point(830, 752);
            btn_thanhToan.Margin = new Padding(3, 4, 3, 4);
            btn_thanhToan.Name = "btn_thanhToan";
            btn_thanhToan.Size = new Size(182, 36);
            btn_thanhToan.TabIndex = 14;
            btn_thanhToan.Text = "THANH TOÁN NGAY";
            btn_thanhToan.UseVisualStyleBackColor = false;
            btn_thanhToan.Click += btn_thanhToan_Click;
            // 
            // lab_thongBao
            // 
            lab_thongBao.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_thongBao.ForeColor = Color.Red;
            lab_thongBao.Location = new Point(1070, 821);
            lab_thongBao.Name = "lab_thongBao";
            lab_thongBao.Size = new Size(454, 31);
            lab_thongBao.TabIndex = 15;
            lab_thongBao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(880, 67);
            label6.Name = "label6";
            label6.Size = new Size(103, 20);
            label6.TabIndex = 16;
            label6.Text = "Tên sản phẩm:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(17, 156);
            label7.Name = "label7";
            label7.Size = new Size(65, 20);
            label7.TabIndex = 17;
            label7.Text = "Đơn giá:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(880, 120);
            label8.Name = "label8";
            label8.Size = new Size(72, 20);
            label8.TabIndex = 18;
            label8.Text = "Số lượng:";
            // 
            // num_soLuong
            // 
            num_soLuong.BackColor = SystemColors.HotTrack;
            num_soLuong.BorderStyle = BorderStyle.None;
            num_soLuong.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            num_soLuong.ForeColor = Color.Yellow;
            num_soLuong.Location = new Point(254, 92);
            num_soLuong.Margin = new Padding(3, 4, 3, 4);
            num_soLuong.Name = "num_soLuong";
            num_soLuong.Size = new Size(207, 23);
            num_soLuong.TabIndex = 19;
            // 
            // lab_tenSanPham
            // 
            lab_tenSanPham.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_tenSanPham.ForeColor = Color.Blue;
            lab_tenSanPham.Location = new Point(993, 64);
            lab_tenSanPham.Name = "lab_tenSanPham";
            lab_tenSanPham.Size = new Size(455, 23);
            lab_tenSanPham.TabIndex = 20;
            lab_tenSanPham.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lab_donGia
            // 
            lab_donGia.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_donGia.ForeColor = Color.Blue;
            lab_donGia.Location = new Point(130, 156);
            lab_donGia.Name = "lab_donGia";
            lab_donGia.Size = new Size(455, 23);
            lab_donGia.TabIndex = 21;
            lab_donGia.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lab_tenKhachHang
            // 
            lab_tenKhachHang.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_tenKhachHang.ForeColor = Color.Blue;
            lab_tenKhachHang.Location = new Point(928, 433);
            lab_tenKhachHang.Name = "lab_tenKhachHang";
            lab_tenKhachHang.Size = new Size(455, 23);
            lab_tenKhachHang.TabIndex = 23;
            lab_tenKhachHang.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(822, 411);
            label10.Name = "label10";
            label10.Size = new Size(112, 20);
            label10.TabIndex = 22;
            label10.Text = "Mã khách hàng:";
            // 
            // btn_themGioHang
            // 
            btn_themGioHang.BackColor = Color.FromArgb(255, 192, 192);
            btn_themGioHang.FlatStyle = FlatStyle.Flat;
            btn_themGioHang.Location = new Point(977, 357);
            btn_themGioHang.Margin = new Padding(3, 4, 3, 4);
            btn_themGioHang.Name = "btn_themGioHang";
            btn_themGioHang.Size = new Size(320, 49);
            btn_themGioHang.TabIndex = 24;
            btn_themGioHang.Text = "Thêm vào giỏ hàng";
            btn_themGioHang.UseVisualStyleBackColor = false;
            btn_themGioHang.Click += btn_themGioHang_Click;
            // 
            // lab_soLuongTon
            // 
            lab_soLuongTon.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_soLuongTon.ForeColor = Color.Blue;
            lab_soLuongTon.Location = new Point(130, 131);
            lab_soLuongTon.Name = "lab_soLuongTon";
            lab_soLuongTon.Size = new Size(455, 23);
            lab_soLuongTon.TabIndex = 26;
            lab_soLuongTon.TextAlign = ContentAlignment.MiddleLeft;
            lab_soLuongTon.Visible = false;

            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(17, 131);
            label11.Name = "label11";
            label11.Size = new Size(38, 20);
            label11.TabIndex = 25;
            label11.Text = "Còn:";
            label11.Visible = false;
            // 
            // lab_maSanPham
            // 
            lab_maSanPham.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_maSanPham.ForeColor = Color.ForestGreen;
            lab_maSanPham.Location = new Point(993, 39);
            lab_maSanPham.Name = "lab_maSanPham";
            lab_maSanPham.Size = new Size(455, 23);
            lab_maSanPham.TabIndex = 27;
            lab_maSanPham.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lab_maKhachHang
            // 
            lab_maKhachHang.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_maKhachHang.ForeColor = Color.ForestGreen;
            lab_maKhachHang.Location = new Point(957, 411);
            lab_maKhachHang.Name = "lab_maKhachHang";
            lab_maKhachHang.Size = new Size(455, 23);
            lab_maKhachHang.TabIndex = 28;
            lab_maKhachHang.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lab_tenNhanVien
            // 
            lab_tenNhanVien.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lab_tenNhanVien.ForeColor = Color.FromArgb(255, 128, 255);
            lab_tenNhanVien.Location = new Point(115, 39);
            lab_tenNhanVien.Name = "lab_tenNhanVien";
            lab_tenNhanVien.Size = new Size(539, 35);
            lab_tenNhanVien.TabIndex = 29;
            lab_tenNhanVien.Text = "@test (tester)";
            lab_tenNhanVien.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.DimGray;
            label9.Location = new Point(30, 39);
            label9.Name = "label9";
            label9.Size = new Size(102, 35);
            label9.TabIndex = 30;
            label9.Text = "Xin chào,";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // llab_dangXuat
            // 
            llab_dangXuat.AutoSize = true;
            llab_dangXuat.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            llab_dangXuat.LinkColor = Color.FromArgb(255, 128, 128);
            llab_dangXuat.Location = new Point(707, 45);
            llab_dangXuat.Name = "llab_dangXuat";
            llab_dangXuat.Size = new Size(112, 28);
            llab_dangXuat.TabIndex = 31;
            llab_dangXuat.TabStop = true;
            // 
            // lab_tenVoucher
            // 
            lab_tenVoucher.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_tenVoucher.ForeColor = Color.LightSeaGreen;
            lab_tenVoucher.Location = new Point(1201, 698);
            lab_tenVoucher.Name = "lab_tenVoucher";
            lab_tenVoucher.Size = new Size(290, 32);
            lab_tenVoucher.TabIndex = 32;
            lab_tenVoucher.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(lab_thongBaoChon);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(cbo_choTietSanPham);
            groupBox1.Controls.Add(lab_soLuongTon);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(lab_donGia);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(num_soLuong);
            groupBox1.Location = new Point(863, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(661, 333);
            groupBox1.TabIndex = 33;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            // 
            // lab_thongBaoChon
            // 
            lab_thongBaoChon.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_thongBaoChon.ForeColor = Color.Red;
            lab_thongBaoChon.Location = new Point(387, 249);
            lab_thongBaoChon.Name = "lab_thongBaoChon";
            lab_thongBaoChon.Size = new Size(254, 31);
            lab_thongBaoChon.TabIndex = 34;
            lab_thongBaoChon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(17, 253);
            label12.Name = "label12";
            label12.Size = new Size(101, 20);
            label12.TabIndex = 34;
            label12.Text = "Loại (Nhanh): ";
            // 
            // cbo_choTietSanPham
            // 
            cbo_choTietSanPham.FormattingEnabled = true;
            cbo_choTietSanPham.Location = new Point(130, 249);
            cbo_choTietSanPham.Margin = new Padding(3, 4, 3, 4);
            cbo_choTietSanPham.Name = "cbo_choTietSanPham";
            cbo_choTietSanPham.Size = new Size(250, 28);
            cbo_choTietSanPham.TabIndex = 0;
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.RosyBrown;
            label13.Location = new Point(30, 137);
            label13.Name = "label13";
            label13.Size = new Size(778, 31);
            label13.TabIndex = 35;
            label13.Text = "Mẹo: Bạn có thể double click để chọn biến thể của sản phẩm";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn_xoaSanPham
            // 
            btn_xoaSanPham.BackColor = Color.Gainsboro;
            btn_xoaSanPham.FlatStyle = FlatStyle.Flat;
            btn_xoaSanPham.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_xoaSanPham.Location = new Point(1417, 417);
            btn_xoaSanPham.Margin = new Padding(3, 4, 3, 4);
            btn_xoaSanPham.Name = "btn_xoaSanPham";
            btn_xoaSanPham.Size = new Size(106, 36);
            btn_xoaSanPham.TabIndex = 36;
            btn_xoaSanPham.Text = "Xóa";
            btn_xoaSanPham.UseVisualStyleBackColor = false;
            btn_xoaSanPham.Click += btn_xoaSanPham_Click;
            // 
            // num_soLuongSua
            // 
            num_soLuongSua.BackColor = SystemColors.HotTrack;
            num_soLuongSua.BorderStyle = BorderStyle.None;
            num_soLuongSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            num_soLuongSua.ForeColor = Color.Yellow;
            num_soLuongSua.Location = new Point(1503, 372);
            num_soLuongSua.Margin = new Padding(3, 4, 3, 4);
            num_soLuongSua.Name = "num_soLuongSua";
            num_soLuongSua.Size = new Size(85, 23);
            num_soLuongSua.TabIndex = 37;
            // 
            // btn_CapNhat
            // 
            btn_CapNhat.BackColor = Color.Gainsboro;
            btn_CapNhat.FlatStyle = FlatStyle.Flat;
            btn_CapNhat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_CapNhat.Location = new Point(1417, 371);
            btn_CapNhat.Margin = new Padding(3, 4, 3, 4);
            btn_CapNhat.Name = "btn_CapNhat";
            btn_CapNhat.Size = new Size(106, 36);
            btn_CapNhat.TabIndex = 38;
            btn_CapNhat.Text = "Cập nhật";
            btn_CapNhat.UseVisualStyleBackColor = false;
            btn_CapNhat.Click += btn_CapNhat_Click;
            // 
            // FormBanHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1566, 864);
            ControlBox = false;
            Controls.Add(btn_CapNhat);
            Controls.Add(num_soLuongSua);
            Controls.Add(btn_xoaSanPham);
            Controls.Add(label13);
            Controls.Add(lab_maKhachHang);
            Controls.Add(label10);
            Controls.Add(lab_tenVoucher);
            Controls.Add(llab_dangXuat);
            Controls.Add(lab_tenNhanVien);
            Controls.Add(label9);
            Controls.Add(lab_maSanPham);
            Controls.Add(btn_themGioHang);
            Controls.Add(lab_tenKhachHang);
            Controls.Add(lab_tenSanPham);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(lab_thongBao);
            Controls.Add(btn_thanhToan);
            Controls.Add(label5);
            Controls.Add(txt_voucher);
            Controls.Add(btn_apDungVoucher);
            Controls.Add(txt_tongTien);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dtg_gioHang);
            Controls.Add(btn_them);
            Controls.Add(txt_timKhach);
            Controls.Add(label2);
            Controls.Add(dtg_khachHang);
            Controls.Add(txt_timKiem);
            Controls.Add(label1);
            Controls.Add(dtg_sanPham);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormBanHang";
            Text = "Bán Hàng";
            WindowState = FormWindowState.Maximized;
            Load += FormBanHang_Load;
            ((System.ComponentModel.ISupportInitialize)dtg_sanPham).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtg_khachHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtg_gioHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_soLuong).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_soLuongSua).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtg_sanPham;
        private Label label1;
        private TextBox txt_timKiem;
        private TextBox txt_timKhach;
        private Label label2;
        private DataGridView dtg_khachHang;
        private Button btn_them;
        private DataGridView dtg_gioHang;
        private Label label3;
        private Label label4;
        private TextBox txt_tongTien;
        private Button btn_apDungVoucher;
        private TextBox txt_voucher;
        private Label label5;
        private Button btn_thanhToan;
        private Label lab_thongBao;
        private Label label6;
        private Label label7;
        private Label label8;
        private NumericUpDown num_soLuong;
        private Label lab_tenSanPham;
        private Label lab_donGia;
        private Label lab_tenKhachHang;
        private Label label10;
        private Button btn_themGioHang;
        private Label lab_soLuongTon;
        private Label label11;
        private Label lab_maSanPham;
        private Label lab_maKhachHang;
        private Label lab_tenNhanVien;
        private Label label9;
        private LinkLabel llab_dangXuat;
        private Label lab_tenVoucher;
        private GroupBox groupBox1;
        private ComboBox cbo_choTietSanPham;
        private Label label12;
        private Label lab_thongBaoChon;
        private Label label13;
        private Button btn_xoaSanPham;
        private NumericUpDown num_soLuongSua;
        private Button btn_CapNhat;
    }
}