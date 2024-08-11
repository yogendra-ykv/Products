using Business.Interfaces;
using Business.Models;
using DataAccess.Model;
using Microsoft.CodeAnalysis;
using Repository.Interfaces;

namespace Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository _productRepository;

        public ProductBusiness(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(ProductModel product)
        {
            IsValidProductId(product.Id);
            _productRepository.AddProduct(MapDbProductModel(product));
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            var t = _productRepository.GetAllProducts();
            if (t == null)
            {
                throw new Exception("No Products found");
            }

            return t.Select(MapProductModel);
        }

        public ProductModel GetProductById(int productId)
        {
            IsValidProductId(productId);

            var t = _productRepository.GetProductById(productId);
            if (t == null)
            {
                throw new Exception("Product not found");
            }

            return MapProductModel(t);
        }

        public void DeleteProductById(int productId)
        {
            IsValidProductId(productId);

            var t = _productRepository.GetProductById(productId);
            _productRepository.DeleteProductById(t);
        }

        public void UpdateProduct(ProductModel product)
        {
            IsValidProductId(product.Id);
            _productRepository.UpdateProduct(MapDbProductModel(product));
        }

        public void DecrementStock(int id, int quantity)
        {
            IsValidProductId(id);
            _productRepository.DecrementStock(id, quantity);
        }

        public void AddToStock(int id, int quantity)
        {
            IsValidProductId(id);
            _productRepository.AddToStock(id, quantity);
        }

        private void IsValidProductId(int id)
        {
            if (id < 100000 || id > 999999)
            {
                throw new InvalidOperationException("Product ID must be a 6-digit number.");
            }
        }

        private ProductModel MapProductModel(Product product)
        {
            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity
            };
        }

        private Product MapDbProductModel(ProductModel product)
        {
            return new Product
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity
            };
        }
    }
}