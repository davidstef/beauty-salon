using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.GUI.AdminGUI;
using WindowsFormsApp1.BL;
using WindowsFormsApp1.Entities;

namespace WindowsFormsApp1
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            ServiceService service = new ServiceService();
            foreach(Service s in service.viewServiceType() ) {
                comboBox1.Items.Add(s.getName() + " - " + s.getPrice() + " RON");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateEmployeeAccountForm c = new CreateEmployeeAccountForm();
            c.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewClientAppointmentsForm v = new ViewClientAppointmentsForm();
            v.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewAppointmentsBetweenDates v = new ViewAppointmentsBetweenDates();
            v.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddService a = new AddService();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeleteService d = new DeleteService();
            d.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateService u = new UpdateService();
            u.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
}
