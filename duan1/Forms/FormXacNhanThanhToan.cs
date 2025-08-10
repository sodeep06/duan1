using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace duan1.Forms
{
    public partial class FormXacNhanThanhToan : Form
    {
        public bool XacNhanThanhToan { get; private set; }
        public string LyDoHuy { get; private set; }

        public FormXacNhanThanhToan()
        {
            InitializeComponent();
            txt_lyDo.Visible = false;
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            XacNhanThanhToan = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool isShowingReasonInput = false;

        private void btn_HuyDon_Click(object sender, EventArgs e)
        {
            if (!isShowingReasonInput)
            {
                lab_thongBao.Text = "Lý do huỷ của bạn?";
                txt_lyDo.Visible = true;
                txt_lyDo.Focus(); 
                btn_HuyDon.Text = "Xác nhận hủy";
                isShowingReasonInput = true;
                btn_XacNhan.Visible = false;

                MessageBox.Show("Vui lòng nhập lý do hủy đơn, sau đó click 'Xác nhận hủy'",
                               "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
                XacNhanThanhToan = false;
                string lyDo = txt_lyDo.Text.Trim();
                LyDoHuy = string.IsNullOrEmpty(lyDo) ? "Đơn hàng huỷ không có lý do" : $"Đơn hàng huỷ vì {lyDo}";
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
