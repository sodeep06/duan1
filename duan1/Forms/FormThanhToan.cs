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
    public partial class FormThanhToan : Form
    {
        public string TrangThaiThanhToan { get; private set; }
        public decimal TienMat { get; private set; }
        public decimal TienThua { get; private set; }

        decimal tongTien;
        public FormThanhToan(decimal tongTien)
        {
            InitializeComponent();
            this.tongTien = tongTien;
            num_tienMat.Visible = false;
            txt_tienThua.Visible = false;
            rdo_chuyenKhoan.Checked = true;
            label1.Visible = false;
            label2.Visible = false;
        }

        private void rdo_tienMat_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = rdo_tienMat.Checked;
            label2.Visible = rdo_tienMat.Checked;
            num_tienMat.Visible = rdo_tienMat.Checked;
            txt_tienThua.Visible = rdo_tienMat.Checked;
        }

        private void num_tienMat_ValueChanged(object sender, EventArgs e)
        {
            TienMat = num_tienMat.Value;
            TienThua = TienMat - tongTien;

            if (TienThua >= 0)
                txt_tienThua.Text = decimal.Round(TienThua, 0, MidpointRounding.AwayFromZero).ToString("N0");
            else
                txt_tienThua.Text = "-" + decimal.Round(Math.Abs(TienThua), 0, MidpointRounding.AwayFromZero).ToString("N0");
        }



        private void btn_xacNhan_Click(object sender, EventArgs e)
        {
            lab_thongBao.Text = "";
            lab_thongBao.Visible = false;

            if (rdo_chuyenKhoan.Checked)
            {
                TrangThaiThanhToan = $"Đã chuyển khoản {tongTien:N0}";
                DialogResult = DialogResult.OK;
                Close();
                return;
            }
            TienMat = num_tienMat.Value;
            TienThua = TienMat - tongTien;

            if (TienMat <= 0)
            {
                lab_thongBao.Text = "Số tiền mặt phải lớn hơn 0.";
                lab_thongBao.ForeColor = Color.Red;
                lab_thongBao.Visible = true;
                return;
            }
            if (TienMat < tongTien)
            {
                lab_thongBao.Text = $"Số tiền mặt {TienMat:N0} không đủ để thanh toán. Tổng tiền là {tongTien:N0}.";
                lab_thongBao.ForeColor = Color.Red;
                lab_thongBao.Visible = true;
                return;
            }

            // Lấy tiền thừa đã được làm tròn (nếu muốn làm tròn)
            TienThua = decimal.Round(TienThua, 0, MidpointRounding.AwayFromZero);
            txt_tienThua.Text = TienThua.ToString("N0");

            // Chuẩn bị trạng thái — chỉ gán 1 lần, không ghi đè
            if (TienThua == 0)
            {
                TrangThaiThanhToan = $"Đã đưa đúng số tiền {tongTien:N0}, không cần thối lại.";
            }
            else
            {
                TrangThaiThanhToan = $"Đã đưa tiền mặt {TienMat:N0} và nhân viên thối lại {TienThua:N0}";
            }

            lab_thongBao.Text = "Sẵn sàng xác nhận.";
            lab_thongBao.ForeColor = Color.Green;
            lab_thongBao.Visible = true;

            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
