using ProductSell.Model;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace SellUI
{
    public partial class Catalog<T>: Form
        where T:class
    {
        ProductContext db;
        DbSet<T> set;
        public Catalog(DbSet<T> set, ProductContext db)
        {
            InitializeComponent();
            this.db = db;
            this.set = set;
            set.Load();
            dataGridView.DataSource = set.Local.ToBindingList();
        }
        private void button1_Click(object sender, System.EventArgs e)
        {
            if (typeof(T) == typeof(Product))
            {
                
            }
            else if (typeof(T) == typeof(Customer))
            {

            }
            else if (typeof(T) == typeof(Seller))
            {

            }
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;

            if (typeof(T) == typeof(Product))
            {
                var product = set.Find(id) as Product;
                if (product != null)
                {
                    var form = new ProductForm(product);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        product = form.Product;
                        db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                var seller = set.Find(id) as Seller;
                if (seller != null)
                {
                    var sellerform = new SellerForm(seller);
                    if (sellerform.ShowDialog() == DialogResult.OK)
                    {
                        seller = sellerform.Seller;
                        db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Customer))
            {
                var customer = set.Find(id) as Customer;
                if (customer != null)
                {
                    var customerform = new CustomerForm(customer);
                    if (customerform.ShowDialog() == DialogResult.OK)
                    {
                        customer = customerform.Customer;
                        db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
        }
    }
}
