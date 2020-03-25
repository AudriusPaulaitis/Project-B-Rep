using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Authentification_Form
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        //functie voor console + inlogform
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Welkom!");
        }




        //functie voor login knop
        private void button1_Click(object sender, EventArgs e)
        {
            string[] names = File.ReadAllLines(@"C:\Users\APaul\Desktop\names.txt");
            string[] passwords = File.ReadAllLines(@"C:\Users\APaul\Desktop\passwords.txt");

            if (names.Contains(textBox1.Text) && passwords.Contains(textBox2.Text))
            {
                AdminForm f2 = new AdminForm();
                f2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Verkeerde inloggegevens");
            }
        }


    }
}
