using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BL;
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1.GUI.UserGuI
{
    public partial class CreateAppointmentForm : Form
    {
        ServiceService service = new ServiceService();
        AppointmentService appointmentService = new AppointmentService();
        LinkedList<Service> services = new LinkedList<Service>();
        public CreateAppointmentForm()
        {
            InitializeComponent();
            LinkedList<Service> services = service.viewServiceType();
            foreach (Service s in services)
            {
                comboBox1.Items.Add(s.getName());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            foreach (Service s in services)
            {
                comboBox1.Items.Add(s.getName());
            }
            Double price = appointmentService.createAppointment(new Appointment(1, dateTimePicker1.Value, textBox1.Text, textBox2.Text, services), services);
            listBox1.Items.Add("__________________");
            listBox1.Items.Add("Cost: " + price + " RON");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceService serv = new ServiceService();
            listBox1.Items.Add(comboBox1.SelectedItem.ToString());
            services.AddLast(serv.findByName(comboBox1.SelectedItem.ToString()));
        }
    }
}
