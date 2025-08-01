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
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            SuspendLayout();
            // 
            // dgvSanPham
            // 
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Location = new Point(12, 250);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.Size = new Size(794, 188);
            dgvSanPham.TabIndex = 0;
            dgvSanPham.CellClick += dgvSanPham_CellClick;
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(83, 51);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(125, 27);
            txtMaSP.TabIndex = 1;
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(278, 51);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(125, 27);
            txtTenSP.TabIndex = 2;
            // 
            // txtGiaBan
            // 
            txtGiaBan.Location = new Point(492, 54);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(125, 27);
            txtGiaBan.TabIndex = 3;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(83, 136);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(125, 27);
            txtSoLuong.TabIndex = 4;
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(278, 136);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(125, 27);
            txtMoTa.TabIndex = 5;
            // 
            // cbDanhMuc
            // 
            cbDanhMuc.FormattingEnabled = true;
            cbDanhMuc.Location = new Point(499, 141);
            cbDanhMuc.Name = "cbDanhMuc";
            cbDanhMuc.Size = new Size(151, 28);
            cbDanhMuc.TabIndex = 6;
            cbDanhMuc.SelectedIndexChanged += cbDanhMuc_SelectedIndexChanged;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(65, 194);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 7;
            btnThem.Text = "Them";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(279, 203);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 8;
            btnSua.Text = "Sua";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(465, 203);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xoa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(652, 203);
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
            label1.Location = new Point(27, 54);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 11;
            label1.Text = "MaSP";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 139);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 12;
            label2.Text = "SoLuong";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(222, 58);
            label3.Name = "label3";
            label3.Size = new Size(32, 20);
            label3.TabIndex = 13;
            label3.Text = "Ten";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(223, 143);
            label4.Name = "label4";
            label4.Size = new Size(45, 20);
            label4.TabIndex = 14;
            label4.Text = "MoTa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(438, 57);
            label5.Name = "label5";
            label5.Size = new Size(31, 20);
            label5.TabIndex = 15;
            label5.Text = "Gia";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(417, 144);
            label6.Name = "label6";
            label6.Size = new Size(76, 20);
            label6.TabIndex = 16;
            label6.Text = "Danh Muc";
            // 
            // FormSanPham
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
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
    }
}