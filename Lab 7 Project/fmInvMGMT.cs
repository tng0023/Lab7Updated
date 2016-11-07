using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Inventory;

namespace Lab_7_Project {
    public partial class fmInvMGMT : Form {
        public fmInvMGMT() {
            InitializeComponent();
        }

        List<Product> inventory = new List<Product>(); //a list to store the inventory
        string output;

        private void SetOutput(Product item) { // a method to set the display output for the item
            output = null;

            output = string.Format("Name:  {0}\r\n--------------------------\r\nUPC: {1}\r\nQty: {2}\r\n\r\nExp: {3:d}",
                item.Name, item.UPC, item.Quantity, item.Expiration);
            if (!IsExpired(item)) {
                output += "\r\n\r\n" + (item.Expiration.Date - DateTime.Today.Date).TotalDays + " days until expiration";
            }
            else
                output += "\r\n\r\nProduct expired!";

            txtOutput.Text = output;
        }
        private bool IsExpired(Product item) { //a method to check if the item entry has expired or not
            if (item.Expiration < DateTime.Today.Date) {
                return true;
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e) {
            inventory.Add(new Product(10085, 30, "Immodium AD", new DateTime(2016, 12, 25))); //adding items to the inventroy list
            inventory.Add(new Product(10086, 10, "Pepcid AC", new DateTime(2017, 1, 30)));
            inventory.Add(new Product(10087, 2, "Pepto Bismol", new DateTime(2016, 10, 30)));
            inventory.Add(new Product(10088, 10, "Tylenol", new DateTime(2017, 10, 25)));

            string[] operations = new string[] { "Select an operation...", "Query", "Increment", "Decrement", "Add new product", "View All"}; //adding the options for teh combo box to a list

            foreach (string thing in operations) //adding the options to the combo box with a foreach loop
                cmbOperation.Items.Add(thing);
            cmbOperation.SelectedIndex = 0;
        }

        private void Button_Click(object sender, EventArgs e) { //button click method
            if (sender == btnCommit) {
                if (cmbOperation.SelectedIndex == 1 | cmbOperation.SelectedIndex == 2 | cmbOperation.SelectedIndex == 3) {
                    foreach (Product x in inventory) {//adding or decresing item totals in the current inventory 
                        if (txtInput.Text == Convert.ToString(x.UPC) || txtInput.Text == x.Name) {
                            if (cmbOperation.SelectedIndex == 2) {
                                x.Quantity += 1;
                            }
                            else if (cmbOperation.SelectedIndex == 3) {
                                x.Quantity -= 1;
                            }
                            SetOutput(x);
                        }
                    }
                }
                else if (cmbOperation.SelectedIndex == 4) {
                    string temp = "";
                    string[] sArray;
                    Form formAddItem = new frmAddItem();//opening the new form to add an item

                    DialogResult btnAdd = formAddItem.ShowDialog();

                    if (btnAdd == DialogResult.OK)
                        temp = formAddItem.Tag.ToString(); //using tag to move over the info from the other form                
                    if (temp != "|||" & temp != "") { 
                        sArray = temp.Split('|');
                        inventory.Add(new Product(
                            Convert.ToInt64(sArray[0]), //UPC
                            Convert.ToInt32(sArray[2]), //quantity
                            sArray[1], //product name
                            Convert.ToDateTime(sArray[3]))); //expiration date
                        SetOutput(inventory[inventory.Count - 1]);
                    }
                }
                else if (cmbOperation.SelectedIndex == 5) {
                    output = "";
                    foreach (Product item in inventory) {
                        output += item.Name + "\r\n";
                        txtOutput.Text = output;
                    }
                }
                else
                    MessageBox.Show("Please click on a valid operation.", "Invalid Selection");
            }

            else if (sender == btnClear) {//will clear the text boxes
                output = "";
                txtInput.Text = "";
                txtOutput.Text = "";
            }
            else if (sender == btnExit) {//exit if exit button is clicked
                Close();
            }
        }

    }
}