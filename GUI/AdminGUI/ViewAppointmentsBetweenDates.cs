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

namespace WindowsFormsApp1.GUI.AdminGUI
{
    public partial class ViewAppointmentsBetweenDates : Form
    {
        public ViewAppointmentsBetweenDates()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppointmentService appService = new AppointmentService();
            LinkedList<Appointment> apps = appService.getAppointmentsBetween2Dates(dateTimePicker1.Value, dateTimePicker2.Value);
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
    }
}
