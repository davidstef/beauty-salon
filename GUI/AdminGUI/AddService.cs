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

namespace WindowsFormsApp1.GUI.AdminGUI
{
    public partial class AddService : Form
    {
        public AddService()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ServiceService s = new ServiceService();
            if (!textBox1.Text.Equals(""))
            {
                try {
                    Console.WriteLine(s.addServiceType(new Entities.Service(textBox1.Text, Convert.ToDouble(textBox2.Text))));
                } catch (Exception eas) {
                    Console.WriteLine("Invalid price!");
                }
            }
            
        }

        private void AddService_Load(object sender, EventArgs e)
        {

        }
    }
}
