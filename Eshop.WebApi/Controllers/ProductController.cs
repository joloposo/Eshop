using Eshop.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly List<Product?> Products = new()
        {
            new Product(1, "Product 1", "Description 1", 10.0m),
            new Product(2, "Product 2", "Description 2", 20.0m),
            new Product(3, "Product 3", "Description 3", 30.0m)
        };

        [HttpGet]
        public IEnumerable<Product?> GetProducts()
        {
            return Products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(string title, string description, decimal price)
        {
            var newId = Products.Max(p => p.Id) + 1;
            var product = new Product(newId, title, description, price);

            Products.Add(product);
            return product;
        }

        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(int id, string title, string description, decimal price)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            product.Update(title, description, price);
            return product;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            Products.Remove(product);
            return Ok();
        }
    }
}
