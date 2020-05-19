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
    public class TransactionDatahandler
    {
        private static SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString);

        public static void AddTransaction(SqlCommand cmd)
        {
            db.Open();
            cmd.Connection = db;
            cmd.CommandText = "AddTransaction";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            db.Close();
        }

        public static void UpdateTransaction(SqlCommand cmd)
        {
            db.Open();
            cmd.Connection = db;
            cmd.CommandText = "UpdateTransaction";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            db.Close();
        }


    }
}
