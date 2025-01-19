using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ShopManagmentSystem
{
    public partial class displaydata : Form
    {
       
       
       
        public displaydata()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ShopForm shopForm = new ShopForm();
            this.Hide();
            shopForm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=MAHAZLAPTOP\\SQLEXPRESS;Initial Catalog=ShopMan;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);

            try
            {
                con.Open();

                string query = "SELECT * FROM additem";
                SqlCommand cmd = new SqlCommand(query, con);

                var reader = cmd.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=MAHAZLAPTOP\\SQLEXPRESS;Initial Catalog=ShopMan;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);

            try
            {
                con.Open();

                string query = "SELECT * FROM CustomerManagement";
                SqlCommand cmd = new SqlCommand(query, con);

                var reader = cmd.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=MAHAZLAPTOP\\SQLEXPRESS;Initial Catalog=ShopMan;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);

            try
            {
                con.Open();

                string query = "SELECT * FROM SupplierManagement";
                SqlCommand cmd = new SqlCommand(query, con);

                var reader = cmd.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=MAHAZLAPTOP\\SQLEXPRESS;Initial Catalog=ShopMan;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);

            try
            {
                con.Open();

                string query = "SELECT * FROM EmployeeManagement";
                SqlCommand cmd = new SqlCommand(query, con);

                var reader = cmd.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=MAHAZLAPTOP\\SQLEXPRESS;Initial Catalog=ShopMan;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);

            try
            {
                con.Open();

                string query = "SELECT *FROM LoanersManagement";
                SqlCommand cmd = new SqlCommand(query, con);

                var reader = cmd.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);

                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void displaydata_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
