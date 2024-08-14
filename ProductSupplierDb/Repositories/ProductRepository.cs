using ProductSupplierDb.Data;
using ProductSupplierDb.Exceptions;
using ProductSupplierDb.Models;

namespace ProductSupplierDb.Repositories
{
    internal class ProductRepository
    {
        private readonly InventoryContext _context;
        public ProductRepository(InventoryContext context)
        {
            _context = context;
        }
        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }
        public Product GetById(int id)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                throw new ProductNotFoundException("Product with the given ID does not exist.");
            }
            return existingProduct;
        }
        public Product GetByName(string name)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Name == name);
            return existingProduct;
        }

        public void Add(Product product)
        {
            //if (_context.Products.Any(p => p.Name == product.Name))
            //    throw new DuplicateProductException("Product with this name already exists.");

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            var existingProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.InventoryId = product.InventoryId;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                throw new ProductNotFoundException("Product not found.");

            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
