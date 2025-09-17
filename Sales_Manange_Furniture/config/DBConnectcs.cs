using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Sales_Manange_Furniture.config
{
    internal class DBConnect
    {
        private SqlConnection conn;

        public DBConnect()
        {
            // Lấy chuỗi kết nối từ App.config
            string connectionString = ConfigurationManager.ConnectionStrings["Sales_Manange_Furniture.Properties.Settings.QuanLyNoiThatConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }

        // Mở kết nối
        public void Open()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        // Đóng kết nối
        public void Close()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        // Thực hiện câu lệnh SELECT, trả về DataTable
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            finally
            {
                Close();
            }
            return dt;
        }

        // Thực hiện INSERT, UPDATE, DELETE → trả về số dòng bị ảnh hưởng
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int result = 0;
            try
            {
                Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    result = cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                Close();
            }
            return result;
        }

        // Trả về giá trị duy nhất (ví dụ COUNT, MAX, MIN…)
        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object result = null;
            try
            {
                Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    result = cmd.ExecuteScalar();
                }
            }
            finally
            {
                Close();
            }
            return result;
        }
    }
}
