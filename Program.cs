using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.BL;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Author : Stef David-Alexandru
        /// Group : 30234
        /// </summary>
        [STAThread]
        static void Main()
        {
             Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new MainForm());
        }
    }
}
