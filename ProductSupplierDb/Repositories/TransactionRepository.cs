using ProductSupplierDb.Data;
using ProductSupplierDb.Exceptions;
using ProductSupplierDb.Models;

namespace ProductSupplierDb.Repositories
{
    internal class TransactionRepository
    {
        private readonly InventoryContext _context;

        public TransactionRepository(InventoryContext context)
        {
            _context = context;
        }

        // Add stock to a product
        public void AddStock(int productId, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new ProductNotFoundException("Product not found.");

            product.Quantity += quantity;

            var transaction = new Transaction
            {
                ProductId = productId,
                Type = "Add Stock",
                Quantity = quantity,
                Date = DateTime.Now,
                //InventoryId = inventoryId
            };

            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        // Remove stock from a product
        public void RemoveStock(int productId, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new ProductNotFoundException("Product not found.");

            if (product.Quantity < quantity)
                throw new InvalidOperationException("Not enough stock to remove.");

            product.Quantity -= quantity;

            var transaction = new Transaction
            {
                ProductId = productId,
                Type = "Remove Stock",
                Quantity = quantity,
                Date = DateTime.Now,
                //InventoryId = inventoryId
            };

            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
        public List<Transaction> GetAll()
        {
            return _context.Transactions.ToList();
        }
    }

}
