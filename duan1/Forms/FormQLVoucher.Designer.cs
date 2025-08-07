namespace duan1.Forms
{
    partial class FormQLVoucher
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
            label1 = new Label();
            dgvVoucher = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtMaVoucher = new TextBox();
            txtTenVoucher = new TextBox();
            txtGiaTri = new TextBox();
            dtpNgayBatDau = new DateTimePicker();
            dtpNgayKetThuc = new DateTimePicker();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVoucher).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(444, 9);
            label1.Name = "label1";
            label1.Size = new Size(143, 46);
            label1.TabIndex = 1;
            label1.Text = "Voucher";
            // 
            // dgvVoucher
            // 
            dgvVoucher.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVoucher.Location = new Point(12, 58);
            dgvVoucher.Name = "dgvVoucher";
            dgvVoucher.RowHeadersWidth = 51;
            dgvVoucher.Size = new Size(1027, 227);
            dgvVoucher.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 312);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 3;
            label2.Text = "Mã Voucher:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 359);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 4;
            label3.Text = "Tên Voucher:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 403);
            label4.Name = "label4";
            label4.Size = new Size(52, 20);
            label4.TabIndex = 5;
            label4.Text = "Giá trị:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(320, 312);
            label5.Name = "label5";
            label5.Size = new Size(104, 20);
            label5.TabIndex = 6;
            label5.Text = "Ngày Bắt Đầu:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(320, 359);
            label6.Name = "label6";
            label6.Size = new Size(108, 20);
            label6.TabIndex = 7;
            label6.Text = "Ngày Kết Thúc:";
            // 
            // txtMaVoucher
            // 
            txtMaVoucher.Location = new Point(110, 309);
            txtMaVoucher.Name = "txtMaVoucher";
            txtMaVoucher.Size = new Size(189, 27);
            txtMaVoucher.TabIndex = 8;
            // 
            // txtTenVoucher
            // 
            txtTenVoucher.Location = new Point(110, 356);
            txtTenVoucher.Name = "txtTenVoucher";
            txtTenVoucher.Size = new Size(189, 27);
            txtTenVoucher.TabIndex = 9;
            // 
            // txtGiaTri
            // 
            txtGiaTri.Location = new Point(110, 400);
            txtGiaTri.Name = "txtGiaTri";
            txtGiaTri.Size = new Size(189, 27);
            txtGiaTri.TabIndex = 10;
            // 
            // dtpNgayBatDau
            // 
            dtpNgayBatDau.Location = new Point(430, 309);
            dtpNgayBatDau.Name = "dtpNgayBatDau";
            dtpNgayBatDau.Size = new Size(250, 27);
            dtpNgayBatDau.TabIndex = 11;
            // 
            // dtpNgayKetThuc
            // 
            dtpNgayKetThuc.Location = new Point(430, 356);
            dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            dtpNgayKetThuc.Size = new Size(250, 27);
            dtpNgayKetThuc.TabIndex = 12;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(796, 303);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 13;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(796, 355);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 14;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(796, 403);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 15;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // FormQLVoucher
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1051, 450);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dtpNgayKetThuc);
            Controls.Add(dtpNgayBatDau);
            Controls.Add(txtGiaTri);
            Controls.Add(txtTenVoucher);
            Controls.Add(txtMaVoucher);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dgvVoucher);
            Controls.Add(label1);
            Name = "FormQLVoucher";
            Text = "FormQLVoucher";
            ((System.ComponentModel.ISupportInitialize)dgvVoucher).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvVoucher;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtMaVoucher;
        private TextBox txtTenVoucher;
        private TextBox txtGiaTri;
        private DateTimePicker dtpNgayBatDau;
        private DateTimePicker dtpNgayKetThuc;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
    }
}