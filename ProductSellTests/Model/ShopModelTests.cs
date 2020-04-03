using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductSell.Model.Tests
{
    [TestClass()]
    public class ShopModelTests
    {
        [TestMethod()]
        public void ShopModelTest()
        {
            var model = new ShopModel();
            model.Start();
        }
    }
}