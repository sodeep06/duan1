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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDangNhap));
            txtEmail = new TextBox();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            label1 = new Label();
            label2 = new Label();
            lab_login = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.BackColor = SystemColors.Control;
            txtEmail.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            txtEmail.Location = new Point(371, 488);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(238, 26);
            txtEmail.TabIndex = 0;
            // 
            // txtMatKhau
            // 
            txtMatKhau.BackColor = SystemColors.Control;
            txtMatKhau.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            txtMatKhau.Location = new Point(371, 532);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '-';
            txtMatKhau.Size = new Size(238, 26);
            txtMatKhau.TabIndex = 1;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.DimGray;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangNhap.ForeColor = Color.WhiteSmoke;
            btnDangNhap.Location = new Point(391, 616);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(115, 41);
            btnDangNhap.TabIndex = 2;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(259, 492);
            label1.Name = "label1";
            label1.Size = new Size(59, 23);
            label1.TabIndex = 3;
            label1.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(259, 536);
            label2.Name = "label2";
            label2.Size = new Size(91, 23);
            label2.TabIndex = 4;
            label2.Text = "Mật khẩu:";
            // 
            // lab_login
            // 
            lab_login.AutoSize = true;
            lab_login.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lab_login.ForeColor = Color.Maroon;
            lab_login.Location = new Point(250, 9);
            lab_login.Name = "lab_login";
            lab_login.Size = new Size(409, 32);
            lab_login.TabIndex = 7;
            lab_login.Text = "Vui lòng đăng nhập vào hệ thống...";
            lab_login.Click += lab_login_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(259, 49);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(389, 391);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // FormDangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(867, 683);
            Controls.Add(lab_login);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(txtEmail);
            Name = "FormDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private TextBox txtMatKhau;
        private Button btnDangNhap;
        private Label label1;
        private Label label2;
        private Label lab_login;

        private PictureBox pictureBox1;

    }
}