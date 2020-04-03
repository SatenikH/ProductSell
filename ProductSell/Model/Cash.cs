using System;
using System.Collections.Generic;

namespace ProductSell.Model
{
    public class Cash
    {
        ProductContext db = new ProductContext();
        public int Number { get; set; }
        public Seller Seller { get; set; }
        public Queue<Cart> Queue { get; set; }
        public int MaxQueueCount { get; set; }
        public int ExitCustomer { get; set; }
        public bool IsModel { get; set; }
        public object Enqueue { get; set; }
        public int Count => Queue.Count;
        public Cash(int number, Seller seller)
        {
            Number = number;
            Seller = seller;
            Queue = new Queue<Cart>();
            IsModel = true;
        }
        public void Unqueue(Cart Cart)
        {
            if (Queue.Count <= MaxQueueCount)
                Queue.Enqueue(Cart);
            ExitCustomer++;
        }
        public decimal Dequeue()
        {
            decimal sum = 0;
            if (Queue.Count == 0 )
            {
                return 0;
            }
            var cart = Queue.Dequeue();
            if (cart != null)
            {
                var check = new Check()
                {
                    SellerID = Seller.SellerID,
                    Seller = Seller,
                    CustomerID = cart.Customer.CustomerID,
                    Customer = cart.Customer,
                    Created = DateTime.Now
                };
                if (!IsModel)
                {
                    db.Checks.Add(check);
                    db.SaveChanges();
                }
                else
                    check.CheckID = 0;

                var sells = new List<Sell>();

                foreach (Product product in cart)
                {
                    if (product.Count > 0)
                    {
                        var sell = new Sell()
                        {
                            CheckID = check.CheckID,
                            Check = check,
                            ProductID = product.ProductID,
                            Product = product
                        };

                        sells.Add(sell);
                        if (!IsModel)
                            db.Sells.Add(sell);

                        product.Count--;
                        sum += product.Price;
                    }
                }
                if (!IsModel)
                    db.SaveChanges();
            }
            return sum;
        }
    }
}
