using System.Data.Entity;

namespace ProductSell.Model
{
    public class ProductContext:DbContext
    {
        public ProductContext():base("ProdSell"){}
        public DbSet<Check> Checks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sell> Sells { get; set; }
    }
}
