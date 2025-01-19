using System;
using System.Linq;
using System.Windows.Forms;

namespace ShopManagmentSystem
{
    public partial class Employee : Form
    {
        private shopmansqlfileDataContext db;

        public Employee()
        {
            InitializeComponent();
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
                // Create a new EmployeeManagement object
                EmployeeManagement emp = new EmployeeManagement
                {
                    EmployeeName = textBox1.Text,
                    Address = textBox2.Text,
                    Phone = textBox3.Text,
                    EmployeeSalary = Convert.ToDecimal(textBox4.Text),
                    Age = Convert.ToInt32(textBox5.Text),
                    ShiftType= textBox6.Text,
                    Position= textBox7.Text,
                    WorkTime= textBox8.Text
                };

                // Add the new employee to the DataContext and submit changes
                db.EmployeeManagements.InsertOnSubmit(emp);
                db.SubmitChanges();

                MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Get the employee name from textBox1 (assuming textBox1 is for EmployeeName)
                string employeeNameToDelete = textBox1.Text.Trim();

                // Query the database for the employee to delete
                var employeeToDelete = db.EmployeeManagements.FirstOrDefault(emp => emp.EmployeeName == employeeNameToDelete);

                if (employeeToDelete != null)
                {
                    // Remove the employee from the DataContext and submit changes
                    db.EmployeeManagements.DeleteOnSubmit(employeeToDelete);
                    db.SubmitChanges();

                    MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Employee not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Get the employee name from textBox1 (assuming textBox1 is for EmployeeName)
                string employeeNameToUpdate = textBox1.Text.Trim();

                // Query the database for the employee to update
                var employeeToUpdate = db.EmployeeManagements.FirstOrDefault(emp => emp.EmployeeName == employeeNameToUpdate);

                if (employeeToUpdate != null)
                {
                    // Update the employee's properties
                    employeeToUpdate.Address = textBox2.Text;
                    employeeToUpdate.Phone = textBox3.Text;
                    employeeToUpdate.EmployeeSalary = Convert.ToDecimal(textBox4.Text);
                    employeeToUpdate.Age = Convert.ToInt32(textBox5.Text);

                    // Submit the changes to the database
                    db.SubmitChanges();

                    MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Employee not found! Please enter correct employee name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }
    }
}
