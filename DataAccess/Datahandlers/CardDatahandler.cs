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
    public class CardDatahandler
    {
        private static SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString);

        public static DataTable SelectCards()
        {
            using (SqlDataAdapter sda = new SqlDataAdapter("SelectCards", db))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);

                return dt;
            }

        }

        public static void AddCard(SqlCommand cmd)
        {
            db.Open();
            cmd.Connection = db;
            cmd.CommandText = "AddCard";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            db.Close();
        }

        public static void UpdateCard(SqlCommand cmd)
        {
            db.Open();
            cmd.Connection = db;
            cmd.CommandText = "UpdateCard";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            db.Close();
        }


    }
}
