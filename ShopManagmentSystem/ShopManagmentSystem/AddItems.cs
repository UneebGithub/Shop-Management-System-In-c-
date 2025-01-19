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
    public partial class AddItems : Form
    {
        shopmansqlfileDataContext db;
        public AddItems()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ShopForm shopForm = new ShopForm();
            this.Hide();
            shopForm.ShowDialog();
            this.Hide();

        }

        private void Add_Click(object sender, EventArgs e)
        {
            db = new shopmansqlfileDataContext();
            try
            {
                db = new shopmansqlfileDataContext();

                additem a = new additem();

                a.productname = textBox1.Text;
                a.quantity = textBox2.Text;
                a.price = textBox3.Text;

                db.additems.InsertOnSubmit(a);
                db.SubmitChanges();

                MessageBox.Show("successfully added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            db=new shopmansqlfileDataContext();
            try { 
                string pname = textBox1.Text;
                var check_table = db.additems.FirstOrDefault(s=>s.productname.Equals(pname));
                   if(check_table != null)
                {
                    db.additems.DeleteOnSubmit(check_table);
                    db.SubmitChanges();
                    MessageBox.Show("Delete Successfully ");

                }
                else
                {
                    MessageBox.Show("PRODUCT not found");
                }
            
            
            }catch(Exception ex) { }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            db = new shopmansqlfileDataContext();
            try
            {
                string pname = textBox1.Text;

                // Query the database for the record to update
                var itemToUpdate = db.additems.FirstOrDefault(a => a.productname.Equals(pname));

                if (itemToUpdate != null)
                {
                    // Update the record's properties with the new values from the text boxes
                    itemToUpdate.quantity = textBox2.Text;
                    itemToUpdate.price = textBox3.Text;

                    // Submit the changes to the database
                    db.SubmitChanges();

                    MessageBox.Show("Item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // If no matching item is found, display an error message
                    MessageBox.Show("Item not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddItems_Load(object sender, EventArgs e)
        {

        }
    }
}
