using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagmentSystem
{
    public partial class Login : Form
    {
        shopmansqlfileDataContext db;
        public Login()
        {
            InitializeComponent();
        }

        private void signup_Click(object sender, EventArgs e)
        {
            Signup s = new Signup();
            this.Hide();
            s.ShowDialog();
            this.Close();
        }

        private void forgetpassword_Click(object sender, EventArgs e)
        {
            forgetpass f = new forgetpass();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                db = new shopmansqlfileDataContext();

                var enteredUsername = textBox1.Text;
                var enteredPassword = textBox2.Text;

                // Query the database to check if the username and password match
                var user = db.signups.SingleOrDefault(s => s.username == enteredUsername && s.password == enteredPassword);

                if (user != null)
                {
                    // If the user is found, show the next form
                    ShopForm sf = new ShopForm();
                    this.Hide();
                    sf.ShowDialog();
                    this.Close();
                }
                else
                {
                    // If the user is not found, display an error message
                    MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void Login_Load(object sender, EventArgs e)
        {
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
