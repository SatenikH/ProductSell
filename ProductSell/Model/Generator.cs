using System;
using System.Collections.Generic;

namespace ProductSell.Model
{
    public class Generator
    {
        Random rand = new Random();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Seller> Sellers { get; set; } = new List<Seller>();

        public List<Customer> GetCustomer(int count)
        {
            var result = new List<Customer>();

            for (int i = 0; i < count; i++)
            {
                var customer = new Customer()
                {
                    CustomerID = Customers.Count,
                    Name = GetRandomName()
                };
                Customers.Add(customer);
                result.Add(customer);
            }
            return result;
        }
        public List<Seller> GetSeller(int count)
        {
            var result = new List<Seller>();

            for (int i = 0; i < count; i++)
            {
                var seller = new Seller()
                {
                    SellerID = Sellers.Count,
                    Name = GetRandomName()
                };
                Sellers.Add(seller);
                result.Add(seller);
            }
            return result;
        }
        public List<Product> GetRandomProduct(int min, int max)
        {
            var result = new List<Product>();
            var count = rand.Next(min, max);
            for (int i = 0; i < count; i++)
            {
                result.Add(Products[rand.Next(Products.Count - 1)]);
            }
            return result;
        }
        public List<Product> GetProduct(int count)
        {
            var result = new List<Product>();


            for (int i = 0; i < count; i++)
            {

                var product = new Product()
                {
                    ProductID = Products.Count,
                    Count = rand.Next(10, 1000),
                    Price = Convert.ToDecimal(rand.Next(5, 100000) + rand.NextDouble()),
                    Name = GetRandomName()
                };
                Products.Add(product);
                result.Add(product);
            }
            return result;
        }
        private static string GetRandomName()
        {
            return Guid.NewGuid().ToString().Substring(0,5);
        }
    }
}
