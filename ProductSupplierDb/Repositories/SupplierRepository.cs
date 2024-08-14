using ProductSupplierDb.Data;
using ProductSupplierDb.Exceptions;
using ProductSupplierDb.Models;

namespace ProductSupplierDb.Repositories
{
    internal class SupplierRepository
    {
        private readonly InventoryContext _context;
        public SupplierRepository(InventoryContext context)
        {
            _context = context;
        }

        public List<Supplier> GetAll()
        {
            return _context.Suppliers.ToList();
        }
        public Supplier GetById(int id)
        {
            var existingSupplier = _context.Suppliers.FirstOrDefault(s => s.Id == id);
            if (existingSupplier == null)
            {
                throw new SupplierNotFoundException("Supplier with the given ID does not exist.");
            }
            return existingSupplier;
        }
        public Supplier GetByName(string name)
        {
            var existingSupplier = _context.Suppliers.FirstOrDefault(s => s.Name == name);
            return existingSupplier;
        }

        public void Add(Supplier supplier)
        {
            //if (_context.Suppliers.Any(s => s.Name == supplier.Name))
            //    throw new DuplicateSupplierException("Supplier with this name already exists.");

            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void Update(Supplier supplier)
        {
            var existingSupplier = _context.Suppliers.FirstOrDefault(s => s.Id == supplier.Id);
            //if (existingSupplier == null)
            //    throw new SupplierNotFoundException("Supplier not found.");

            //if (_context.Suppliers.Any(s => s.Name == supplier.Name && s.Id != supplier.Id))
            //    throw new DuplicateSupplierException("Another supplier with this name already exists.");

            existingSupplier.Name = supplier.Name;
            existingSupplier.ContactInfo = supplier.ContactInfo;
            existingSupplier.InventoryId = supplier.InventoryId;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier == null)
                throw new SupplierNotFoundException("Supplier not found.");

            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
        }
    }
}
