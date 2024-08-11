using Business.Models;
using DataAccess.Model;
using Moq;
using Repository.Interfaces;

namespace Business.Tests
{
    [TestClass]
    public class ProductBusinessTest
    {
        private Mock<IProductRepository> _mockProductRepository = null!;
        private ProductBusiness _sut = null!;

        [TestInitialize]
        public void Setup()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _mockProductRepository.Setup(x => x.GetProductById(It.IsAny<int>()))
                .Returns(new Product() { Id = 110011, Name = "test", Quantity = 21 });
            _sut = new ProductBusiness(_mockProductRepository.Object);
        }

        [TestMethod]
        public void GetAllProducts_Called_VerifyRepoCalled()
        {
            _sut.GetAllProducts();
            _mockProductRepository.Verify(m => m.GetAllProducts(), Times.Once);
        }

        [TestMethod]
        public void AddProduct_Called_VerifyRepoCalled()
        {
            _sut.AddProduct(new ProductModel() { Id = 100111, Name = "test", Quantity = 1 });
            _mockProductRepository.Verify(m => m.AddProduct(It.IsAny<Product>()), Times.Once);
        }


        [TestMethod]
        public void GetProductById_Called_VerifyRepoCalled()
        {
            _sut.GetProductById(100000);
            _mockProductRepository.Verify(m => m.GetProductById(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void DeleteProductById_Called_VerifyRepoCalled()
        {
            _sut.DeleteProductById(100000);
            _mockProductRepository.Verify(m => m.DeleteProductById(It.IsAny<Product>()), Times.Once);
        }

        [TestMethod]
        public void UpdateProduct_Called_VerifyRepoCalled()
        {
            _sut.UpdateProduct(new ProductModel() { Id = 100000, Name = "test", Quantity = 10 });
            _mockProductRepository.Verify(m => m.UpdateProduct(It.IsAny<Product>()), Times.Once);
        }

        [TestMethod]
        public void AddToStock_Called_VerifyRepoCalled()
        {
            _sut.AddToStock(100000, 12);
            _mockProductRepository.Verify(m => m.GetProductById(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void DecrementStock_Called_VerifyRepoCalled()
        {
            _sut.DecrementStock(100000, 12);
            _mockProductRepository.Verify(m => m.GetProductById(It.IsAny<int>()), Times.Once);
        }
    }
}