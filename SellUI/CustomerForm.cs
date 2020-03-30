using ProductSell.Model;
using System;
using System.Windows.Forms;

namespace SellUI
{
    public partial class CustomerForm : Form
    {
        public Customer Customer { get; set; }
        public CustomerForm()
        {
            InitializeComponent();
        }
        public CustomerForm(Customer customer):this()
        {
            Customer = customer;
            textBox1.Text = Customer.Name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Customer = new Customer
            {
                Name = textBox1.Text
            };
            Close();
        }
    }
}
