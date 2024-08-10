using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("addproduct")]
        public void AddProduct([FromBody] ProductModel product)
        {
            _productService.AddProduct(product);
        }

        [HttpGet("getallproducts")]
        public IEnumerable<ProductModel> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }

        [HttpGet("getproductbyid/{productId:int}")]
        public ProductModel GetProductById(int productId)
        {
            return _productService.GetProductById(productId);
        }

        [HttpDelete("deleteproductbyid/{productId:int}")]
        public void DeleteProductById(int productId)
        {
            _productService.DeleteProductById(productId);
        }

        [HttpPut("updateproduct")]
        public void UpdateProduct([FromBody] ProductModel product)
        {
            _productService.UpdateProduct(product);
        }

        [HttpPut("decrement-stock/{id}/{quantity} ")]
        public void DecrementStock(int id, int quantity)
        {
            _productService.DecrementStock(id, quantity);
        }

        [HttpPut("add-to-stock/{id}/{quantity} ")]
        public void AddToStock(int id, int quantity)
        {
            _productService.AddToStock(id, quantity);
        }
    }
}