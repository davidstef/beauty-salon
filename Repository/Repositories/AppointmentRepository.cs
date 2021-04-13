using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1.DAL
{
    class AppointmentRepository
    {
        #region IAppointmentRepository Members
        private static AppointmentRepository _appointmentRepository = null;
        private static ServiceRepository _serviceRepository = ServiceRepository.getInstance();
        private String _connectionString = @"Data Source=DESKTOP-JE6DDU4\SQLEXPRESS;Initial Catalog=ps;Integrated Security=True";
        SqlConnection _conn = null;

        private AppointmentRepository()
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

        public static AppointmentRepository getInstance()
        {
            if (_appointmentRepository == null)
            {
                _appointmentRepository = new AppointmentRepository();
            }
            return _appointmentRepository;
        }

        public Appointment getAppointment(Appointment p, LinkedList<Service> servus)
        {
            String sql = "SELECT * FROM dbo.appointments where date= '" + p.getDate() + "';";
           
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    p = new Appointment(id, DateTime.Parse(reader["date"].ToString()),
                        reader["clientName"].ToString(), reader["phoneNumber"].ToString(), servus);
                    _serviceRepository.getServicesById(id);

                    p.setServicesList(servus);
                } else
                {
                    _conn.Close();
                    return null;
                }
              
               _conn.Close();
                return p;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public LinkedList<Appointment> getAppointments()
        {
            LinkedList<Service> servus = new LinkedList<Service>();
            LinkedList<Appointment> progs = new LinkedList<Appointment>();
            Appointment p = null;
            String sql = "SELECT * FROM dbo.appointments";

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    servus = _serviceRepository.getServicesById(int.Parse(reader["id"].ToString()));
                    p = new Appointment(int.Parse(reader["id"].ToString()), DateTime.Parse(reader["date"].ToString()),
                        reader["clientName"].ToString(), reader["phoneNumber"].ToString(), servus);
                    progs.AddLast(p);
                }
                _conn.Close();
                return progs;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private bool addServiceForAppointment(int id, LinkedList<Service> servs)
        {
            LinkedList<String> sqls = new LinkedList<String>();
            foreach(Service s in servs)
            {
                sqls.AddLast("INSERT INTO dbo.services (idAppointment, name, price) values (" + id + ", '"
                 + s.getName() + "' ," + s.getPrice() + ");");
            }

            try
            {
                _conn.Close();
                foreach (String sql in sqls)
                {

                    _conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, _conn);
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    adapter.InsertCommand = new SqlCommand(sql, _conn);
                    adapter.InsertCommand.ExecuteNonQuery();
                    
                    cmd.Dispose();
                    _conn.Close();

                }
               
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public bool createAppointment(Appointment p, LinkedList<Service> serv)
        {
             String sql = "INSERT INTO dbo.appointments (clientName, date, phoneNumber) values ('" + p.getClientName() + "', '"
              + p.getDate() + "' ,'" + p.getPhoneNumber() + "');";
           
            try
            {
                _conn.Open();
                
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataAdapter adapter = new SqlDataAdapter();
               
                adapter.InsertCommand = new SqlCommand(sql, _conn);
                adapter.InsertCommand.ExecuteNonQuery();
                cmd.Dispose();
                _conn.Close();

                Appointment prog = getAppointment(p, serv);
                addServiceForAppointment(prog.getId(), serv);
                
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public LinkedList<Appointment> getAppointmentsBetween2Dates(DateTime d1, DateTime d2)
        {
            LinkedList<Service> servus = new LinkedList<Service>();
            LinkedList<Appointment> progs = new LinkedList<Appointment>();
            Appointment p = null;
            String sql = "SELECT * FROM dbo.appointments WHERE date BETWEEN '" + d1 + "' AND '" +  d2 + "';";

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    servus = _serviceRepository.getServicesById(int.Parse(reader["id"].ToString()));
                    p = new Appointment(int.Parse(reader["id"].ToString()), DateTime.Parse(reader["date"].ToString()),
                        reader["clientName"].ToString(), reader["phoneNumber"].ToString(), servus);
                    progs.AddLast(p);
                }

                _conn.Close();
                return progs;

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public LinkedList<Appointment> getAllClientAppointments(String clientName)
        {
            LinkedList<Service> servus = new LinkedList<Service>();
            LinkedList<Appointment> progs = new LinkedList<Appointment>();
            Appointment p = null;
            String sql = "SELECT * FROM dbo.appointments WHERE clientName='" + clientName + "'; ";

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(sql, _conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        servus = _serviceRepository.getServicesById(int.Parse(reader["id"].ToString()));
                        p = new Appointment(int.Parse(reader["id"].ToString()), DateTime.Parse(reader["date"].ToString()),
                            reader["clientName"].ToString(), reader["phoneNumber"].ToString(), servus);
                        progs.AddLast(p);
                    }
                } else
                {
                    _conn.Close();
                    return null;
                } 

                _conn.Close();
                return progs;

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
