using Microsoft.AspNetCore.Mvc;
using ProductsApp.Models;

namespace ProductsApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Potato Soup", Category = "Schmoceries", Price = 42 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        public ProductsController(Product[] products)
        {
            this.products = products;
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
