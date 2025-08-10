namespace duan1.Forms
{
    partial class FormHoaDon
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dtg_hoaDon = new DataGridView();
            panel1 = new Panel();
            label13 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtg_hoaDon).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dtg_hoaDon
            // 
            dtg_hoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_hoaDon.BackgroundColor = SystemColors.Control;
            dtg_hoaDon.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dtg_hoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dtg_hoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_hoaDon.Cursor = Cursors.Hand;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dtg_hoaDon.DefaultCellStyle = dataGridViewCellStyle4;
            dtg_hoaDon.Dock = DockStyle.Left;
            dtg_hoaDon.Location = new Point(0, 0);
            dtg_hoaDon.Name = "dtg_hoaDon";
            dtg_hoaDon.ReadOnly = true;
            dtg_hoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_hoaDon.Size = new Size(608, 552);
            dtg_hoaDon.TabIndex = 4;
            dtg_hoaDon.CellDoubleClick += dtg_hoaDon_CellDoubleClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label13);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(610, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 552);
            panel1.TabIndex = 5;
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.RosyBrown;
            label13.Location = new Point(-251, 263);
            label13.Name = "label13";
            label13.Size = new Size(206, 23);
            label13.TabIndex = 36;
            label13.Text = "Mẹo: Bạn có thể double click để chọn biến thể của sản phẩm";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.RosyBrown;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(312, 43);
            label1.TabIndex = 37;
            label1.Text = "Mẹo: Bạn có thể double click để xem chi tiết";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormHoaDon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(922, 552);
            Controls.Add(panel1);
            Controls.Add(dtg_hoaDon);
            Name = "FormHoaDon";
            Text = "FormHoaDon";
            Load += FormHoaDon_Load;
            ((System.ComponentModel.ISupportInitialize)dtg_hoaDon).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtg_hoaDon;
        private Panel panel1;
        private Label label1;
        private Label label13;
    }
}