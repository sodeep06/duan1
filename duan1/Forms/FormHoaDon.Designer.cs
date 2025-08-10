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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dtg_hoaDon = new DataGridView();
            panel1 = new Panel();
            btn_xuatPDF = new Button();
            label1 = new Label();
            label13 = new Label();
            panel2 = new Panel();
            label2 = new Label();
            lab_maHoaDon = new Label();
            ((System.ComponentModel.ISupportInitialize)dtg_hoaDon).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dtg_hoaDon
            // 
            dtg_hoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtg_hoaDon.BackgroundColor = SystemColors.Control;
            dtg_hoaDon.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtg_hoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtg_hoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtg_hoaDon.Cursor = Cursors.Hand;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dtg_hoaDon.DefaultCellStyle = dataGridViewCellStyle2;
            dtg_hoaDon.Dock = DockStyle.Fill;
            dtg_hoaDon.Location = new Point(0, 0);
            dtg_hoaDon.Name = "dtg_hoaDon";
            dtg_hoaDon.ReadOnly = true;
            dtg_hoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_hoaDon.Size = new Size(604, 552);
            dtg_hoaDon.TabIndex = 4;
            dtg_hoaDon.CellClick += dtg_hoaDon_CellClick;
            dtg_hoaDon.CellDoubleClick += dtg_hoaDon_CellDoubleClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(lab_maHoaDon);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btn_xuatPDF);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label13);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(610, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 552);
            panel1.TabIndex = 5;
            // 
            // btn_xuatPDF
            // 
            btn_xuatPDF.FlatStyle = FlatStyle.Flat;
            btn_xuatPDF.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_xuatPDF.Location = new Point(211, 58);
            btn_xuatPDF.Name = "btn_xuatPDF";
            btn_xuatPDF.Size = new Size(89, 23);
            btn_xuatPDF.TabIndex = 38;
            btn_xuatPDF.Text = "Xuất PDF";
            btn_xuatPDF.UseVisualStyleBackColor = true;
            btn_xuatPDF.Click += btn_xuatPDF_Click;
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
            // panel2
            // 
            panel2.Controls.Add(dtg_hoaDon);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(604, 552);
            panel2.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 92);
            label2.Name = "label2";
            label2.Size = new Size(26, 15);
            label2.TabIndex = 39;
            label2.Text = "ID: ";
            // 
            // lab_maHoaDon
            // 
            lab_maHoaDon.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lab_maHoaDon.ForeColor = Color.FromArgb(0, 192, 0);
            lab_maHoaDon.Location = new Point(35, 84);
            lab_maHoaDon.Name = "lab_maHoaDon";
            lab_maHoaDon.Size = new Size(265, 28);
            lab_maHoaDon.TabIndex = 40;
            lab_maHoaDon.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FormHoaDon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(922, 552);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "FormHoaDon";
            Text = "FormHoaDon";
            Load += FormHoaDon_Load;
            ((System.ComponentModel.ISupportInitialize)dtg_hoaDon).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtg_hoaDon;
        private Panel panel1;
        private Label label1;
        private Label label13;
        private Button btn_xuatPDF;
        private Panel panel2;
        private Label lab_maHoaDon;
        private Label label2;
    }
}