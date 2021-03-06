﻿using System;
using System.Windows.Forms;
using ProductSell.Model;

namespace SellUI
{
    public partial class Form1 : Form
    {
        ProductContext db;
        public Form1()
        {
            InitializeComponent();
            db = new ProductContext();
        }
        private void sellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogSeller = new Catalog<Seller>(db.Sellers, db);
            catalogSeller.Show();
        }
        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCustomer = new Catalog<Customer>(db.Customers, db);
            catalogCustomer.Show();
        }
        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Product>(db.Products, db);
            catalogProduct.Show();
        }
        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCheck = new Catalog<Check>(db.Checks, db);
            catalogCheck.Show();
        }
        private void CustomerAddToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            var form = new CustomerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Customers.Add(form.Customer);
                db.SaveChanges();
            }
        }
        private void SellerAddToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var formseller = new SellerForm();
            if (formseller.ShowDialog() == DialogResult.OK)
            {
                db.Sellers.Add(formseller.Seller);
                db.SaveChanges();
            }
        }
        private void ProductAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formproduct = new ProductForm();
            if (formproduct.ShowDialog() == DialogResult.OK)
            {
                db.Products.Add(formproduct.Product);
                db.SaveChanges();
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ModelForm();
            form.Show();
        }
    }
}
