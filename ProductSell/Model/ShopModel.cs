using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductSell.Model
{
    public class ShopModel
    {
        Random rand = new Random();
        public List<Cash> Cashs { get; set; } = new List<Cash>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();

        Generator generator = new Generator();
        public ShopModel()
        {
            var sellers = generator.GetSeller(20);
            generator.GetProduct(1000);
            generator.GetCustomer(100);

            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }

            for (int i = 0; i < 3; i++)
            {
                Cashs.Add(new Cash(Cashs.Count, Sellers.Dequeue()));
            }
        }
        public void Start()
        {
            var customers = generator.GetCustomer(2);
            var carts = new Queue<Cart>();
            foreach (var customer in customers)
            {
                var cart = new Cart(customer);
                foreach (var product in generator.GetRandomProduct(10, 30))
                {
                    cart.Add(product);
                }
                carts.Enqueue(cart);
            }

            while (carts.Count>0)
            {
                var cash = Cashs[rand.Next(Cashs.Count - 1)];
                cash.Unqueue(carts.Dequeue());
            }
          
            while (true)
            {
                var cash = Cashs[rand.Next(Cashs.Count - 1)];
                var money = cash.Dequeue();
            }
        }
    }
}
