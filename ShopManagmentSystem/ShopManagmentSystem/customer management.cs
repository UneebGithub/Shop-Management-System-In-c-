using System;
using System.Linq;
using System.Windows.Forms;

namespace ShopManagmentSystem
{
    public partial class customer_management : Form
    {
        // Create a LINQ to SQL DataContext for CustomerManagement table
        private shopmansqlfileDataContext db;

        public customer_management()
        {
            InitializeComponent();
            // Initialize your LINQ to SQL DataContext
            db = new shopmansqlfileDataContext();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ShopForm shopForm = new ShopForm();
            this.Hide();
            shopForm.ShowDialog();
            this.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new CustomerManagement object
                CustomerManagement c = new CustomerManagement
                {
                    CustomerName = textBox1.Text,
                    CustomerEmail = textBox2.Text,
                    CustomerPhone = textBox3.Text
                };

                // Add the new customer to the DataContext and submit changes
                db.CustomerManagements.InsertOnSubmit(c);
                db.SubmitChanges();

                MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the customer name from textBox1 (assuming textBox1 is for CustomerName)
                string customerNameToDelete = textBox1.Text.Trim();

                // Query the database for the customer to delete
                var customerToDelete = db.CustomerManagements.FirstOrDefault(c => c.CustomerName == customerNameToDelete);

                if (customerToDelete != null)
                {
                    // Remove the customer from the DataContext and submit changes
                    db.CustomerManagements.DeleteOnSubmit(customerToDelete);
                    db.SubmitChanges();

                    MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Customer not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the customer name from textBox1 (assuming textBox1 is for CustomerName)
                string customerNameToUpdate = textBox1.Text.Trim();

                // Query the database for the customer to update
                var customerToUpdate = db.CustomerManagements.FirstOrDefault(c => c.CustomerName == customerNameToUpdate);

                if (customerToUpdate != null)
                {
                    // Update the customer's properties
                    customerToUpdate.CustomerEmail = textBox2.Text;
                    customerToUpdate.CustomerPhone = textBox3.Text;

                    // Submit the changes to the database
                    db.SubmitChanges();

                    MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Customer not found! Please enter correct customer name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void customer_management_Load(object sender, EventArgs e)
        {

        }
    }
}
