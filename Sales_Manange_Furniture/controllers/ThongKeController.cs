using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales_Manage_Furniture.models;
using Sales_Manage_Furniture.config;

namespace Sales_Manage_Furniture.controllers
{
    internal class ThongKeController
    {
        private DBConnect db = new DBConnect();
        public List<(int Month, decimal TotalRevenue)> GetMonthlyRevenueList(int year)
        {
            string query = @"
        SELECT MONTH(NgayBan) AS Thang, SUM(TongTien) AS DoanhThu
        FROM HoaDonBan
        WHERE YEAR(NgayBan) = @year
        GROUP BY MONTH(NgayBan)
        ORDER BY Thang";

            var dt = db.ExecuteQuery(query, new SqlParameter[] {
        new SqlParameter("@year", year)
    });

            List<(int Month, decimal TotalRevenue)> list = new List<(int, decimal)>();
            foreach (DataRow row in dt.Rows)
            {
                int month = Convert.ToInt32(row["Thang"]);
                decimal total = Convert.ToDecimal(row["DoanhThu"]);
                list.Add((month, total));
            }
            return list;
        }

        public Dictionary<int, decimal> GetMonthlyRevenue(int year)
        {
            Dictionary<int, decimal> revenues = new Dictionary<int, decimal>();

            string query = @"
                SELECT MONTH(NgayBan) AS Thang, SUM(TongTien) AS DoanhThu
                FROM HoaDonBan
                WHERE YEAR(NgayBan) = @year
                GROUP BY MONTH(NgayBan)
                ORDER BY Thang;";

            SqlParameter[] parameters = {
                new SqlParameter("@year", year)
            };

            DataTable dt = db.ExecuteQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                int thang = Convert.ToInt32(row["Thang"]);
                decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                revenues[thang] = doanhThu;
            }

            return revenues;
        }

        // Tính phần trăm thay đổi so với tháng trước
        public decimal GetPercentChange(int year, int month)
        {
            var revenues = GetMonthlyRevenue(year);

            if (!revenues.ContainsKey(month) || month == 1)
                return 0; // không tính được

            decimal current = revenues[month];
            decimal previous = revenues.ContainsKey(month - 1) ? revenues[month - 1] : 0;

            if (previous == 0) return 100; // tháng trước không có doanh thu

            return ((current - previous) / previous) * 100;
        }


    }

}
