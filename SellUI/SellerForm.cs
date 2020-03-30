using ProductSell.Model;
using System;
using System.Windows.Forms;

namespace SellUI
{
    public partial class SellerForm : Form
    {
        public Seller Seller { get; set; }
        public SellerForm()
        {
            InitializeComponent();
        }
        public SellerForm(Seller seller):this()
        {
            Seller = seller;
            textBox1.Text = Seller.Name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Seller = new Seller
            {
                Name = textBox1.Text
            };
            Close();
        }
    }
}
