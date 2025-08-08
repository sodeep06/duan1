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
            label3 = new Label();
            lab_thongBao = new Label();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(95, 61);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(209, 23);
            txtEmail.TabIndex = 0;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(95, 99);
            txtMatKhau.Margin = new Padding(3, 2, 3, 2);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(209, 23);
            txtMatKhau.TabIndex = 1;
            // 
            // btnDangNhap
            // 
            btnDangNhap.Location = new Point(118, 136);
            btnDangNhap.Margin = new Padding(3, 2, 3, 2);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(134, 25);
            btnDangNhap.TabIndex = 2;
            btnDangNhap.Text = "Dang Nhap";
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 69);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 3;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 105);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 4;
            label2.Text = "Mat khau";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(118, 21);
            label3.Name = "label3";
            label3.Size = new Size(129, 20);
            label3.TabIndex = 5;
            label3.Text = "SHOP Giay Piapia";
            // 
            // lab_thongBao
            // 
            lab_thongBao.Location = new Point(22, 178);
            lab_thongBao.Name = "lab_thongBao";
            lab_thongBao.Size = new Size(339, 23);
            lab_thongBao.TabIndex = 6;
            lab_thongBao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormDangNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 213);
            Controls.Add(lab_thongBao);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(txtEmail);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormDangNhap";
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
        private Label label3;
        private Label lab_thongBao;
    }
}