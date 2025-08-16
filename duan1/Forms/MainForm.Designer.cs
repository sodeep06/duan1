namespace duan1.Forms
{
    partial class MainForm
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
            lblChaoMung = new Label();
            btnSanPham = new Button();
            btnBanHang = new Button();
            btnThongKe = new Button();
            panel1 = new Panel();
            btnNhanVien = new Button();
            btnVoucher = new Button();
            btn_qlyNhanVien = new Button();
            btn_qlyVoucher = new Button();
            btn_hoaDon = new Button();
            SuspendLayout();
            // 
            // lblChaoMung
            // 
            lblChaoMung.AutoSize = true;
            lblChaoMung.Location = new Point(12, 57);
            lblChaoMung.Name = "lblChaoMung";
            lblChaoMung.Size = new Size(71, 20);
            lblChaoMung.TabIndex = 0;
            lblChaoMung.Text = "Welcome";
            // 
            // btnSanPham
            // 
            btnSanPham.Location = new Point(11, 89);
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Size = new Size(152, 69);
            btnSanPham.TabIndex = 1;
            btnSanPham.Text = "Sản Phẩm";
            btnSanPham.UseVisualStyleBackColor = true;
            btnSanPham.Click += btnSanPham_Click;
            // 
            // btnBanHang
            // 
            btnBanHang.Location = new Point(11, 165);
            btnBanHang.Name = "btnBanHang";
            btnBanHang.Size = new Size(152, 69);
            btnBanHang.TabIndex = 2;
            btnBanHang.Text = "Bán Hàng";
            btnBanHang.UseVisualStyleBackColor = true;
            btnBanHang.Click += btn_BanHang_Click;
            // 
            // btnThongKe
            // 
            btnThongKe.Location = new Point(11, 317);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(152, 69);
            btnThongKe.TabIndex = 4;
            btnThongKe.Text = "Thống Kê";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // panel1
            // 
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Location = new Point(178, 89);
            panel1.Name = "panel1";
            panel1.Size = new Size(2160, 1029);
            panel1.TabIndex = 5;
            // 
            // btnNhanVien
            // 
            btnNhanVien.Location = new Point(12, 241);
            btnNhanVien.Margin = new Padding(3, 2, 3, 2);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(152, 70);
            btnNhanVien.TabIndex = 6;
            btnNhanVien.Text = "QuanLyNV";
            btnNhanVien.UseVisualStyleBackColor = true;
            // 
            // btnVoucher
            // 
            btnVoucher.Location = new Point(0, 0);
            btnVoucher.Name = "btnVoucher";
            btnVoucher.Size = new Size(75, 23);
            btnVoucher.TabIndex = 0;
            // 
            // btn_qlyNhanVien
            // 
            btn_qlyNhanVien.Location = new Point(11, 240);
            btn_qlyNhanVien.Margin = new Padding(2, 1, 2, 1);
            btn_qlyNhanVien.Name = "btn_qlyNhanVien";
            btn_qlyNhanVien.Size = new Size(152, 73);
            btn_qlyNhanVien.TabIndex = 0;
            btn_qlyNhanVien.Text = "Quản Lý Nhân VIên";
            btn_qlyNhanVien.UseVisualStyleBackColor = true;
            btn_qlyNhanVien.Click += btn_qlyNhanVien_Click;
            // 
            // btn_qlyVoucher
            // 
            btn_qlyVoucher.Location = new Point(11, 392);
            btn_qlyVoucher.Name = "btn_qlyVoucher";
            btn_qlyVoucher.Size = new Size(152, 69);
            btn_qlyVoucher.TabIndex = 6;
            btn_qlyVoucher.Text = "Voucher";
            btn_qlyVoucher.UseVisualStyleBackColor = true;
            btn_qlyVoucher.Click += btn_qlyVoucher_Click;
            // 
            // btn_hoaDon
            // 
            btn_hoaDon.Location = new Point(11, 467);
            btn_hoaDon.Name = "btn_hoaDon";
            btn_hoaDon.Size = new Size(152, 69);
            btn_hoaDon.TabIndex = 7;
            btn_hoaDon.Text = "Hóa đơn";
            btn_hoaDon.UseVisualStyleBackColor = true;
            btn_hoaDon.Click += btn_hoaDon_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1561, 1045);
            Controls.Add(panel1);
            Controls.Add(btn_hoaDon);
            Controls.Add(btn_qlyVoucher);
            Controls.Add(btn_qlyNhanVien);
            Controls.Add(btnThongKe);
            Controls.Add(btnBanHang);
            Controls.Add(btnSanPham);
            Controls.Add(lblChaoMung);
            Name = "MainForm";
            Text = "Quản Lý";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblChaoMung;
        private Button btnSanPham;
        private Button btnBanHang;
        private Button btnThongKe;
        private Panel panel1;
        private Button btnNhanVien;
        private Button btnVoucher;
        private Button btn_qlyNhanVien;
        private Button btn_qlyVoucher;
        private Button btn_hoaDon;
    }
}