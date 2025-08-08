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
            SuspendLayout();
            // 
            // lblChaoMung
            // 
            lblChaoMung.AutoSize = true;
            lblChaoMung.Location = new Point(553, 68);
            lblChaoMung.Margin = new Padding(6, 0, 6, 0);
            lblChaoMung.Name = "lblChaoMung";
            lblChaoMung.Size = new Size(113, 32);
            lblChaoMung.TabIndex = 0;
            lblChaoMung.Text = "Welcome";
            // 
            // btnSanPham
            // 
            btnSanPham.Location = new Point(19, 143);
            btnSanPham.Margin = new Padding(6, 4, 6, 4);
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Size = new Size(247, 111);
            btnSanPham.TabIndex = 1;
            btnSanPham.Text = "SanPham";
            btnSanPham.UseVisualStyleBackColor = true;
            btnSanPham.Click += btnSanPham_Click;
            // 
            // btnBanHang
            // 
            btnBanHang.Location = new Point(19, 265);
            btnBanHang.Margin = new Padding(6, 4, 6, 4);
            btnBanHang.Name = "btnBanHang";
            btnBanHang.Size = new Size(247, 111);
            btnBanHang.TabIndex = 2;
            btnBanHang.Text = "BanHang";
            btnBanHang.UseVisualStyleBackColor = true;
            // 
            // btnThongKe
            // 
            btnThongKe.Location = new Point(19, 508);
            btnThongKe.Margin = new Padding(6, 4, 6, 4);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(247, 111);
            btnThongKe.TabIndex = 4;
            btnThongKe.Text = "ThongKe";
            btnThongKe.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Location = new Point(310, 145);
            panel1.Margin = new Padding(6, 4, 6, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(2299, 1011);
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
            btnNhanVien.Click += btnQuanLyNV_Click;
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
            btn_qlyNhanVien.Location = new Point(19, 383);
            btn_qlyNhanVien.Name = "btn_qlyNhanVien";
            btn_qlyNhanVien.Size = new Size(247, 118);
            btn_qlyNhanVien.TabIndex = 0;
            btn_qlyNhanVien.Text = "Quan ly nhan vien";
            btn_qlyNhanVien.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2884, 1523);
            Controls.Add(btn_qlyNhanVien);
            Controls.Add(panel1);
            Controls.Add(btnThongKe);
            Controls.Add(btnBanHang);
            Controls.Add(btnSanPham);
            Controls.Add(lblChaoMung);
            Margin = new Padding(6, 4, 6, 4);
            Name = "MainForm";
            Text = "MainForm";
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
    }
}