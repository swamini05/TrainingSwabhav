using ProductSupplierDb.Data;
using ProductSupplierDb.Exceptions;
using ProductSupplierDb.Models;
using ProductSupplierDb.Repositories;

namespace ProductSupplierDb.Controller
{
    internal class SupplierStore
    {


        static SupplierRepository supplierRepo = new SupplierRepository(new InventoryContext());
        static List<Supplier> suppliers { get; set; } = new List<Supplier>();

        public static void DisplayMenu()
        {
            Console.WriteLine("\nWelcome to the Supplier Application\n");
            while (true)
            {
                Console.WriteLine("\nWhich Operation do you wish to perform\n" +
                    "1.Add a new Supplier\n" +
                    "2.Update supplier Details\n" +
                    "3.Delete a Supplier\n" +
                    "4.View supplier Details\n" +
                    "5.View all suppliers\n" +
                    "6.Exit\n");

                Console.WriteLine("Enter your choice");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    DoTask(choice);
                }
                catch (SupplierNotFoundException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (DuplicateSupplierException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (InventoryNotFoundException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                }
            }
        }

        private static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddSupplier();
                    break;
                case 2:
                    Update();
                    break;
                case 3:
                    Delete();
                    break;
                case 4:
                    SupplierDetails();
                    break;
                case 5:
                    Display();
                    break;
                case 6:
                    InventoryStore.InventoryMenu();
                    break;
                default:
                    Console.WriteLine("Enter a valid input");
                    break;
            }
        }

        public static void AddSupplier()
        {
            Console.WriteLine("Enter the supplier Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the product Contact Information");
            string contactinfo = Console.ReadLine();
            Console.WriteLine("Enter the Inventory number");
            int inventoryId = Convert.ToInt32(Console.ReadLine());
            var existingInventory = InventoryRepository.GetById(inventoryId);

            var supplier = new Supplier
            {
                Name = name,
                ContactInfo = contactinfo,
                InventoryId = inventoryId
            };

            supplierRepo.Add(supplier);
            Console.WriteLine("Supplier Added Successfully");

        }

        public static void Display()
        {
            var suppliers = supplierRepo.GetAll();
            suppliers.ForEach(supplier => Console.WriteLine(supplier));
        }

        public static void Update()
        {
            Console.WriteLine("Enter the supplier ID");
            int id = Convert.ToInt32(Console.ReadLine());
            var existingSupplier = supplierRepo.GetById(id);
            Console.WriteLine("Enter the new name of the Supplier");
            string name = Console.ReadLine();
            if (supplierRepo.GetByName(name) != null && name != existingSupplier.Name)
            {
                throw new DuplicateSupplierException("Another supplier with this name already exists.");
            }
            Console.WriteLine("Enter the new contactinfo of the Supplier");
            string contactinfo = Console.ReadLine();
            Console.WriteLine("Enter the Inventory number");
            int inventoryId = Convert.ToInt32(Console.ReadLine());
            var existingInventory = InventoryRepository.GetById(inventoryId);

            var supplier = new Supplier
            {
                Id = id,
                Name = name,
                ContactInfo = contactinfo,
                InventoryId = inventoryId
            };

            supplierRepo.Update(supplier);
            Console.WriteLine("Supplier Updated Successfully");
        }

        public static void Delete()
        {
            Console.WriteLine("Enter the supplier ID");
            int id = Convert.ToInt32(Console.ReadLine());

            supplierRepo.Delete(id);
            Console.WriteLine("Supplier Deleted Successfully");
        }

        public static void SupplierDetails()
        {
            Console.WriteLine("Enter the supplier ID");
            int id = Convert.ToInt32(Console.ReadLine());

            var supplier = supplierRepo.GetById(id);
            Console.WriteLine(supplier);
        }
    }
}
