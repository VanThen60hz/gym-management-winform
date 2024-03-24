using System.Data;
using System.Data.SqlClient;

namespace gym_management
{
    internal class LOPDUNGCHUNG
    {
        static string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.net\winform\gym-management\gym-management\QLPHONGGYM.mdf;Integrated Security=True";
        public static SqlConnection con = new SqlConnection(conStr);

        public static DataTable GetDataToTable(string sql)
        {
            DataTable table = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            dap.Fill(table);
            return table;
        }

        public static int CUD(string sql)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery();
            }

            return result;

        }

        public static int CAL(string sql)
        {
            int result;
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                result = (int)cmd.ExecuteScalar();
            }

            return result;
        }
    }

}