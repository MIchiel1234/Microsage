using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataAccess
{
    public class UserDatahandler
    {
        private static SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString);

        public static DataTable SelectUsers()
        {
            using (SqlDataAdapter sda = new SqlDataAdapter("SelectUsers", db))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);

                return dt;
            }

        }

        public static string SelectUsertitle(string Username)
        {
            try
            {
                db.Open();
                SqlParameter par1 = new SqlParameter("@Username", Username);
                SqlCommand cmd = new SqlCommand("SelectUsertitle", db);
                cmd.Parameters.Add(par1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                db.Close();
                db.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string title = dr["Employee_Title"].ToString();
                db.Close();
                return title;
            }
            catch (InvalidOperationException)
            {
                db.Open();
                SqlParameter par1 = new SqlParameter("@Username", Username);
                SqlCommand cmd = new SqlCommand("SelectUsertitle", db);
                cmd.Parameters.Add(par1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                db.Close();
                db.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string title = dr["Employee_Title"].ToString();;
                db.Close();
                return title;
            }
            
        }

        public static string SelectUserName(string Username)
        {
            try
            {
                db.Open();
                SqlParameter par1 = new SqlParameter("@Username", Username);
                SqlCommand cmd = new SqlCommand("SelectUserName", db);
                cmd.Parameters.Add(par1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                db.Close();
                db.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string name = dr["Employee_Name"].ToString();

                db.Close();
                return name;
            }
            catch (InvalidOperationException)
            {
                db.Open();
                SqlParameter par1 = new SqlParameter("@Username", Username);
                SqlCommand cmd = new SqlCommand("SelectUserName", db);
                cmd.Parameters.Add(par1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                db.Close();
                db.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string name = dr["Employee_Name"].ToString();
                db.Close();
                return name;
            }
            
        }
        public static string SelectUserSurname(string Username)
        {
            try
            {
                db.Open();
                SqlParameter par1 = new SqlParameter("@Username", Username);
                SqlCommand cmd = new SqlCommand("SelectUserSurname", db);
                cmd.Parameters.Add(par1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                db.Close();
                db.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string surname = dr["Employee_Surname"].ToString();
                db.Close();
                return surname;
            }
            catch (InvalidOperationException)
            {
                db.Open();
                SqlParameter par1 = new SqlParameter("@Username", Username);
                SqlCommand cmd = new SqlCommand("SelectUserSurname", db);
                cmd.Parameters.Add(par1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                db.Close();
                db.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string surname = dr["Employee_Surname"].ToString();
                db.Close();
                return surname;
            }
        }

        public static string SelectUserPassword(string Username)
        {
            try
            {
                db.Open();
                SqlParameter par1 = new SqlParameter("@Username", Username);
                SqlCommand cmd = new SqlCommand("SelectUserPassword", db);
                cmd.Parameters.Add(par1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                db.Close();
                db.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string Password = dr["Emp_Password"].ToString();
                db.Close();
                return Password;
            }
            catch (InvalidOperationException)
            {
                db.Open();
                SqlParameter par1 = new SqlParameter("@Username", Username);
                SqlCommand cmd = new SqlCommand("SelectUserPassword", db);
                cmd.Parameters.Add(par1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                db.Close();
                db.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string Password = dr["Emp_Password"].ToString();
                db.Close();
                return Password;
            }
        }

        public static int findUser(string Username, string Password)
        {
            try
            {
                db.Open();
                SqlParameter par1 = new SqlParameter("@Username", Username);
                SqlParameter par2 = new SqlParameter("@Password", Password);
                SqlCommand cmd = new SqlCommand("findUser", db);
                cmd.Parameters.Add(par1);
                cmd.Parameters.Add(par2);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                db.Close();
                db.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string read = dr["Employee_ID"].ToString();
                int ID = Convert.ToInt32(read);
                db.Close();
                return ID;
            }
            catch (InvalidOperationException)
            {
                db.Open();
                SqlParameter par1 = new SqlParameter("@Username", Username);
                SqlParameter par2 = new SqlParameter("@Password", Username);
                SqlCommand cmd = new SqlCommand("findUser", db);
                cmd.Parameters.Add(par1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                db.Close();
                db.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string read = dr["Employee_ID"].ToString();
                int ID = Convert.ToInt32(read);
                db.Close();
                return ID;
            }
            
        }

        public static void AddUser(SqlCommand cmd)
        {
            db.Open();
            cmd.Connection = db;
            cmd.CommandText = "AddUser";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            db.Close();
        }

        public static void RemoveUser(SqlCommand cmd)
        {
            db.Open();
            cmd.Connection = db;
            cmd.CommandText = "RemoveUser";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            db.Close();
        }

        public static void UpdateUser(SqlCommand cmd)
        {
            db.Open();
            cmd.Connection = db;
            cmd.CommandText = "UpdateUser";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            db.Close();
        }

        public class T
        {
            private string v1;
            private string v2;
            private string v3;

            public T(string v1, string v2, string v3)
            {
                this.v1 = v1;
                this.v2 = v2;
                this.v3 = v3;
            }
        }
    }
}
