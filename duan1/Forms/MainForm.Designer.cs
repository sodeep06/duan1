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
            SuspendLayout();
            // 
            // lblChaoMung
            // 
            lblChaoMung.AutoSize = true;
            lblChaoMung.Location = new Point(341, 43);
            lblChaoMung.Name = "lblChaoMung";
            lblChaoMung.Size = new Size(71, 20);
            lblChaoMung.TabIndex = 0;
            lblChaoMung.Text = "Welcome";
            // 
            // btnSanPham
            // 
            btnSanPham.Location = new Point(12, 89);
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Size = new Size(152, 70);
            btnSanPham.TabIndex = 1;
            btnSanPham.Text = "SanPham";
            btnSanPham.UseVisualStyleBackColor = true;
            btnSanPham.Click += btnSanPham_Click;
            // 
            // btnBanHang
            // 
            btnBanHang.Location = new Point(12, 165);
            btnBanHang.Name = "btnBanHang";
            btnBanHang.Size = new Size(152, 70);
            btnBanHang.TabIndex = 2;
            btnBanHang.Text = "BanHang";
            btnBanHang.UseVisualStyleBackColor = true;
            // 
            // btnThongKe
            // 
            btnThongKe.Location = new Point(12, 317);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(152, 70);
            btnThongKe.TabIndex = 4;
            btnThongKe.Text = "ThongKe";
            btnThongKe.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Location = new Point(191, 90);
            panel1.Name = "panel1";
            panel1.Size = new Size(1415, 632);
            panel1.TabIndex = 5;
            // 
            // btnNhanVien
            // 
            btnNhanVien.Location = new Point(12, 241);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Size = new Size(152, 70);
            btnNhanVien.TabIndex = 6;
            btnNhanVien.Text = "QuanLyNV";
            btnNhanVien.UseVisualStyleBackColor = true;
            btnNhanVien.Click += btnQuanLyNV_Click;
            // 
            // btnVoucher
            // 
            btnVoucher.Location = new Point(12, 393);
            btnVoucher.Name = "btnVoucher";
            btnVoucher.Size = new Size(152, 70);
            btnVoucher.TabIndex = 7;
            btnVoucher.Text = "QLVoucher";
            btnVoucher.UseVisualStyleBackColor = true;
            btnVoucher.Click += btnQLVoucher_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1618, 714);
            Controls.Add(btnVoucher);
            Controls.Add(btnNhanVien);
            Controls.Add(panel1);
            Controls.Add(btnThongKe);
            Controls.Add(btnBanHang);
            Controls.Add(btnSanPham);
            Controls.Add(lblChaoMung);
            Name = "MainForm";
            Text = "MainForm";
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
    }
}