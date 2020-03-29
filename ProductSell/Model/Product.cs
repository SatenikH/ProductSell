using System.Collections.Generic;

namespace ProductSell.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Sell> Sells { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
