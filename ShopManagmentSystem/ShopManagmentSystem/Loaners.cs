using System;
using System.Linq;
using System.Windows.Forms;

namespace ShopManagmentSystem
{
    public partial class Loaners : Form
    {
        private shopmansqlfileDataContext db;

        public Loaners()
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
                LoanersManagement loaner = new LoanersManagement
                {
                    LoanerName = textBox1.Text,
                    Address = textBox2.Text,
                    Phone = textBox3.Text,
                    ItemsLoaned = decimal.Parse(textBox4.Text),
                    ItemsTotalPrice = int.Parse(textBox8.Text),
                    LoanDuration = textBox5.Text
                };

                db.LoanersManagements.InsertOnSubmit(loaner);
                db.SubmitChanges();

                MessageBox.Show("Loaner added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string loanerNameToDelete = textBox1.Text.Trim();

                var loanerToDelete = db.LoanersManagements.FirstOrDefault(l => l.LoanerName == loanerNameToDelete);

                if (loanerToDelete != null)
                {
                    db.LoanersManagements.DeleteOnSubmit(loanerToDelete);
                    db.SubmitChanges();

                    MessageBox.Show("Loaner deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Loaner not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string loanerNameToUpdate = textBox1.Text.Trim();

                var loanerToUpdate = db.LoanersManagements.FirstOrDefault(l => l.LoanerName == loanerNameToUpdate);

                if (loanerToUpdate != null)
                {
                    loanerToUpdate.Address = textBox2.Text;
                    loanerToUpdate.Phone = textBox3.Text;
                    loanerToUpdate.ItemsLoaned = decimal.Parse(textBox4.Text);
                    loanerToUpdate.ItemsTotalPrice = int.Parse(textBox8.Text);
                    loanerToUpdate.LoanDuration = textBox5.Text;

                    db.SubmitChanges();

                    MessageBox.Show("Loaner updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Loaner not found! Please enter correct loaner name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Loaners_Load(object sender, EventArgs e)
        {

        }
    }
}
