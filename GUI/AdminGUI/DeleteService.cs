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
    public partial class DeleteService : Form
    {
        ServiceService service = new ServiceService();
        public DeleteService()
        {
            InitializeComponent();
            foreach (Service s in service.viewServiceType())
            {
                comboBox1.Items.Add(s.getName());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                Console.WriteLine(service.deleteServiceType(comboBox1.SelectedItem.ToString()));
                foreach (Service s in service.viewServiceType())
                {
                    comboBox1.Items.Add(s.getName());
                }
            } else
            {
                Console.WriteLine("Please select one item in the box!");
            }
        }
    }
}
