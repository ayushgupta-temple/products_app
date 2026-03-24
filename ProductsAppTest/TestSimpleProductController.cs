using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsApp.Controllers;
using ProductsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ProductsApp.Tests
{
    [TestClass]
    public class TestSimpleProductController
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductsController(testProducts);

            var result = controller.GetAllProducts().ToArray();

            Assert.AreEqual(testProducts.Length, result.Length);
        }

        [TestMethod]
        public void GetProduct_ShouldReturnCorrectProduct()
        {
            var testProducts = GetTestProducts();
            var controller = new ProductsController(testProducts);

            var actionResult = controller.GetProduct(4);
            var okResult = actionResult.Result as OkObjectResult;

            Assert.IsNotNull(okResult);

            var product = okResult.Value as Product;
            Assert.IsNotNull(product);
            Assert.AreEqual(testProducts[3].Name, product.Name);
        }

        [TestMethod]
        public void GetProduct_ShouldNotFindProduct()
        {
            var controller = new ProductsController(GetTestProducts());

            var actionResult = controller.GetProduct(999);
            var notFoundResult = actionResult.Result as NotFoundResult;

            Assert.IsNotNull(notFoundResult);
        }

        private Product[] GetTestProducts()
        {
            return new Product[]
            {
                new Product { Id = 1, Name = "Demo1", Price = 1 },
                new Product { Id = 2, Name = "Demo2", Price = 3.75M },
                new Product { Id = 3, Name = "Demo3", Price = 16.99M },
                new Product { Id = 4, Name = "Demo4", Price = 11.00M },
            };
        }
    }
}
