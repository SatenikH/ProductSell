using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ProductSell.Model.Tests
{
    [TestClass()]
    public class CartTests
    {
        [TestMethod()]
        public void CartTest()
        {
            //Arrange
            var customer = new Customer()
            {
                CustomerID = 1,
                Name = "testuser"
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

            var cart = new Cart(customer);

            var expectedResule = new List<Product>()
            { 
                product1, product1, product2
            };

            //Act
            cart.Add(product1);
            cart.Add(product1);
            cart.Add(product2);

            var cartResult = cart.GetAll();

            //Assert
            Assert.AreEqual(expectedResule.Count, cartResult.Count);
            for (int i = 0; i < expectedResule.Count; i++)
            {
                Assert.AreEqual(expectedResule[i], cartResult[i]);
            }
        }
    }
}
