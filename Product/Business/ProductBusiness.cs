using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Repository.Interfaces;

namespace Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductBusiness(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void AddProduct(ProductModel product)
        {
            _productRepository.AddProduct(_mapper.Map<DataAccess.Model.Product>(product));
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
            var t = _productRepository.GetProductById(productId);
            if (t == null)
            {
                throw new Exception("Product not found");
            }

            return MapProductModel(t);
        }

        public void DeleteProductById(int productId)
        {
            var t = _productRepository.GetProductById(productId);
            if (t != null)
            {
                _productRepository.DeleteProductById(t);
            }
        }

        public void UpdateProduct(ProductModel product)
        {
            _productRepository.UpdateProduct(_mapper.Map<DataAccess.Model.Product>(product));
        }

        public void DecrementStock(int id, int quantity)
        {
            _productRepository.DecrementStock(id, quantity);
        }

        public void AddToStock(int id, int quantity)
        {
            _productRepository.AddToStock(id, quantity);
        }

        private ProductModel MapProductModel(DataAccess.Model.Product product)
        {
            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity
            };
        }
    }
}