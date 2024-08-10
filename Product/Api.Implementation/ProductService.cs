using Api.Interfaces;
using Api.Models;
using AutoMapper;
using Business.Interfaces;
using DataAccess.Model;

namespace Api.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductBusiness _productBusiness;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ProductService(IProductBusiness productBusiness, IMapper mapper, IUnitOfWork uow)
        {
            _productBusiness = productBusiness;
            _mapper = mapper;
            _uow = uow;
        }

        public void AddProduct(ProductModel product)
        {
            _productBusiness.AddProduct(_mapper.Map<Business.Models.ProductModel>(product));
            _uow.Commit();
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            return _mapper.Map<IEnumerable<ProductModel>>(_productBusiness.GetAllProducts());
        }

        public ProductModel GetProductById(int productId)
        {
            return _mapper.Map<ProductModel>(_productBusiness.GetProductById(productId));
        }

        public void DeleteProductById(int productId)
        {
            _productBusiness.DeleteProductById(productId);
            _uow.Commit();
        }

        public void UpdateProduct(ProductModel product)
        {
            _productBusiness.UpdateProduct(_mapper.Map<Business.Models.ProductModel>(product));
            _uow.Commit();
        }

        public void DecrementStock(int id, int quantity)
        {
            _productBusiness.DecrementStock(id, quantity);
            _uow.Commit();
        }

        public void AddToStock(int id, int quantity)
        {
            _productBusiness.AddToStock(id, quantity);
            _uow.Commit();
        }
    }
}