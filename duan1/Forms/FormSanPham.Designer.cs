namespace duan1.Forms
{
    partial class FormSanPham
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
            dgvSanPham = new DataGridView();
            txtMaSP = new TextBox();
            txtTenSP = new TextBox();
            txtGiaBan = new TextBox();
            txtSoLuong = new TextBox();
            txtMoTa = new TextBox();
            cbDanhMuc = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            picHinhAnh = new PictureBox();
            btnChonAnh = new Button();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            SuspendLayout();
            // 
            // dgvSanPham
            // 
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Location = new Point(555, 34);
            dgvSanPham.Margin = new Padding(3, 2, 3, 2);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.Size = new Size(580, 495);
            dgvSanPham.TabIndex = 0;
            dgvSanPham.CellClick += dgvSanPham_CellClick;
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(89, 258);
            txtMaSP.Margin = new Padding(3, 2, 3, 2);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(158, 23);
            txtMaSP.TabIndex = 1;
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(89, 226);
            txtTenSP.Margin = new Padding(3, 2, 3, 2);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(158, 23);
            txtTenSP.TabIndex = 2;
            // 
            // txtGiaBan
            // 
            txtGiaBan.Location = new Point(89, 350);
            txtGiaBan.Margin = new Padding(3, 2, 3, 2);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(158, 23);
            txtGiaBan.TabIndex = 3;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(89, 290);
            txtSoLuong.Margin = new Padding(3, 2, 3, 2);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(158, 23);
            txtSoLuong.TabIndex = 4;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(89, 320);
            txtMoTa.Margin = new Padding(3, 2, 3, 2);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(158, 23);
            txtMoTa.TabIndex = 5;
            // 
            // cbDanhMuc
            // 
            cbDanhMuc.FormattingEnabled = true;
            cbDanhMuc.Location = new Point(89, 377);
            cbDanhMuc.Margin = new Padding(3, 2, 3, 2);
            cbDanhMuc.Name = "cbDanhMuc";
            cbDanhMuc.Size = new Size(158, 23);
            cbDanhMuc.TabIndex = 6;
            cbDanhMuc.SelectedIndexChanged += cbDanhMuc_SelectedIndexChanged;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(412, 278);
            btnThem.Margin = new Padding(3, 2, 3, 2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(82, 22);
            btnThem.TabIndex = 7;
            btnThem.Text = "Them";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(412, 362);
            btnSua.Margin = new Padding(3, 2, 3, 2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(82, 22);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sua";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(412, 322);
            btnXoa.Margin = new Padding(3, 2, 3, 2);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(82, 22);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xoa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(412, 238);
            btnLamMoi.Margin = new Padding(3, 2, 3, 2);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(82, 22);
            btnLamMoi.TabIndex = 10;
            btnLamMoi.Text = "F5";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 260);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 11;
            label1.Text = "MaSP";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 292);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 12;
            label2.Text = "SoLuong";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 232);
            label3.Name = "label3";
            label3.Size = new Size(25, 15);
            label3.TabIndex = 13;
            label3.Text = "Ten";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 322);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 14;
            label4.Text = "MoTa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 352);
            label5.Name = "label5";
            label5.Size = new Size(24, 15);
            label5.TabIndex = 15;
            label5.Text = "Gia";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 377);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 16;
            label6.Text = "Danh Muc";
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(48, 14);
            picHinhAnh.Margin = new Padding(3, 2, 3, 2);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(446, 202);
            picHinhAnh.TabIndex = 17;
            picHinhAnh.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.BackColor = SystemColors.AppWorkspace;
            btnChonAnh.FlatStyle = FlatStyle.Flat;
            btnChonAnh.Location = new Point(89, 416);
            btnChonAnh.Margin = new Padding(3, 2, 3, 2);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(82, 54);
            btnChonAnh.TabIndex = 18;
            btnChonAnh.Text = "Thêm hình ảnh";
            btnChonAnh.UseVisualStyleBackColor = false;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(661, 9);
            txtTimKiem.Margin = new Padding(3, 2, 3, 2);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(213, 23);
            txtTimKiem.TabIndex = 19;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(880, 10);
            btnTimKiem.Margin = new Padding(3, 2, 3, 2);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(82, 22);
            btnTimKiem.TabIndex = 20;
            btnTimKiem.Text = "Tim`";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            btnTimKiem.KeyDown += txtTimKiem_KeyDown;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(592, 11);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 21;
            label7.Text = "Tim Kiem";
            // 
            // FormSanPham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1429, 538);
            Controls.Add(label7);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnChonAnh);
            Controls.Add(picHinhAnh);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(cbDanhMuc);
            Controls.Add(txtMoTa);
            Controls.Add(txtSoLuong);
            Controls.Add(txtGiaBan);
            Controls.Add(txtTenSP);
            Controls.Add(txtMaSP);
            Controls.Add(dgvSanPham);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormSanPham";
            Text = "FormSanPham";
            Load += FormSanPham_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSanPham;
        private TextBox txtMaSP;
        private TextBox txtTenSP;
        private TextBox txtGiaBan;
        private TextBox txtSoLuong;
        private TextBox txtMoTa;
        private ComboBox cbDanhMuc;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private PictureBox picHinhAnh;
        private Button btnChonAnh;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private Label label7;
    }
}