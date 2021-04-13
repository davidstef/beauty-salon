using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.DAL;

namespace WindowsFormsApp1.BL
{
    class ServiceService
    {
        private ServiceRepository serviceRepository = ServiceRepository.getInstance();

        public bool addServiceType(Service s)
        {
            if(serviceRepository.addServiceType(s))
                return true;
            return false;
            
        }

        public Service findByName(String name)
        {
            return serviceRepository.getServiceByName(name);
        }
            public LinkedList<Service> viewServiceType()
        {
            return serviceRepository.viewServiceType();
        }

        public bool deleteServiceType(String s)
        {
            return serviceRepository.deleteServiceType(s);
        }

        public bool updateServiceType(String name, Double price)
        {
            return serviceRepository.updateServiceType(name, price) ? true : false;
        }
    }
}
