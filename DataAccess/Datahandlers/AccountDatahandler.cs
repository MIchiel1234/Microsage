using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess.Datahandlers
{
    public class AccountDatahandler
    {
        private static SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString);

        public static DataTable SelectAccounts()
        {
            using (SqlDataAdapter sda = new SqlDataAdapter("SelectAccounts", db))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);

                return dt;
            }

        }

        public static void AddAccount(SqlCommand cmd)
        {
            db.Open();
            cmd.Connection = db;
            cmd.CommandText = "AddAccount";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            db.Close();
        }

        public static void UpdateAccount(SqlCommand cmd)
        {
            db.Open();
            cmd.Connection = db;
            cmd.CommandText = "UpdateAccount";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            db.Close();
        }
    }
}
