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
    public partial class ShopForm : Form
    {
        public ShopForm()
        {
            InitializeComponent();
        }

        private void ShopForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddItems i = new AddItems();
            this.Hide();
            i.ShowDialog();
            this.Close();   

        }

        private void button2_Click(object sender, EventArgs e)
        {
            customer_management c = new customer_management();
            this.Hide();
            c.ShowDialog();
            this.Close();  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            supplier s = new supplier(); 
            this.Hide();
            s.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Loaners l = new Loaners();
            this.Hide();
            l.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            this.Hide();
            emp.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            displaydata d = new displaydata();
            this.Hide();
            d.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
