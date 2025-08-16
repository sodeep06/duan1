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
            label8 = new Label();
            txtKichThuoc = new TextBox();
            txtMauSac = new TextBox();
            label9 = new Label();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvSanPham
            // 
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Location = new Point(634, 61);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.Size = new Size(987, 660);
            dgvSanPham.TabIndex = 0;
            dgvSanPham.CellClick += dgvSanPham_CellClick;
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(113, 362);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(180, 27);
            txtMaSP.TabIndex = 1;
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(113, 320);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(180, 27);
            txtTenSP.TabIndex = 2;
            // 
            // txtGiaBan
            // 
            txtGiaBan.Location = new Point(113, 484);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(180, 27);
            txtGiaBan.TabIndex = 3;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(113, 405);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(180, 27);
            txtSoLuong.TabIndex = 4;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(113, 444);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(180, 27);
            txtMoTa.TabIndex = 5;
            // 
            // cbDanhMuc
            // 
            cbDanhMuc.FormattingEnabled = true;
            cbDanhMuc.Location = new Point(113, 521);
            cbDanhMuc.Name = "cbDanhMuc";
            cbDanhMuc.Size = new Size(180, 28);
            cbDanhMuc.TabIndex = 6;
            cbDanhMuc.SelectedIndexChanged += cbDanhMuc_SelectedIndexChanged;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(422, 484);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(422, 565);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(422, 525);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(422, 445);
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
            label1.Location = new Point(23, 365);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 11;
            label1.Text = "Mã SP:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 408);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 12;
            label2.Text = "Số Lượng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 327);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 13;
            label3.Text = "Tên:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 447);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 14;
            label4.Text = "Mô Tả:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 487);
            label5.Name = "label5";
            label5.Size = new Size(34, 20);
            label5.TabIndex = 15;
            label5.Text = "Giá:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 521);
            label6.Name = "label6";
            label6.Size = new Size(79, 20);
            label6.TabIndex = 16;
            label6.Text = "Danh Mục:";
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(27, 38);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(510, 245);
            picHinhAnh.TabIndex = 17;
            picHinhAnh.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.Location = new Point(634, 10);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(94, 29);
            btnChonAnh.TabIndex = 18;
            btnChonAnh.Text = "Chọn Ảnh";
            btnChonAnh.UseVisualStyleBackColor = true;
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(812, 12);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(125, 27);
            txtTimKiem.TabIndex = 19;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(943, 10);
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
            label7.Location = new Point(734, 15);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 21;
            label7.Text = "Tìm Kiếm";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(304, 326);
            label8.Name = "label8";
            label8.Size = new Size(85, 20);
            label8.TabIndex = 22;
            label8.Text = "Kích Thước:";
            // 
            // txtKichThuoc
            // 
            txtKichThuoc.Location = new Point(391, 323);
            txtKichThuoc.Name = "txtKichThuoc";
            txtKichThuoc.Size = new Size(125, 27);
            txtKichThuoc.TabIndex = 23;
            // 
            // txtMauSac
            // 
            txtMauSac.Location = new Point(391, 380);
            txtMauSac.Name = "txtMauSac";
            txtMauSac.Size = new Size(125, 27);
            txtMauSac.TabIndex = 24;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(315, 387);
            label9.Name = "label9";
            label9.Size = new Size(68, 20);
            label9.TabIndex = 25;
            label9.Text = "Màu Sắc:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(picHinhAnh);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(txtMauSac);
            groupBox1.Controls.Add(txtMoTa);
            groupBox1.Controls.Add(txtKichThuoc);
            groupBox1.Controls.Add(txtMaSP);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(txtTenSP);
            groupBox1.Controls.Add(txtGiaBan);
            groupBox1.Controls.Add(txtSoLuong);
            groupBox1.Controls.Add(cbDanhMuc);
            groupBox1.Controls.Add(btnThem);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btnSua);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnXoa);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnLamMoi);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(31, 37);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(567, 640);
            groupBox1.TabIndex = 27;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông Tin Sản Phẩm";
            // 
            // FormSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1633, 717);
            Controls.Add(groupBox1);
            Controls.Add(label7);
            Controls.Add(dgvSanPham);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnChonAnh);
            Name = "FormSanPham";
            Text = "Sản Phẩm";
            Load += FormSanPham_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private Label label8;
        private TextBox txtKichThuoc;
        private TextBox txtMauSac;
        private Label label9;
        private GroupBox groupBox1;
    }
}