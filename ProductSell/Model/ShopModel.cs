using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ProductSell.Model
{
    public class ShopModel
    {
        Random rand = new Random();
        bool IsStart = false;
        public List<Cash> Cashs { get; set; } = new List<Cash>();
        public List<Check> Checks { get; set; } = new List<Check>();
        public List<Cart> Carts { get; set; } = new List<Cart>();
        public List<Sell> Sells { get; set; } = new List<Sell>();
        public Queue<Seller> Sellers { get; set; } = new Queue<Seller>();

        Generator generator = new Generator();
        public ShopModel()
        {
            var sellers = generator.GetSeller(8);
            generator.GetProduct(100);
            generator.GetCustomer(20);

            foreach (var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }

            for (
                int i = 0; i < 3; i++)
            {
                Cashs.Add(new Cash(Cashs.Count, Sellers.Dequeue()));
            }
        }
        public async void Start()
        {
            IsStart = true;
            Task.Run(() => CreateCarts(10, 1000));

            var cashTask = Cashs.Select(c => new Task(() => CashStart(c, 1000)));
            foreach (var task in cashTask)
            {
                task.Start();
            }
        }
        public void Stop()
        {
            IsStart = false;
        }
        private void CreateCarts(int count, int sleep)
        {
            while (IsStart)
            {
                var customers = generator.GetCustomer(count);

                foreach (var customer in customers)
                {
                    var cart = new Cart(customer);
                    foreach (var product in generator.GetRandomProduct(10, 30))
                    {
                        cart.Add(product);
                    }
                    var cash = Cashs[rand.Next(Cashs.Count - 1)];
                    cash.Unqueue(cart);
                }
                Thread.Sleep(sleep);
            }
        }
        private void CashStart(Cash cash, int sleep)
        {
            while (IsStart)
            {
                if (cash.Count > 0)
                {
                    cash.Dequeue();
                    Thread.Sleep(sleep);
                }
            }
        }

    }
}
