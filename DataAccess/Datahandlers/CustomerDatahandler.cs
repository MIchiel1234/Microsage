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
    public class CustomerDatahandler
    {
        private static SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString);

        public static DataTable SelectCustomers()
        {
            using (SqlDataAdapter sda = new SqlDataAdapter("SelectCustomers", db))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);

                return dt;
            }

        }

        public static void AddCustomer(SqlCommand cmd)
        {
            db.Open();
            cmd.Connection = db;
            cmd.CommandText = "AddCustomer";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            db.Close();
        }

        public static void UpdateCustomer(SqlCommand cmd)
        {
            db.Open();
            cmd.Connection = db;
            cmd.CommandText = "UpdateCustomer";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            db.Close();
        }



    }
}
