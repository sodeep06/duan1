namespace duan1.Forms
{
    partial class FormThanhToan
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
            num_tienMat = new NumericUpDown();
            rdo_chuyenKhoan = new RadioButton();
            rdo_tienMat = new RadioButton();
            txt_tienThua = new TextBox();
            btn_xacNhan = new Button();
            label1 = new Label();
            label2 = new Label();
            lab_thongBao = new Label();
            ((System.ComponentModel.ISupportInitialize)num_tienMat).BeginInit();
            SuspendLayout();
            // 
            // num_tienMat
            // 
            num_tienMat.Location = new Point(26, 73);
            num_tienMat.Maximum = new decimal(new int[] { -402653184, -1613725636, 54210108, 0 });
            num_tienMat.Name = "num_tienMat";
            num_tienMat.Size = new Size(120, 23);
            num_tienMat.TabIndex = 0;
            num_tienMat.ValueChanged += num_tienMat_ValueChanged;
            // 
            // rdo_chuyenKhoan
            // 
            rdo_chuyenKhoan.AutoSize = true;
            rdo_chuyenKhoan.Location = new Point(26, 33);
            rdo_chuyenKhoan.Name = "rdo_chuyenKhoan";
            rdo_chuyenKhoan.Size = new Size(102, 19);
            rdo_chuyenKhoan.TabIndex = 1;
            rdo_chuyenKhoan.TabStop = true;
            rdo_chuyenKhoan.Text = "Chuyển khoản";
            rdo_chuyenKhoan.UseVisualStyleBackColor = true;
            // 
            // rdo_tienMat
            // 
            rdo_tienMat.AutoSize = true;
            rdo_tienMat.Location = new Point(243, 33);
            rdo_tienMat.Name = "rdo_tienMat";
            rdo_tienMat.Size = new Size(71, 19);
            rdo_tienMat.TabIndex = 2;
            rdo_tienMat.TabStop = true;
            rdo_tienMat.Text = "Tiền mặt";
            rdo_tienMat.UseVisualStyleBackColor = true;
            rdo_tienMat.CheckedChanged += rdo_tienMat_CheckedChanged;
            // 
            // txt_tienThua
            // 
            txt_tienThua.Location = new Point(194, 73);
            txt_tienThua.Name = "txt_tienThua";
            txt_tienThua.Size = new Size(120, 23);
            txt_tienThua.TabIndex = 3;
            // 
            // btn_xacNhan
            // 
            btn_xacNhan.Location = new Point(26, 102);
            btn_xacNhan.Name = "btn_xacNhan";
            btn_xacNhan.Size = new Size(120, 23);
            btn_xacNhan.TabIndex = 4;
            btn_xacNhan.Text = "Xác nhận";
            btn_xacNhan.UseVisualStyleBackColor = true;
            btn_xacNhan.Click += btn_xacNhan_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 55);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 5;
            label1.Text = "Tiền khách đưa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(194, 55);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 6;
            label2.Text = "Tiền thừa";
            // 
            // lab_thongBao
            // 
            lab_thongBao.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_thongBao.ForeColor = Color.Red;
            lab_thongBao.Location = new Point(26, 9);
            lab_thongBao.Name = "lab_thongBao";
            lab_thongBao.Size = new Size(288, 15);
            lab_thongBao.TabIndex = 7;
            // 
            // FormThanhToan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(326, 143);
            Controls.Add(lab_thongBao);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_xacNhan);
            Controls.Add(txt_tienThua);
            Controls.Add(rdo_tienMat);
            Controls.Add(rdo_chuyenKhoan);
            Controls.Add(num_tienMat);
            Name = "FormThanhToan";
            Text = "FormThanhToan";
            ((System.ComponentModel.ISupportInitialize)num_tienMat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown num_tienMat;
        private RadioButton rdo_chuyenKhoan;
        private RadioButton rdo_tienMat;
        private TextBox txt_tienThua;
        private Button btn_xacNhan;
        private Label label1;
        private Label label2;
        private Label lab_thongBao;
    }
}