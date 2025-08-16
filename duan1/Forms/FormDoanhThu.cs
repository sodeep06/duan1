using duan1.Repositories;
using duan1.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace duan1.Forms
{
    public partial class FormDoanhThu : Form
    {
        private readonly DonHangRepo _repo = new DonHangRepo();

        // Theme (nhẹ nhàng, đồng nhất)
        private readonly Color TBg = Color.FromArgb(246, 247, 251);
        private readonly Color TDark = Color.FromArgb(17, 24, 39);
        private readonly Color TMuted = Color.FromArgb(107, 114, 128);
        private readonly Color TPrimary = Color.FromArgb(91, 141, 239);
        private readonly Color TBorder = Color.FromArgb(229, 231, 235);

        // UI
        private Panel topFilter;
        private DateTimePicker dtFrom, dtTo;
        private Button btnReload, btnToday, btn7, btn30, btnThisYear;
        private Chart chartRevenue;

        public FormDoanhThu()
        {
            InitializeComponent();

            // Để nhúng vào panel của MainForm
            FormBorderStyle = FormBorderStyle.None;
            TopLevel = false;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = TBg;
            Font = new Font("Segoe UI", 10f);

            BuildUI();
            ApplyTheme();

            // Mặc định 30 ngày gần nhất
            Shown += (s, e) =>
            {
                var to = DateTime.Today;
                var from = to.AddDays(-29);
                dtFrom.Value = from;
                dtTo.Value = to;
                LoadRange(from, to);
            };
        }

        private void BuildUI()
        {
            SuspendLayout();

            // ===== Thanh lọc =====
            topFilter = new Panel { Dock = DockStyle.Top, Height = 56, Padding = new Padding(16, 8, 16, 8), BackColor = TBg };

            dtFrom = new DateTimePicker { Width = 170, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };
            dtTo = new DateTimePicker { Width = 170, Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy" };

            btnReload = MakeBtn("Lọc", () => LoadRange(dtFrom.Value.Date, dtTo.Value.Date));
            btnToday = MakeBtn("Hôm nay", () => { var d = DateTime.Today; SetRange(d, d); });
            btn7 = MakeBtn("7 ngày", () => { var to = DateTime.Today; SetRange(to.AddDays(-6), to); });
            btn30 = MakeBtn("30 ngày", () => { var to = DateTime.Today; SetRange(to.AddDays(-29), to); });
            btnThisYear = MakeBtn("Năm nay", () =>
            {
                int y = DateTime.Today.Year;
                SetRange(new DateTime(y, 1, 1), new DateTime(y, 12, 31));
            });

            var flow = new FlowLayoutPanel
            {
                Dock = DockStyle.Left,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            flow.Controls.Add(new Label { Text = "Từ:", AutoSize = true, ForeColor = TDark, Margin = new Padding(0, 8, 6, 0) });
            flow.Controls.Add(dtFrom);
            flow.Controls.Add(new Label { Text = "  Đến:", AutoSize = true, ForeColor = TDark, Margin = new Padding(12, 8, 6, 0) });
            flow.Controls.Add(dtTo);
            flow.Controls.Add(btnReload);
            flow.Controls.Add(btnToday);
            flow.Controls.Add(btn7);
            flow.Controls.Add(btn30);
            flow.Controls.Add(btnThisYear);

            topFilter.Controls.Add(flow);
            Controls.Add(topFilter);

            // ===== Biểu đồ (fill toàn bộ phần còn lại) =====
            chartRevenue = new Chart { Dock = DockStyle.Fill, BackColor = Color.White };

            var ca = new ChartArea("ca")
            {
                BackColor = Color.White
            };
            // Trục & lưới
            ca.AxisX.MajorGrid.LineColor = TBorder;
            ca.AxisY.MajorGrid.LineColor = TBorder;
            ca.AxisX.LabelStyle.ForeColor = TDark;
            ca.AxisY.LabelStyle.ForeColor = TDark;
            ca.AxisY.LabelStyle.Format = "N0";

            // Cấu hình cơ bản trục X theo ngày (bước cụ thể set theo khoảng)
            ca.AxisX.IntervalType = DateTimeIntervalType.Days;
            ca.AxisX.LabelStyle.Format = "dd/MM";
            ca.AxisX.IsMarginVisible = true;

            chartRevenue.ChartAreas.Add(ca);

            var srs = new Series("Doanh thu")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.DateTime,
                IsXValueIndexed = false,   // Tôn trọng khoảng cách thời gian thật
                BorderWidth = 0,
                Color = Color.FromArgb(66, 133, 244)
            };
            chartRevenue.Series.Add(srs);

            Controls.Add(chartRevenue);

            ResumeLayout();
        }

        private Button MakeBtn(string text, Action onClick)
        {
            var b = new Button
            {
                Text = text,
                AutoSize = true,
                Margin = new Padding(12, 0, 0, 0),
                Padding = new Padding(10, 6, 10, 6),
                BackColor = TPrimary,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            b.FlatAppearance.BorderSize = 0;
            b.Click += (s, e) => onClick();
            b.MouseEnter += (s, e) => b.BackColor = Color.FromArgb(28, 151, 234);
            b.MouseLeave += (s, e) => b.BackColor = TPrimary;
            return b;
        }

        private void ApplyTheme()
        {
            // Nếu muốn tinh chỉnh DateTimePicker thêm thì làm ở đây
        }

        // ================= DATA =================
        private void SetRange(DateTime from, DateTime to)
        {
            dtFrom.Value = from;
            dtTo.Value = to;
            LoadRange(from, to);
        }

        private void LoadRange(DateTime from, DateTime to)
        {
            if (from > to)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
                return;
            }

            SetupXAxis(from, to);                 // quan trọng: set bước nhãn theo khoảng
            var list = _repo.GetRevenueByDay(from, to);
            BindChartByDay(list);
        }

        private void BindChartByDay(List<RevenuePointVm> list)
        {
            var srs = chartRevenue.Series[0];
            srs.Points.Clear();

            foreach (var p in list.OrderBy(x => x.Ngay))
                srs.Points.AddXY(p.Ngay, p.DoanhThu);
        }

        // Chống trùng nhãn ngày: chọn bước (Interval) theo độ dài khoảng
        private void SetupXAxis(DateTime from, DateTime to)
        {
            var ax = chartRevenue.ChartAreas[0].AxisX;

            ax.Minimum = from.ToOADate();
            ax.Maximum = to.ToOADate();
            ax.LabelStyle.Format = "dd/MM";

            int days = (int)(to.Date - from.Date).TotalDays + 1;
            double step = days <= 12 ? 1
                       : days <= 24 ? 2
                       : days <= 60 ? 5
                       : days <= 120 ? 10
                       : 30;

            ax.IntervalType = DateTimeIntervalType.Days;
            ax.Interval = step;
            ax.LabelStyle.Interval = step;

            ax.MajorGrid.IntervalType = DateTimeIntervalType.Days;
            ax.MajorGrid.Interval = step;

            ax.LabelStyle.Angle = -45;   // nghiêng nhẹ cho dễ đọc (có thể bỏ nếu không thích)
        }
    }
}
