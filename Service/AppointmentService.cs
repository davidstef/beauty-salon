using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.DAL;

namespace WindowsFormsApp1.BL
{
    class AppointmentService
    {
        private AppointmentRepository appointmentRepository = AppointmentRepository.getInstance();
        public Double createAppointment(Appointment prog, LinkedList<Service> servs)
        {
            Appointment foundP = appointmentRepository.getAppointment(prog, servs);

            if (foundP != null)
            {
                if (prog.getServicesList().Intersect(foundP.getServicesList()).Any())
                {
                    appointmentRepository.createAppointment(prog, servs);
                    return calculateTotalPrice(servs);
                }
            }
            else
            {
                appointmentRepository.createAppointment(prog, servs);
                Console.WriteLine(servs.ElementAt(0).getPrice());
                return calculateTotalPrice(servs);
            }

            return 0.0;
        }

        private Double calculateTotalPrice(LinkedList<Service> list) 
        {
            double sum = 0.0;
            foreach(Service s in list) {
                sum += s.getPrice();
            }
            return sum;
        }

        public LinkedList<Appointment> getAppointments()
        {
            return appointmentRepository.getAppointments();
        }
        public LinkedList<Appointment> getAppointmentsBetween2Dates(DateTime d1, DateTime d2)
        {
            return appointmentRepository.getAppointmentsBetween2Dates(d1, d2);
        }

        public LinkedList<Appointment> getAllClientAppointments(String clientName)
        {
            return appointmentRepository.getAllClientAppointments(clientName);
        }
    }
}
