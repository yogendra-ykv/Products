using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProductBusiness
    {
        void AddProduct(ProductModel product);
        IEnumerable<ProductModel> GetAllProducts();
        ProductModel GetProductById(int productId);
        void DeleteProductById(int productId);
        void UpdateProduct(ProductModel product);
        ProductModel DecrementStock(int id, int quantity);
        ProductModel AddToStock(int id, int quantity);
    }
}