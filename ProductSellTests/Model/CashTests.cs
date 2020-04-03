using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductSell.Model.Tests
{
    [TestClass()]
    public class CashTests
    {
        [TestMethod()]
        public void CashTest()
        {
            //arrange
            var customer1 = new Customer()
            {
                Name = "testuser1",
                CustomerID = 1
            };
            var customer2 = new Customer()
            {
                Name = "testuser2",
                CustomerID = 2
            };

            var seller = new Seller()
            {
                Name = "sellername",
                SellerID = 1
            };
            var product1 = new Product()
            {
                ProductID = 1,
                Name = "pr1",
                Price = 100,
                Count = 10
            };
            var product2 = new Product()
            {
                ProductID = 2,
                Name = "prod2",
                Price = 200,
                Count = 20
            };

            var cart1 = new Cart(customer1);
            cart1.Add(product1);
            cart1.Add(product1);
            cart1.Add(product2);

            var cart2 = new Cart(customer2);
            cart2.Add(product1);
            cart2.Add(product2);
            cart2.Add(product2);

            var cash = new Cash(1, seller);
            cash.Unqueue(cart1);
            cash.Unqueue(cart2);

            var cart1ExectedResult = 400;
            var cart2ExectedResult = 500;

            //act
            var cart1ActualResult = cash.Dequeue();
          //  var cart2ActualResult = cash.Dequeue();

            //assert
            Assert.AreEqual(cart1ExectedResult, cart1ActualResult);
          //  Assert.AreEqual(cart2ExectedResult, cart2ActualResult);
//            Assert.AreEqual(7, product1.Count);
          //  Assert.AreEqual(17, product2.Count);
        }
    }
}