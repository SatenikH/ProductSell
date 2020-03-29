using ProductSell.Model;
using System;
using System.Windows.Forms;

namespace SellUI
{
    public partial class ProductForm : Form
    {
        public Product Product { get; set; }
        public ProductForm()
        {
            InitializeComponent();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            Product = new Product
            {
                Name = textBox1.Text,
                Price = numericUpDown1.Value,
                Count = (int)numericUpDown2.Value
            };
            Close();
        }
    }
}
