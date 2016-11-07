using System;
using System.Windows.Forms;

namespace Lab_7_Project {
    public partial class frmAddItem : Form {
        public frmAddItem() {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e) {//adding items to the inventory
            if (sender == btnAdd) {
                if (IsValid(txtUPC) & IsValid(txtQuantity) & IsDate(txtExpirationDate) & IsPresent(txtProductName)) {
                    Tag = txtUPC.Text + "|" + txtProductName.Text + "|" + txtQuantity.Text + "|" + txtExpirationDate.Text;//tag to move the data to the other form
                    MessageBox.Show("Product " + txtProductName.Text + " was added successfully", "Item Added");
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else { //invalid input detected!
                    Tag = "";
                    MessageBox.Show("Product information entry error.", "Invalid Data");
                    ResetTextBoxes();
                }

            }
            else if (sender == btnCancel) { //cancel the entry
                DialogResult = DialogResult.Cancel;
                Close();
            } 
        }
        private void ResetTextBoxes() { //resets textboxes
            foreach (TextBox thing in new TextBox[] { txtExpirationDate, txtProductName, txtQuantity, txtUPC })
                thing.Text = "";
        }
        private bool IsPresent(TextBox tb) { 
            if (tb.Text != "" || tb.Text != null)            
                return true;
            return false;
        }
        private bool IsValid(TextBox tb) {
            long x;
            if (long.TryParse(tb.Text, out x))
                return true;
            return false;
        }
        private bool IsDate(TextBox tb) {
            DateTime x;
            if (DateTime.TryParse(tb.Text, out x))
                return true;
            return false;
        }

    }
}