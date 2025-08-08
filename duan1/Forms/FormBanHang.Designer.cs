namespace duan1.Forms
{
    partial class FormBanHang
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
            dtg_sanPham = new DataGridView();
            label1 = new Label();
            txt_timKiem = new TextBox();
            txt_timKhach = new TextBox();
            label2 = new Label();
            dtg_khachHang = new DataGridView();
            btn_them = new Button();
            dataGridView2 = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            btn_apDungVoucher = new Button();
            txt_voucher = new TextBox();
            label5 = new Label();
            button1 = new Button();
            lab_thongBao = new Label();
            ((System.ComponentModel.ISupportInitialize)dtg_sanPham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtg_khachHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dtg_sanPham
            // 
            dtg_sanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_sanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_sanPham.Location = new Point(12, 50);
            dtg_sanPham.Name = "dtg_sanPham";
            dtg_sanPham.ReadOnly = true;
            dtg_sanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_sanPham.Size = new Size(681, 150);
            dtg_sanPham.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 1;
            label1.Text = "Tim kiem";
            // 
            // txt_timKiem
            // 
            txt_timKiem.Location = new Point(74, 11);
            txt_timKiem.Name = "txt_timKiem";
            txt_timKiem.Size = new Size(619, 23);
            txt_timKiem.TabIndex = 2;
            // 
            // txt_timKhach
            // 
            txt_timKhach.Location = new Point(74, 231);
            txt_timKhach.Name = "txt_timKhach";
            txt_timKhach.Size = new Size(485, 23);
            txt_timKhach.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 234);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 4;
            label2.Text = "Tim kiem";
            // 
            // dtg_khachHang
            // 
            dtg_khachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_khachHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_khachHang.Location = new Point(12, 271);
            dtg_khachHang.Name = "dtg_khachHang";
            dtg_khachHang.ReadOnly = true;
            dtg_khachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_khachHang.Size = new Size(681, 150);
            dtg_khachHang.TabIndex = 3;
            // 
            // btn_them
            // 
            btn_them.Location = new Point(565, 231);
            btn_them.Name = "btn_them";
            btn_them.Size = new Size(128, 23);
            btn_them.TabIndex = 6;
            btn_them.Text = "Them";
            btn_them.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(938, 262);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(400, 150);
            dataGridView2.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(940, 243);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 8;
            label3.Text = "Gio hang";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(938, 428);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 9;
            label4.Text = "Tong tien:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1003, 425);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(335, 23);
            textBox1.TabIndex = 10;
            // 
            // btn_apDungVoucher
            // 
            btn_apDungVoucher.Location = new Point(1263, 479);
            btn_apDungVoucher.Name = "btn_apDungVoucher";
            btn_apDungVoucher.Size = new Size(75, 23);
            btn_apDungVoucher.TabIndex = 11;
            btn_apDungVoucher.Text = "Ap dung";
            btn_apDungVoucher.UseVisualStyleBackColor = true;
            // 
            // txt_voucher
            // 
            txt_voucher.Location = new Point(1003, 480);
            txt_voucher.Name = "txt_voucher";
            txt_voucher.Size = new Size(254, 23);
            txt_voucher.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(941, 483);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 13;
            label5.Text = "Voucher: ";
            // 
            // button1
            // 
            button1.Location = new Point(938, 550);
            button1.Name = "button1";
            button1.Size = new Size(397, 77);
            button1.TabIndex = 14;
            button1.Text = "THANH TOAN";
            button1.UseVisualStyleBackColor = true;
            // 
            // lab_thongBao
            // 
            lab_thongBao.Location = new Point(941, 515);
            lab_thongBao.Name = "lab_thongBao";
            lab_thongBao.Size = new Size(397, 23);
            lab_thongBao.TabIndex = 15;
            lab_thongBao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormBanHang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 648);
            Controls.Add(lab_thongBao);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(txt_voucher);
            Controls.Add(btn_apDungVoucher);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dataGridView2);
            Controls.Add(btn_them);
            Controls.Add(txt_timKhach);
            Controls.Add(label2);
            Controls.Add(dtg_khachHang);
            Controls.Add(txt_timKiem);
            Controls.Add(label1);
            Controls.Add(dtg_sanPham);
            Name = "FormBanHang";
            Text = "FormBanHang";
            WindowState = FormWindowState.Maximized;
            Load += FormBanHang_Load;
            ((System.ComponentModel.ISupportInitialize)dtg_sanPham).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtg_khachHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtg_sanPham;
        private Label label1;
        private TextBox txt_timKiem;
        private TextBox txt_timKhach;
        private Label label2;
        private DataGridView dtg_khachHang;
        private Button btn_them;
        private DataGridView dataGridView2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private Button btn_apDungVoucher;
        private TextBox txt_voucher;
        private Label label5;
        private Button button1;
        private Label lab_thongBao;
    }
}