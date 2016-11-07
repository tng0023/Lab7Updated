using System;
using System.Windows.Forms;

namespace Lab_7_Project
{
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fmInvMGMT());
        }
    }
}

namespace Inventory
{
    public class Product {
        long upc;
        string productName;
        int qtyOnHand;
        DateTime expiration;

        public Product() { }
        public Product(long _UPC, int _qty, string _name, DateTime _ex) {
            upc = _UPC;
            qtyOnHand = _qty;
            productName = _name;
            expiration = _ex;
        }
        public long UPC {
            get { return upc; }
            set { upc = value; }
        }
        public int Quantity {
            get { return qtyOnHand; }
            set { qtyOnHand = value; }
        }
        public string Name {
            get { return productName; }
            set { productName = value; }
        }
        public DateTime Expiration {
            get { return expiration; }
            set { expiration = value; }
        }
    }
}
