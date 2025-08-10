namespace duan1.Forms
{
    partial class FormDangNhap
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
            txtEmail = new TextBox();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            label1 = new Label();
            label2 = new Label();
            lab_thongBao = new Label();
            lab_login = new Label();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.BackColor = SystemColors.Control;
            txtEmail.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            txtEmail.Location = new Point(104, 65);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(209, 22);
            txtEmail.TabIndex = 0;
            // 
            // txtMatKhau
            // 
            txtMatKhau.BackColor = SystemColors.Control;
            txtMatKhau.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            txtMatKhau.Location = new Point(104, 103);
            txtMatKhau.Margin = new Padding(3, 2, 3, 2);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '-';
            txtMatKhau.Size = new Size(209, 22);
            txtMatKhau.TabIndex = 1;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.DimGray;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangNhap.ForeColor = Color.WhiteSmoke;
            btnDangNhap.Location = new Point(104, 131);
            btnDangNhap.Margin = new Padding(3, 2, 3, 2);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(101, 31);
            btnDangNhap.TabIndex = 2;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(31, 67);
            label1.Name = "label1";
            label1.Size = new Size(42, 17);
            label1.TabIndex = 3;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(31, 103);
            label2.Name = "label2";
            label2.Size = new Size(66, 17);
            label2.TabIndex = 4;
            label2.Text = "Mat khau";
            // 
            // lab_thongBao
            // 
            lab_thongBao.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_thongBao.Location = new Point(22, 181);
            lab_thongBao.Name = "lab_thongBao";
            lab_thongBao.Size = new Size(339, 23);
            lab_thongBao.TabIndex = 6;
            lab_thongBao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lab_login
            // 
            lab_login.AutoSize = true;
            lab_login.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lab_login.ForeColor = Color.Maroon;
            lab_login.Location = new Point(31, 19);
            lab_login.Name = "lab_login";
            lab_login.Size = new Size(318, 25);
            lab_login.TabIndex = 7;
            lab_login.Text = "Vui lòng đăng nhập vào hệ thống...";
            lab_login.Click += lab_login_Click;
            // 
            // FormDangNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(373, 213);
            Controls.Add(lab_login);
            Controls.Add(lab_thongBao);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(txtEmail);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormDangNhap";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private TextBox txtMatKhau;
        private Button btnDangNhap;
        private Label label1;
        private Label label2;
        private Label lab_thongBao;
        private Label lab_login;
    }
}