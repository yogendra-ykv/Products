using DataAccess.Model;

namespace Repository.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int productId);
        void DeleteProductById(Product product);
        void UpdateProduct(Product product);
        void DecrementStock(int id, int quantity);
        void AddToStock(int id, int quantity);
    }
}