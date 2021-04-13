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
    public partial class UpdateService : Form
    {
        public UpdateService()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceService s = new ServiceService();
            if (!textBox1.Text.Equals(""))
            {
                try
                {
                    Console.WriteLine(s.updateServiceType(textBox1.Text, Convert.ToDouble(textBox2.Text)));
                }
                catch (Exception eas)
                {
                    Console.WriteLine("Invalid price!");
                }
            }
            else
            {
                Console.WriteLine("Invalid name!");
            }
        }
    }
}
