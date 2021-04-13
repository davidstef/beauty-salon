using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1.DAL
{
    class ServiceRepository
    {
        #region IServiceRepository Members
        private static ServiceRepository _serviceRepository = null;
        private String _connectionString = @"Data Source=DESKTOP-JE6DDU4\SQLEXPRESS;Initial Catalog=ps;Integrated Security=True";
        SqlConnection _conn = null;
        private ServiceRepository()
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

        public static ServiceRepository getInstance()
        {
            if (_serviceRepository == null)
            {
                _serviceRepository = new ServiceRepository();
            }
            return _serviceRepository;
        }

        public bool addServiceType(Service s)
        {
            String sql = "INSERT INTO dbo.type_of_services (name, price) values ('" + s.getName() + "' ," + s.getPrice() + ");";  

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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool updateServiceType(String name, Double price)
        {
            String sql = "UPDATE dbo.type_of_services SET price=" + price + " WHERE name='" + name + "';";
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

        public bool deleteServiceType(String name)
        {
            String sql = "Delete from dbo.type_of_services where name='" + name + "';";

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

        public LinkedList<Service> viewServiceType()
        {
            Service s = null;
            LinkedList<Service> servicii = new LinkedList<Service>();
            String sql = "SELECT * FROM dbo.type_of_services;";

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    s = new Service(reader["name"].ToString(), Double.Parse(reader["price"].ToString()));
                    servicii.AddLast(s);
                }
                _conn.Close();
                return servicii;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public LinkedList<Service> getServicesById(int id)
        {
            
            LinkedList<Service> servicii = new LinkedList<Service>();
            String sql = "SELECT * FROM dbo.services WHERE idAppointment=" + id + ";";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Service s = new Service(int.Parse(reader["idAppointment"].ToString()),reader["name"].ToString(), Double.Parse(reader["price"].ToString()));
                    servicii.AddLast(s);
                }
                _conn.Close();
                return servicii;
              
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Service getServiceByName(String name)
        {
            
            String sql = "SELECT * FROM dbo.type_of_services WHERE name='" + name + "';";
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();
               
                if (reader.Read())
                {
                     Service s = new Service(reader["name"].ToString(), Double.Parse(reader["price"].ToString()));
                    _conn.Close();
                    return s;
                }
                return null;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        #endregion
    }
}
