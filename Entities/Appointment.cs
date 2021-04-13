using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entities
{
    class Appointment
    {
        private int id;
        private DateTime date;
        private String clientName;
        private String phoneNumber;
        private LinkedList<Service> servicesList;

        public Appointment(int id, DateTime date, string clientName, string phoneNumber, LinkedList<Service> servicesList)
        {
            this.id = id;
            this.date = date;
            this.clientName = clientName;
            this.phoneNumber = phoneNumber;
            this.servicesList = servicesList;
        }
        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }
        public String getClientName()
        {
            return clientName;
        }

        public void setClientName(String clientName)
        {
            this.clientName = clientName;
        }

        public DateTime getDate()
        {
            return date;
        }

        public void setDate(DateTime date)
        {
            this.date = date;
        }

        public String getPhoneNumber()
        {
            return phoneNumber;
        }

        public void setPhoneNumber(String phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public LinkedList<Service> getServicesList()
        {
            return servicesList;
        }

        public void setServicesList(LinkedList<Service> listServicii)
        {
            this.servicesList = listServicii;
        }

    }
}
