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
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Location = new Point(634, 45);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.Size = new Size(987, 660);
            dgvSanPham.TabIndex = 0;
            dgvSanPham.CellClick += dgvSanPham_CellClick;
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(121, 344);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(180, 27);
            txtMaSP.TabIndex = 1;
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(121, 302);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(180, 27);
            txtTenSP.TabIndex = 2;
            // 
            // txtGiaBan
            // 
            txtGiaBan.Location = new Point(121, 466);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(180, 27);
            txtGiaBan.TabIndex = 3;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(121, 387);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(180, 27);
            txtSoLuong.TabIndex = 4;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(121, 426);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(180, 27);
            txtMoTa.TabIndex = 5;
            // 
            // cbDanhMuc
            // 
            cbDanhMuc.FormattingEnabled = true;
            cbDanhMuc.Location = new Point(121, 503);
            cbDanhMuc.Name = "cbDanhMuc";
            cbDanhMuc.Size = new Size(180, 28);
            cbDanhMuc.TabIndex = 6;
            cbDanhMuc.SelectedIndexChanged += cbDanhMuc_SelectedIndexChanged;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(471, 370);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(471, 483);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(471, 429);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(471, 317);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 10;
            btnLamMoi.Text = "F5";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 347);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 11;
            label1.Text = "Mã Sản phẩm:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 390);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 12;
            label2.Text = "Số Lượng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 309);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 13;
            label3.Text = "Tên:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 429);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 14;
            label4.Text = "Mô Tả:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 469);
            label5.Name = "label5";
            label5.Size = new Size(34, 20);
            label5.TabIndex = 15;
            label5.Text = "Giá:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 503);
            label6.Name = "label6";
            label6.Size = new Size(79, 20);
            label6.TabIndex = 16;
            label6.Text = "Danh Mục:";
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(55, 19);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(510, 270);
            picHinhAnh.TabIndex = 17;
            picHinhAnh.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(577, 10);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(94, 29);
            btnChonAnh.TabIndex = 18;
            btnChonAnh.Text = "Thêm ảnh";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(755, 12);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(125, 27);
            txtTimKiem.TabIndex = 19;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(886, 10);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 20;
            btnTimKiem.Text = "Tìm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            btnTimKiem.KeyDown += txtTimKiem_KeyDown;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(677, 15);
            label7.Name = "label7";
            label7.Size = new Size(73, 20);
            label7.TabIndex = 21;
            label7.Text = "Tìm kiếm:";
            // 
            // FormSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1633, 717);
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