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
            ((System.ComponentModel.ISupportInitialize)dtg_hoaDon).BeginInit();
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
            dtg_hoaDon.Dock = DockStyle.Left;
            dtg_hoaDon.Location = new Point(0, 0);
            dtg_hoaDon.Margin = new Padding(3, 4, 3, 4);
            dtg_hoaDon.Name = "dtg_hoaDon";
            dtg_hoaDon.ReadOnly = true;
            dtg_hoaDon.RowHeadersWidth = 51;
            dtg_hoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg_hoaDon.Size = new Size(695, 736);
            dtg_hoaDon.TabIndex = 4;
            dtg_hoaDon.CellDoubleClick += dtg_hoaDon_CellDoubleClick;
            // 
            // FormHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1054, 736);
            Controls.Add(dtg_hoaDon);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormHoaDon";
            Text = "Hóa Đơn";
            Load += FormHoaDon_Load;
            ((System.ComponentModel.ISupportInitialize)dtg_hoaDon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtg_hoaDon;
    }
}