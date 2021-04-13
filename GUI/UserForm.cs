using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.GUI.UserGuI;
using WindowsFormsApp1.BL;
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            AppointmentService appService = new AppointmentService();
            LinkedList<Appointment> apps = appService.getAppointments();
            foreach (Appointment a in apps)
            {
                StringBuilder str = new StringBuilder();
                foreach (Service s in a.getServicesList())
                {
                    str.Append(s.getName() + " ");
                }
                comboBox1.Items.Add(a.getClientName() + ", " + a.getPhoneNumber() + ", " + a.getDate() + ", " + str);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateAppointmentForm c = new CreateAppointmentForm();
            c.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
