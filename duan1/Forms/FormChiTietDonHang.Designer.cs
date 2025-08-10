namespace duan1.Forms
{
    partial class FormChiTietDonHang
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dtg_chiTietDonHang = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dtg_chiTietDonHang).BeginInit();
            SuspendLayout();
            // 
            // dtg_chiTietDonHang
            // 
            dtg_chiTietDonHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_chiTietDonHang.BackgroundColor = SystemColors.Control;
            dtg_chiTietDonHang.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtg_chiTietDonHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtg_chiTietDonHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_chiTietDonHang.Cursor = Cursors.Hand;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtg_chiTietDonHang.DefaultCellStyle = dataGridViewCellStyle2;
            dtg_chiTietDonHang.Dock = DockStyle.Fill;
            dtg_chiTietDonHang.Location = new Point(0, 0);
            dtg_chiTietDonHang.Name = "dtg_chiTietDonHang";
            dtg_chiTietDonHang.ReadOnly = true;
            dtg_chiTietDonHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_chiTietDonHang.Size = new Size(1018, 492);
            dtg_chiTietDonHang.TabIndex = 5;
            // 
            // FormChiTietDonHang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 492);
            Controls.Add(dtg_chiTietDonHang);
            Name = "FormChiTietDonHang";
            Text = "FormChiTietDonHang";
            Load += FormChiTietDonHang_Load;
            ((System.ComponentModel.ISupportInitialize)dtg_chiTietDonHang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtg_chiTietDonHang;
    }
}