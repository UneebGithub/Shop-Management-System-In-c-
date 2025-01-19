using System;
using System.Linq;
using System.Windows.Forms;

namespace ShopManagmentSystem
{
    public partial class supplier : Form
    {
        // Create a LINQ to SQL DataContext for SupplierManagement table
        private shopmansqlfileDataContext db;

        public supplier()
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
                // Create a new SupplierManagement object
                SupplierManagement s = new SupplierManagement
                {
                    SupplierName = textBox1.Text,
                    SupplierEmail = textBox2.Text,
                    Phone = textBox3.Text,
                    ContactPerson = textBox4.Text,
                    SupplierType = textBox5.Text
                };

                // Add the new supplier to the DataContext and submit changes
                db.SupplierManagements.InsertOnSubmit(s);
                db.SubmitChanges();

                MessageBox.Show("Supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Get the supplier name from textBoxSupplierName (assuming textBoxSupplierName is for SupplierName)
                string supplierNameToDelete = textBox1.Text.Trim();

                // Query the database for the supplier to delete
                var supplierToDelete = db.SupplierManagements.FirstOrDefault(s => s.SupplierName == supplierNameToDelete);

                if (supplierToDelete != null)
                {
                    // Remove the supplier from the DataContext and submit changes
                    db.SupplierManagements.DeleteOnSubmit(supplierToDelete);
                    db.SubmitChanges();

                    MessageBox.Show("Supplier deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Supplier not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Get the supplier name from textBoxSupplierName (assuming textBoxSupplierName is for SupplierName)
                string supplierNameToUpdate = textBox1.Text.Trim();

                // Query the database for the supplier to update
                var supplierToUpdate = db.SupplierManagements.FirstOrDefault(s => s.SupplierName == supplierNameToUpdate);

                if (supplierToUpdate != null)
                {
                    // Update the supplier's properties
                    supplierToUpdate.SupplierEmail = textBox2.Text;
                    supplierToUpdate.Phone = textBox3.Text;
                    supplierToUpdate.ContactPerson = textBox4.Text;
                    supplierToUpdate.SupplierType = textBox5.Text;

                    // Submit the changes to the database
                    db.SubmitChanges();

                    MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Supplier not found! Please enter correct supplier name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void supplier_Load(object sender, EventArgs e)
        {

        }
    }
}
