using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class UserRepository
    {
        #region IUserRepository Members
        private static UserRepository _usersDAL = null;
        private String _connectionString = @"Data Source=DESKTOP-JE6DDU4\SQLEXPRESS;Initial Catalog=ps;Integrated Security=True";
        SqlConnection _conn = null;

        private UserRepository()
        {
            try
            {
                _conn = new SqlConnection(_connectionString);
            }
            catch (SqlException e)
            {
                
               
                _conn = null;
            }

        }

        public static UserRepository getInstance()
        {
            if (_usersDAL == null)
            {
                _usersDAL = new UserRepository();
            }
            return _usersDAL;
        }

        public User getUser(String username, String password)
        {
            User u = null;
            String sql = "SELECT * FROM dbo.users WHERE username='" + username + "' AND password='" + password + "'";

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    u = new User(reader["username"].ToString(), reader["password"].ToString(), reader["name"].ToString(), reader["role"].ToString());
                }
                _conn.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            return u;
        }
        public bool updateUser(User u, String password)
        {
            String sql = "UPDATE dbo.users SET password='" + password + "', name='" + u.getName() +
                "', role='" + u.getRole() + "' WHERE username='" + u.getUsername() + "';";

            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.InsertCommand = new SqlCommand(sql, _conn);
                adapter.InsertCommand.ExecuteNonQuery();
                cmd.Dispose();
                _conn.Close();

                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public bool createUser(User u, String password)
        {
            String sql = "INSERT INTO dbo.users (username, password, role, name) values ('" + u.getUsername() + "', '"
             + password + "', '" + u.getRole() + "', '" + u.getName() + "');";

            try
            {
                _conn.Open();

                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.InsertCommand = new SqlCommand(sql, _conn);
                adapter.InsertCommand.ExecuteNonQuery();
                cmd.Dispose();
                _conn.Close();

                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool deleteUser(String username)
        {
            String sql = "Delete from dbo.users where username='" + username + "';";

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.InsertCommand = new SqlCommand(sql, _conn);
                adapter.InsertCommand.ExecuteNonQuery();
                cmd.Dispose();
                _conn.Close();
                return true;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        #endregion
    }
}
