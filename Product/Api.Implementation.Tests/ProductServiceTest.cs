using Api.Interfaces;
using Api.Models;
using AutoMapper;
using Business.Interfaces;
using DataAccess.Model;
using Moq;

namespace Api.Implementation.Tests
{
    [TestClass]
    public class ProductServiceTest
    {
        private IProductService _sut = null!;
        private Mock<IProductBusiness> _mockProductBusiness = null!;
        private Mock<IMapper> _mockMapper = null!;
        private Mock<IUnitOfWork> _mockUow = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockProductBusiness = new Mock<IProductBusiness>();
            _mockMapper = new Mock<IMapper>();
            _mockUow = new Mock<IUnitOfWork>();
            SetupMapper();
            _sut = new ProductService(_mockProductBusiness.Object, _mockMapper.Object, _mockUow.Object);
        }

        [TestMethod]
        public void GetAllProducts_Called_BusinessCalled()
        {
            _sut.GetAllProducts();
            _mockProductBusiness.Verify(m => m.GetAllProducts(), Times.Once);
        }

        [TestMethod]
        public void AddProduct_Called_BusinessCalled()
        {
            _sut.AddProduct(new ProductModel() { Id = 1000000, Name = "test", Quantity = 10 });
            _mockProductBusiness.Verify(m => m.AddProduct(It.IsAny<Business.Models.ProductModel>()), Times.Once);
        }

        [TestMethod]
        public void GetProductById_Called_BusinessCalled()
        {
            _sut.GetProductById(1000000);
            _mockProductBusiness.Verify(m => m.GetProductById(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void DeleteProductById_Called_BusinessCalled()
        {
            _sut.DeleteProductById(1000000);
            _mockProductBusiness.Verify(m => m.DeleteProductById(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void UpdateProduct_Called_BusinessCalled()
        {
            _sut.UpdateProduct(new ProductModel() { Id = 1000000, Name = "test", Quantity = 10 });
            _mockProductBusiness.Verify(m => m.UpdateProduct(It.IsAny<Business.Models.ProductModel>()), Times.Once);
        }

        [TestMethod]
        public void AddToStock_Called_BusinessCalled()
        {
            _sut.AddToStock(1000000, 12);
            _mockProductBusiness.Verify(m => m.AddToStock(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void DecrementStock_Called_BusinessCalled()
        {
            _sut.DecrementStock(1000000, 12);
            _mockProductBusiness.Verify(m => m.DecrementStock(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        private void SetupMapper()
        {
            _mockMapper.Setup(m => m.Map<ProductModel>(It.IsAny<ProductModel>())).Returns(new ProductModel());
            _mockMapper.Setup(m => m.Map<Business.Models.ProductModel>(It.IsAny<ProductModel>()))
                .Returns(new Business.Models.ProductModel());
            _mockMapper.Setup(m =>
                    m.Map<IEnumerable<ProductModel>>(It.IsAny<IEnumerable<Business.Models.ProductModel>>()))
                .Returns(new List<ProductModel>());
            _mockMapper.Setup(m =>
                    m.Map<IEnumerable<Business.Models.ProductModel>>(It.IsAny<IEnumerable<ProductModel>>()))
                .Returns(new List<Business.Models.ProductModel>());
        }
    }
}