using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entities
{
    class Service
    {
        private int id;
        private int idAppointment;
        private String name;
        private Double price;

        public Service(int idAppointment, string name, double price)
        {
            this.idAppointment = idAppointment;
            this.name = name;
            this.price = price;
        }

        public Service(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getIdAppointment()
        {
            return idAppointment;
        }

        public void setIdAppointment(int idAppointment)
        {
            this.idAppointment = idAppointment;
        }
        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public Double getPrice()
        {
            return price;
        }

        public void setPrice(Double price)
        {
            this.price = price;
        }
    }
}
