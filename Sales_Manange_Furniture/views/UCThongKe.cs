using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sales_Manage_Furniture.controllers;
using System.Windows.Forms.DataVisualization.Charting;

namespace Sales_Manange_Furniture.views
{
    public partial class UCThongKe : UserControl
    {
        HoaDonController _hoaDonController = new HoaDonController();
        ThongKeController tkCtrl = new ThongKeController();
        public UCThongKe()
        {
            InitializeComponent();
            dgv_DonHangGanDay.RowHeadersVisible = false;
            
            SetupDataGridView();
            LoadData();
        }
        private void SetupDataGridView()
        {
            dgv_DonHangGanDay.AutoGenerateColumns = false; // ❌ không tự tạo cột
            dgv_DonHangGanDay.Columns.Clear();

            dgv_DonHangGanDay.Columns.Add("MaDHB", "Mã đơn hàng");
            dgv_DonHangGanDay.Columns["MaDHB"].DataPropertyName = "MaHDB";

            dgv_DonHangGanDay.Columns.Add("MaKH", "Mã khách hàng");
            dgv_DonHangGanDay.Columns["MaKH"].DataPropertyName = "MaKH"; // hoặc TenKH nếu có join

            dgv_DonHangGanDay.Columns.Add("NgayBan", "Ngày Bán");
            dgv_DonHangGanDay.Columns["NgayBan"].DataPropertyName = "NgayBan";

            dgv_DonHangGanDay.Columns.Add("TongTien", "Tổng tiền");
            dgv_DonHangGanDay.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dgv_DonHangGanDay.Columns["TongTien"].DataPropertyName = "TongTien";

            dgv_DonHangGanDay.Columns.Add("TrangThai", "Trạng thái");
            dgv_DonHangGanDay.Columns["TrangThai"].DataPropertyName = "TrangThai";

            foreach (DataGridViewColumn col in dgv_DonHangGanDay.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void LoadChart()
        {
            var monthlyRevenue = tkCtrl.GetMonthlyRevenueList(DateTime.Now.Year);

            chartRevenue.Series.Clear();
            var series = new Series("Revenue")
            {
                ChartType = SeriesChartType.Column
            };
            chartRevenue.Series.Add(series);

            for (int month = 1; month <= 12; month++)
            {
                decimal revenue = monthlyRevenue.FirstOrDefault(m => m.Month == month).TotalRevenue;
                series.Points.AddXY(month, revenue);
            }

            StyleChart(chartRevenue);
        }

        private void StyleChart(Chart chart)
        {
            chart.BackColor = Color.White;
            chart.ChartAreas[0].BackColor = Color.White;

            chart.ChartAreas[0].AxisX.Title = "Tháng";
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;

            chart.ChartAreas[0].AxisY.Title = "Doanh thu (VND)";
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            chart.Series[0].Color = Color.SaddleBrown;
            chart.Series[0].BorderWidth = 2;
            chart.Legends.Clear();
        }


        public void LoadData()
        {
            var allOrders = _hoaDonController.GetAll();
            var recentOrders = allOrders
                                .OrderByDescending(h => h.NgayBan)
                                .Take(5) // lấy 5 hóa đơn gần nhất
                                .ToList();

            dgv_DonHangGanDay.DataSource = null;
            dgv_DonHangGanDay.DataSource = recentOrders;

            // Load biểu đồ doanh thu
            LoadChart();
        }

        private void UCThongKe_Load(object sender, EventArgs e)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            // --- Doanh thu tháng này ---
            var revenues = tkCtrl.GetMonthlyRevenue(year);
            decimal currentRevenue = revenues.ContainsKey(month) ? revenues[month] : 0;

            txt_DoanhThu.Text = $"{currentRevenue:N0} VND"; // show doanh thu

            // --- Phần trăm thay đổi so với tháng trước ---
            decimal percentChange = tkCtrl.GetPercentChange(year, month);

            if (percentChange >= 0)
            {
                guna2TextBox1.Text = $"↑ Tăng {percentChange:N1}%";
                guna2TextBox1.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                guna2TextBox1.Text = $"↓ Giảm {Math.Abs(percentChange):N1}%";
                guna2TextBox1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void txt_DoanhThu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
