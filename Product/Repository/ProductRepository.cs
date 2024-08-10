using Repository.Interfaces;
using DataAccess.Model;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDbContext _context;

        public ProductRepository(ApiDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                throw new InvalidOperationException($"Product with ID {productId} not found.");
            }

            return product;
        }

        public void DeleteProductById(Product product)
        {
            _context.Products.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }

        public void DecrementStock(int id, int quantity)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                throw new InvalidOperationException($"Product with ID {id} not found.");
            }

            if (quantity < 0)
            {
                throw new ArgumentException("Quantity to decrement must be a positive number.", nameof(quantity));
            }

            if (product.Quantity < quantity)
            {
                throw new InvalidOperationException(
                    $"Cannot decrement stock by {quantity} as it would result in negative stock.");
            }

            product.Quantity -= quantity;
        }

        public void AddToStock(int id, int quantity)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                throw new InvalidOperationException($"Product with ID {id} not found.");
            }

            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity to add must be a positive number.", nameof(quantity));
            }

            product.Quantity += quantity;
        }
    }
}