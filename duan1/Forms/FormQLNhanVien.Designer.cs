namespace duan1.Forms
{
    partial class FormQLNhanVien
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
            dgvNhanVien = new DataGridView();
            txtTimKiem = new TextBox();
            label2 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtMaNhanVien = new TextBox();
            txtHoTen = new TextBox();
            txtEmail = new TextBox();
            txtMatKhau = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(356, 9);
            label1.Name = "label1";
            label1.Size = new Size(334, 46);
            label1.TabIndex = 0;
            label1.Text = "Thông Tin Nhân Viên";
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Location = new Point(12, 61);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.Size = new Size(1020, 279);
            dgvNhanVien.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(798, 410);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(234, 27);
            txtTimKiem.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(675, 410);
            label2.Name = "label2";
            label2.Size = new Size(114, 31);
            label2.TabIndex = 3;
            label2.Text = "Tìm Kiếm:";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(558, 362);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 4;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(558, 412);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 5;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(558, 461);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 6;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 366);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 7;
            label3.Text = "Mã Nhân Viên:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 416);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 8;
            label4.Text = "Họ Tên:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 465);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 9;
            label5.Text = "Email:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(269, 366);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 10;
            label6.Text = "Mật Khẩu:";
            // 
            // txtMaNhanVien
            // 
            txtMaNhanVien.Location = new Point(123, 363);
            txtMaNhanVien.Name = "txtMaNhanVien";
            txtMaNhanVien.Size = new Size(140, 27);
            txtMaNhanVien.TabIndex = 12;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(123, 414);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(140, 27);
            txtHoTen.TabIndex = 13;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(123, 463);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(140, 27);
            txtEmail.TabIndex = 14;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(380, 363);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(140, 27);
            txtMatKhau.TabIndex = 15;
            // 
            // FormQLNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1048, 516);
            Controls.Add(txtMatKhau);
            Controls.Add(txtEmail);
            Controls.Add(txtHoTen);
            Controls.Add(txtMaNhanVien);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(label2);
            Controls.Add(txtTimKiem);
            Controls.Add(dgvNhanVien);
            Controls.Add(label1);
            Name = "FormQLNhanVien";
            Text = "FormQLNhanVien";
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvNhanVien;
        private TextBox txtTimKiem;
        private Label label2;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtMaNhanVien;
        private TextBox txtHoTen;
        private TextBox txtEmail;
        private TextBox txtMatKhau;
    }
}