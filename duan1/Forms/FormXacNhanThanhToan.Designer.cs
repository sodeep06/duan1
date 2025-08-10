namespace duan1.Forms
{
    partial class FormXacNhanThanhToan
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
            btn_XacNhan = new Button();
            btn_HuyDon = new Button();
            txt_lyDo = new TextBox();
            lab_thongBao = new Label();
            SuspendLayout();
            // 
            // btn_XacNhan
            // 
            btn_XacNhan.Location = new Point(22, 76);
            btn_XacNhan.Name = "btn_XacNhan";
            btn_XacNhan.Size = new Size(105, 43);
            btn_XacNhan.TabIndex = 0;
            btn_XacNhan.Text = "Xác nhận";
            btn_XacNhan.UseVisualStyleBackColor = true;
            btn_XacNhan.Click += btn_XacNhan_Click;
            // 
            // btn_HuyDon
            // 
            btn_HuyDon.Location = new Point(156, 76);
            btn_HuyDon.Name = "btn_HuyDon";
            btn_HuyDon.Size = new Size(105, 43);
            btn_HuyDon.TabIndex = 1;
            btn_HuyDon.Text = "Huỷ đơn phút cuối";
            btn_HuyDon.UseVisualStyleBackColor = true;
            btn_HuyDon.Click += btn_HuyDon_Click;
            // 
            // txt_lyDo
            // 
            txt_lyDo.Location = new Point(22, 37);
            txt_lyDo.Name = "txt_lyDo";
            txt_lyDo.Size = new Size(239, 23);
            txt_lyDo.TabIndex = 2;
            // 
            // lab_thongBao
            // 
            lab_thongBao.AutoSize = true;
            lab_thongBao.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_thongBao.ForeColor = Color.FromArgb(192, 0, 0);
            lab_thongBao.Location = new Point(74, 9);
            lab_thongBao.Name = "lab_thongBao";
            lab_thongBao.Size = new Size(137, 17);
            lab_thongBao.TabIndex = 3;
            lab_thongBao.Text = "Xác nhận thanh toán";
            // 
            // FormXacNhanThanhToan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 131);
            Controls.Add(lab_thongBao);
            Controls.Add(txt_lyDo);
            Controls.Add(btn_HuyDon);
            Controls.Add(btn_XacNhan);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormXacNhanThanhToan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormXacNhanThanhToan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_XacNhan;
        private Button btn_HuyDon;
        private TextBox txt_lyDo;
        private Label lab_thongBao;
    }
}