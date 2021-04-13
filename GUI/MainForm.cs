using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using WindowsFormsApp1.BL;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private UserService userService = new UserService();

        public MainForm()
        {
            InitializeComponent();
            label3.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;
            User user = userService.login(username, password);

            if (user == null)
            {
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
                if (user.getRole().Equals("admin"))
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                }
                else if (user.getRole().Equals("user"))
                {
                    UserForm userForm = new UserForm();
                    userForm.Show();
                }
            }
        }

        
    }
}
