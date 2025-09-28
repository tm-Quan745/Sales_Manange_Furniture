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
        DBConnect db;
        LoginController lgCtrl = new LoginController();

        public ThongKeController(string username)
        {
            string sqllogin = lgCtrl.GetSqlLogin(username);
            string sqlpass = lgCtrl.GetSqlPass(username);
            db = new DBConnect(sqllogin, sqlpass);
        }

        public List<(int Month, decimal TotalRevenue)> GetMonthlyRevenueList(int year)
        {
            string query = "EXEC sp_GetMonthlyRevenueList @year";
            SqlParameter[] parameters = {
                new SqlParameter("@year", year)
    };

            var dt = db.ExecuteQuery(query, parameters);

            List<(int, decimal)> list = new List<(int, decimal)>();
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
            string query = "EXEC sp_GetMonthlyRevenue @year";
            SqlParameter[] parameters = {
                new SqlParameter("@year", year)
             };

            DataTable dt = db.ExecuteQuery(query, parameters);

            Dictionary<int, decimal> revenues = new Dictionary<int, decimal>();
            foreach (DataRow row in dt.Rows)
            {
                int month = Convert.ToInt32(row["Thang"]);
                decimal revenue = Convert.ToDecimal(row["DoanhThu"]);
                revenues[month] = revenue;
            }
            return revenues;
        }


        // Tính phần trăm thay đổi so với tháng trước
        public decimal GetPercentChange(int year, int month)
        {
            string query = "EXEC sp_GetPercentChange @year, @month";
            SqlParameter[] parameters = {
            new SqlParameter("@year", year),
            new SqlParameter("@month", month)
        };

            DataTable dt = db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                return Convert.ToDecimal(dt.Rows[0]["PercentChange"]);
            }
            return 0;
        }



    }

}
