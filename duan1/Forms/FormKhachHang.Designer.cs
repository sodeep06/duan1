namespace duan1.Forms
{
    partial class FormKhachHang
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
            dgvKhachHang = new DataGridView();
            txtMaKH = new TextBox();
            txtHoTen = new TextBox();
            txtSDT = new TextBox();
            txtDiaChi = new TextBox();
            txtEmail = new TextBox();
            txtSearch = new TextBox();
            btnSave = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnSearch = new Button();
            btnThem = new Button();
            btnNew = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).BeginInit();
            SuspendLayout();
            // 
            // dgvKhachHang
            // 
            dgvKhachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhachHang.Location = new Point(27, 273);
            dgvKhachHang.Name = "dgvKhachHang";
            dgvKhachHang.RowHeadersWidth = 51;
            dgvKhachHang.Size = new Size(909, 197);
            dgvKhachHang.TabIndex = 0;
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(85, 23);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(125, 27);
            txtMaKH.TabIndex = 1;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(85, 80);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(125, 27);
            txtHoTen.TabIndex = 2;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(86, 130);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(125, 27);
            txtSDT.TabIndex = 3;
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(312, 23);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(125, 27);
            txtDiaChi.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(312, 80);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 5;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(149, 227);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 6;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(490, 225);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 8;
            btnSave.Text = "Sửa";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(614, 225);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(737, 227);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 10;
            btnRefresh.Text = "F5";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 27);
            label1.Name = "label1";
            label1.Size = new Size(57, 20);
            label1.TabIndex = 11;
            label1.Text = "Mã KH:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 83);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 12;
            label2.Text = "Họ Tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 137);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 13;
            label3.Text = "SDT:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(243, 30);
            label4.Name = "label4";
            label4.Size = new Size(60, 20);
            label4.TabIndex = 14;
            label4.Text = "Địa Chỉ:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(243, 87);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 15;
            label5.Text = "Email:";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(49, 226);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 16;
            btnSearch.Text = "Tìm Kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(359, 225);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 17;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(842, 227);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(94, 29);
            btnNew.TabIndex = 18;
            btnNew.Text = "New";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // FormKhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 482);
            Controls.Add(btnNew);
            Controls.Add(btnThem);
            Controls.Add(btnSearch);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(txtSearch);
            Controls.Add(txtEmail);
            Controls.Add(txtDiaChi);
            Controls.Add(txtSDT);
            Controls.Add(txtHoTen);
            Controls.Add(txtMaKH);
            Controls.Add(dgvKhachHang);
            Name = "FormKhachHang";
            Text = "Khách Hàng";
            Load += FormKhachHang_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKhachHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvKhachHang;
        private TextBox txtMaKH;
        private TextBox txtHoTen;
        private TextBox txtSDT;
        private TextBox txtDiaChi;
        private TextBox txtEmail;
        private TextBox txtSearch;
        private Button btnNew;
        private Button btnSave;
        private Button btnDelete;
        private Button btnRefresh;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnSearch;
        private Button btnThem;

    }
}