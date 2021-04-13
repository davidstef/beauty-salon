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
    public partial class CreateEmployeeAccountForm : Form
    {
        public CreateEmployeeAccountForm()
        {
            InitializeComponent();
            comboBox1.Items.Add("admin");
            comboBox1.Items.Add("user");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserService user = new UserService();
            if (!textBox1.Text.Equals("") || !textBox2.Text.Equals("") || !textBox3.Text.Equals(""))
            {
                Console.WriteLine(user.createUser(new User(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedItem.ToString())));
            } else
            {
                Console.WriteLine("Invalid username, password or name!");
            }
        }
    }
}
