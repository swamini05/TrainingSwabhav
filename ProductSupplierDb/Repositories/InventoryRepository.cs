using Microsoft.EntityFrameworkCore;
using ProductSupplierDb.Data;
using ProductSupplierDb.Exceptions;
using ProductSupplierDb.Models;

namespace ProductSupplierDb.Repositories
{
    internal class InventoryRepository
    {
        static InventoryContext context = new InventoryContext();

        public static Inventory GetById(int id)
        {
            var existingInventory = context.Inventories.FirstOrDefault(p => p.Id == id);
            if (existingInventory == null)
            {
                throw new InventoryNotFoundException("Inventory with the given ID does not exist.");
            }
            return existingInventory;
        }
        public static void GenerateReport()
        {
            var inventories = context.Inventories
                .Include(i => i.Products)
                .Include(i => i.Suppliers)
                .Include(i => i.Transactions)
                .ToList();

            foreach (var inventory in inventories)
            {
                Console.WriteLine(inventory);
                Console.WriteLine();
            }
        }
    }

}
