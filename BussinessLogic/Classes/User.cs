using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using DataAccess;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CreditCardFraudDetectionSystem.Resource.Domain
{
    public class User
    {
        public enum SecurityLevel
        {
            ADMIN = 0,
            MANAGER = 1,
            SUPERVISOR = 2,
            STAFF = 3
        };

        public enum TitleValues
        {
            MR,
            MS,
            MRS,
            DR,
            PROF
        }

        private String username;
        private String password;
        private String title;
        private String name;
        private String surname;
        private int securityLevel;
        private Boolean locked;

        public User(){ }

        public User(String username, String password)
        {
            this.username = username;
            this.password = password;
        }

        public User(String title, String name, String surname)
        {
            this.title = title;
            this.name = name;
            this.surname = surname;
        }

        public User(String username, String password, String title, String name, String surname)
        {
            this.username = username;
            this.password = password;
            this.title = title;
            this.name = name;
            this.surname = surname;
        }

        public User(String username, String password, String title, String name, String surname, int securityLevel, Boolean locked)
        {
            this.username = username;
            this.password = password;
            this.title = title;
            this.name = name;
            this.surname = surname;
            this.securityLevel = securityLevel; // Please note the enums in the top section
            this.locked = locked;
        }

        public String getUsername()
        {
            return this.username;
        }

        public void setUsername(String username)
        {
            this.username = username;
        }

        public String getPassword()
        {
            return this.password;
        }

        public void setPassword(String password)
        {
            this.password = password;
        }

        public String getTitle()
        {
            return this.title;
        }

        public void setTitle(String title)
        {
            this.title = title;
        }

        public String getName()
        {
            return this.name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getSurname()
        {
            return this.surname;
        }

        public void setSurname(String surname)
        {
            this.surname = surname;
        }

        public int getSecurityLevel()
        {
            return this.securityLevel;
        }

        public void setSecurityLevel(int securityLevel)
        {
            this.securityLevel = securityLevel;
        }

        public Boolean isLocked()
        {
            return this.locked;
        }

        public void setLocked(Boolean locked)
        {
            this.locked = locked;
        }

        SqlCommand cmd = new SqlCommand();

        public List<User> GetUser(string Username)
        {
            List<User> user = new List<User>();
            user.Add(new User(Username, UserDatahandler.SelectUserPassword(Username),UserDatahandler.SelectUsertitle(Username), UserDatahandler.SelectUserName(Username), UserDatahandler.SelectUserSurname(Username)));
            return user;
        }

        public  int findUser(string Username, string Password)
        {
            return UserDatahandler.findUser(Username, Password);
        }

        public void AddUser()
        {
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Surname", surname);
            cmd.Parameters.AddWithValue("@SecurityLevel", securityLevel);
            UserDatahandler.AddUser(cmd);
        }

        public void RemoveUser(int Employee_ID)
        {
            cmd.Parameters.AddWithValue("@Employee_ID", Employee_ID);
            UserDatahandler.RemoveUser(cmd);
        }

        public void UpdateUser(int Employee_ID)
        {
            cmd.Parameters.AddWithValue("@Employee_ID", Employee_ID);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@Title", title);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Surname", surname);
            cmd.Parameters.AddWithValue("@SecurityLevel", securityLevel);
            UserDatahandler.UpdateUser(cmd);
        }

    }
}
