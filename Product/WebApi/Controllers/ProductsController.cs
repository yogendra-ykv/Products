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
        public IActionResult AddProduct([FromBody] ProductModel product)
        {
            try
            {
                _productService.AddProduct(product);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("getallproducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("getproductbyid/{productId:int}")]
        public IActionResult GetProductById(int productId)
        {
            try
            {
                var product = _productService.GetProductById(productId);
                return Ok(product);
            }
            catch (KeyNotFoundException keyEx)
            {
                return StatusCode(200, keyEx.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("deleteproductbyid/{productId:int}")]
        public IActionResult DeleteProductById(int productId)
        {
            try
            {
                _productService.DeleteProductById(productId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Product with ID {productId} not found.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("updateproduct")]
        public IActionResult UpdateProduct([FromBody] ProductModel product)
        {
            try
            {
                _productService.UpdateProduct(product);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("decrement-stock/{id}/{quantity}")]
        public IActionResult DecrementStock(int id, int quantity)
        {
            try
            {
                var product = _productService.DecrementStock(id, quantity);
                return Ok(product);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("add-to-stock/{id}/{quantity}")]
        public IActionResult AddToStock(int id, int quantity)
        {
            try
            {
                var product = _productService.AddToStock(id, quantity);
                return Ok(product);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}