namespace duan1.Forms
{
    partial class FormChiTietSanPham
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
            dtg_chiTietSanPham = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dtg_chiTietSanPham).BeginInit();
            SuspendLayout();
            // 
            // dtg_chiTietSanPham
            // 
            dtg_chiTietSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_chiTietSanPham.BackgroundColor = SystemColors.Control;
            dtg_chiTietSanPham.BorderStyle = BorderStyle.None;
            dtg_chiTietSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_chiTietSanPham.Dock = DockStyle.Top;
            dtg_chiTietSanPham.Location = new Point(0, 0);
            dtg_chiTietSanPham.Name = "dtg_chiTietSanPham";
            dtg_chiTietSanPham.Size = new Size(800, 294);
            dtg_chiTietSanPham.TabIndex = 0;
            dtg_chiTietSanPham.CellClick += dtg_chiTietSanPham_CellClick;
            // 
            // FormChiTietSanPham
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtg_chiTietSanPham);
            Name = "FormChiTietSanPham";
            Text = "FormChiTietSanPham";
            Load += FormChiTietSanPham_Load;
            ((System.ComponentModel.ISupportInitialize)dtg_chiTietSanPham).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtg_chiTietSanPham;
    }
}