using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.BL;

namespace WindowsFormsApp1.GUI.AdminGUI
{
    public partial class ViewClientAppointmentsForm : Form
    {
        public ViewClientAppointmentsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppointmentService appointmentService = new AppointmentService();
            LinkedList<Appointment> appoints = appointmentService.getAllClientAppointments(textBox1.Text);
            if(appoints != null)
                foreach (Appointment a in appoints)
                {
                    StringBuilder str = new StringBuilder();
                    foreach (Service s in a.getServicesList())
                    {   
                        str.Append(s.getName() + " ");
                    }
                    comboBox1.Items.Add(a.getClientName() + ", " + a.getPhoneNumber() + ", " + a.getDate() + ", " +  str);
                }
        }
    }
}
