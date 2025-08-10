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
            ((System.ComponentModel.ISupportInitialize)dtg_sanPham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtg_khachHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtg_gioHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_soLuong).BeginInit();
            SuspendLayout();
            // 
            // dtg_sanPham
            // 
            dtg_sanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_sanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_sanPham.Location = new Point(26, 129);
            dtg_sanPham.Name = "dtg_sanPham";
            dtg_sanPham.ReadOnly = true;
            dtg_sanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_sanPham.Size = new Size(681, 150);
            dtg_sanPham.TabIndex = 0;
            dtg_sanPham.CellClick += dtg_sanPham_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 93);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 1;
            label1.Text = "Tìm kiếm";
            // 
            // txt_timKiem
            // 
            txt_timKiem.Location = new Point(88, 90);
            txt_timKiem.Name = "txt_timKiem";
            txt_timKiem.Size = new Size(619, 23);
            txt_timKiem.TabIndex = 2;
            // 
            // txt_timKhach
            // 
            txt_timKhach.Location = new Point(88, 310);
            txt_timKhach.Name = "txt_timKhach";
            txt_timKhach.Size = new Size(485, 23);
            txt_timKhach.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 313);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 4;
            label2.Text = "Tìm kiếm";
            // 
            // dtg_khachHang
            // 
            dtg_khachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_khachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_khachHang.Location = new Point(26, 350);
            dtg_khachHang.Name = "dtg_khachHang";
            dtg_khachHang.ReadOnly = true;
            dtg_khachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_khachHang.Size = new Size(681, 150);
            dtg_khachHang.TabIndex = 3;
            dtg_khachHang.CellClick += dtg_khachHang_CellClick;
            // 
            // btn_them
            // 
            btn_them.Location = new Point(579, 310);
            btn_them.Name = "btn_them";
            btn_them.Size = new Size(128, 23);
            btn_them.TabIndex = 6;
            btn_them.Text = "Thêm khách hàng";
            btn_them.UseVisualStyleBackColor = true;
            // 
            // dtg_gioHang
            // 
            dtg_gioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_gioHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_gioHang.Location = new Point(743, 269);
            dtg_gioHang.Name = "dtg_gioHang";
            dtg_gioHang.ReadOnly = true;
            dtg_gioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_gioHang.Size = new Size(595, 150);
            dtg_gioHang.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(743, 251);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 8;
            label3.Text = "Giỏ hàng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(938, 428);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 9;
            label4.Text = "Tổng tiền:";
            // 
            // txt_tongTien
            // 
            txt_tongTien.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_tongTien.ForeColor = Color.DarkOrchid;
            txt_tongTien.Location = new Point(1003, 425);
            txt_tongTien.Name = "txt_tongTien";
            txt_tongTien.PlaceholderText = "@@@";
            txt_tongTien.ReadOnly = true;
            txt_tongTien.Size = new Size(335, 25);
            txt_tongTien.TabIndex = 10;
            // 
            // btn_apDungVoucher
            // 
            btn_apDungVoucher.Location = new Point(1263, 479);
            btn_apDungVoucher.Name = "btn_apDungVoucher";
            btn_apDungVoucher.Size = new Size(75, 23);
            btn_apDungVoucher.TabIndex = 11;
            btn_apDungVoucher.Text = "Ap dung";
            btn_apDungVoucher.UseVisualStyleBackColor = true;
            btn_apDungVoucher.Click += btn_apDungVoucher_Click;
            // 
            // txt_voucher
            // 
            txt_voucher.Location = new Point(1003, 480);
            txt_voucher.Name = "txt_voucher";
            txt_voucher.Size = new Size(254, 23);
            txt_voucher.TabIndex = 12;
            txt_voucher.TextChanged += txt_voucher_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(941, 483);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 13;
            label5.Text = "Voucher: ";
            // 
            // btn_thanhToan
            // 
            btn_thanhToan.Location = new Point(938, 550);
            btn_thanhToan.Name = "btn_thanhToan";
            btn_thanhToan.Size = new Size(397, 77);
            btn_thanhToan.TabIndex = 14;
            btn_thanhToan.Text = "THANH TOAN";
            btn_thanhToan.UseVisualStyleBackColor = true;
            btn_thanhToan.Click += btn_thanhToan_Click;
            // 
            // lab_thongBao
            // 
            lab_thongBao.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_thongBao.ForeColor = Color.Red;
            lab_thongBao.Location = new Point(941, 515);
            lab_thongBao.Name = "lab_thongBao";
            lab_thongBao.Size = new Size(397, 23);
            lab_thongBao.TabIndex = 15;
            lab_thongBao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(770, 50);
            label6.Name = "label6";
            label6.Size = new Size(83, 15);
            label6.TabIndex = 16;
            label6.Text = "Tên sản phẩm:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(770, 146);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 17;
            label7.Text = "Đơn giá:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(770, 90);
            label8.Name = "label8";
            label8.Size = new Size(57, 15);
            label8.TabIndex = 18;
            label8.Text = "Số lượng:";
            // 
            // num_soLuong
            // 
            num_soLuong.BackColor = SystemColors.HotTrack;
            num_soLuong.BorderStyle = BorderStyle.None;
            num_soLuong.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            num_soLuong.ForeColor = Color.Yellow;
            num_soLuong.Location = new Point(869, 88);
            num_soLuong.Name = "num_soLuong";
            num_soLuong.Size = new Size(181, 19);
            num_soLuong.TabIndex = 19;
            // 
            // lab_tenSanPham
            // 
            lab_tenSanPham.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_tenSanPham.ForeColor = Color.Blue;
            lab_tenSanPham.Location = new Point(869, 48);
            lab_tenSanPham.Name = "lab_tenSanPham";
            lab_tenSanPham.Size = new Size(398, 17);
            lab_tenSanPham.TabIndex = 20;
            lab_tenSanPham.Text = "@@@";
            lab_tenSanPham.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lab_donGia
            // 
            lab_donGia.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_donGia.ForeColor = Color.Blue;
            lab_donGia.Location = new Point(869, 146);
            lab_donGia.Name = "lab_donGia";
            lab_donGia.Size = new Size(398, 17);
            lab_donGia.TabIndex = 21;
            lab_donGia.Text = "@@@";
            lab_donGia.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lab_tenKhachHang
            // 
            lab_tenKhachHang.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_tenKhachHang.ForeColor = Color.Blue;
            lab_tenKhachHang.Location = new Point(869, 191);
            lab_tenKhachHang.Name = "lab_tenKhachHang";
            lab_tenKhachHang.Size = new Size(398, 17);
            lab_tenKhachHang.TabIndex = 23;
            lab_tenKhachHang.Text = "@@@";
            lab_tenKhachHang.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(770, 191);
            label10.Name = "label10";
            label10.Size = new Size(93, 15);
            label10.TabIndex = 22;
            label10.Text = "Tên khách hàng:";
            // 
            // btn_themGioHang
            // 
            btn_themGioHang.BackColor = Color.FromArgb(255, 192, 192);
            btn_themGioHang.FlatStyle = FlatStyle.Flat;
            btn_themGioHang.Location = new Point(770, 211);
            btn_themGioHang.Name = "btn_themGioHang";
            btn_themGioHang.Size = new Size(280, 37);
            btn_themGioHang.TabIndex = 24;
            btn_themGioHang.Text = "Thêm vào giỏ hàng";
            btn_themGioHang.UseVisualStyleBackColor = false;
            btn_themGioHang.Click += btn_themGioHang_Click;
            // 
            // lab_soLuongTon
            // 
            lab_soLuongTon.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_soLuongTon.ForeColor = Color.Blue;
            lab_soLuongTon.Location = new Point(869, 119);
            lab_soLuongTon.Name = "lab_soLuongTon";
            lab_soLuongTon.Size = new Size(398, 17);
            lab_soLuongTon.TabIndex = 26;
            lab_soLuongTon.Text = "@@@";
            lab_soLuongTon.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(770, 119);
            label11.Name = "label11";
            label11.Size = new Size(32, 15);
            label11.TabIndex = 25;
            label11.Text = "Còn:";
            // 
            // lab_maSanPham
            // 
            lab_maSanPham.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_maSanPham.ForeColor = Color.ForestGreen;
            lab_maSanPham.Location = new Point(869, 29);
            lab_maSanPham.Name = "lab_maSanPham";
            lab_maSanPham.Size = new Size(398, 17);
            lab_maSanPham.TabIndex = 27;
            lab_maSanPham.Text = "id@";
            lab_maSanPham.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lab_maKhachHang
            // 
            lab_maKhachHang.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_maKhachHang.ForeColor = Color.ForestGreen;
            lab_maKhachHang.Location = new Point(869, 174);
            lab_maKhachHang.Name = "lab_maKhachHang";
            lab_maKhachHang.Size = new Size(398, 17);
            lab_maKhachHang.TabIndex = 28;
            lab_maKhachHang.Text = "id@";
            lab_maKhachHang.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lab_tenNhanVien
            // 
            lab_tenNhanVien.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lab_tenNhanVien.ForeColor = Color.FromArgb(255, 128, 255);
            lab_tenNhanVien.Location = new Point(101, 29);
            lab_tenNhanVien.Name = "lab_tenNhanVien";
            lab_tenNhanVien.Size = new Size(472, 26);
            lab_tenNhanVien.TabIndex = 29;
            lab_tenNhanVien.Text = "@test (tester)";
            lab_tenNhanVien.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.DimGray;
            label9.Location = new Point(26, 29);
            label9.Name = "label9";
            label9.Size = new Size(89, 26);
            label9.TabIndex = 30;
            label9.Text = "Xin chào,";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // llab_dangXuat
            // 
            llab_dangXuat.AutoSize = true;
            llab_dangXuat.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            llab_dangXuat.LinkColor = Color.FromArgb(255, 128, 128);
            llab_dangXuat.Location = new Point(619, 34);
            llab_dangXuat.Name = "llab_dangXuat";
            llab_dangXuat.Size = new Size(88, 21);
            llab_dangXuat.TabIndex = 31;
            llab_dangXuat.TabStop = true;
            llab_dangXuat.Text = "Đăng xuất";
            llab_dangXuat.LinkClicked += llab_dangXuat_LinkClicked;
            // 
            // lab_tenVoucher
            // 
            lab_tenVoucher.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_tenVoucher.ForeColor = Color.LightSeaGreen;
            lab_tenVoucher.Location = new Point(1003, 453);
            lab_tenVoucher.Name = "lab_tenVoucher";
            lab_tenVoucher.Size = new Size(254, 24);
            lab_tenVoucher.TabIndex = 32;
            lab_tenVoucher.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormBanHang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 648);
            Controls.Add(lab_tenVoucher);
            Controls.Add(llab_dangXuat);
            Controls.Add(lab_tenNhanVien);
            Controls.Add(label9);
            Controls.Add(lab_maKhachHang);
            Controls.Add(lab_maSanPham);
            Controls.Add(lab_soLuongTon);
            Controls.Add(label11);
            Controls.Add(btn_themGioHang);
            Controls.Add(lab_tenKhachHang);
            Controls.Add(label10);
            Controls.Add(lab_donGia);
            Controls.Add(lab_tenSanPham);
            Controls.Add(num_soLuong);
            Controls.Add(label8);
            Controls.Add(label7);
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
            Name = "FormBanHang";
            Text = "FormBanHang";
            WindowState = FormWindowState.Maximized;
            Load += FormBanHang_Load;
            ((System.ComponentModel.ISupportInitialize)dtg_sanPham).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtg_khachHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtg_gioHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_soLuong).EndInit();
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
    }
}