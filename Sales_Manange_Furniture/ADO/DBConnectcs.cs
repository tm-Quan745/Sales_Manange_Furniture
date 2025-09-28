using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Sales_Manage_Furniture.config
{
    internal class DBConnect
    {
        
        private SqlConnection conn;

        public DBConnect()
        {
            // Lấy chuỗi kết nối từ App.config
            string connectionString = ConfigurationManager.ConnectionStrings["Sales_Manage_Furniture.Properties.Settings.QuanLyNoiThatConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }
        // Constructor dùng login riêng
        public DBConnect(string sqlLogin, string sqlPass)
        {
            string dbName = "QuanLyNoiThat";
            string server = "."; // hoặc server của bạn
            string connStr = $"Server={server};Database={dbName};User Id={sqlLogin};Password={sqlPass};";
            conn = new SqlConnection(connStr);
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

        // SELECT → DataTable
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            DataTable dt = new DataTable();
            try
            {
                Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = commandType;   // Cho phép chọn Text hoặc StoredProcedure
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

        // INSERT, UPDATE, DELETE → số dòng ảnh hưởng
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            int result = 0;
            try
            {
                Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = commandType;
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

        // Trả về giá trị duy nhất
        public object ExecuteScalar(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            object result = null;
            try
            {
                Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = commandType;
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
