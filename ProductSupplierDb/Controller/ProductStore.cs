using ProductSupplierDb.Data;
using ProductSupplierDb.Exceptions;
using ProductSupplierDb.Models;
using ProductSupplierDb.Repositories;

namespace ProductSupplierDb.Controller
{
    internal class ProductStore
    {
        static ProductRepository productRepo = new ProductRepository(new InventoryContext());
        static List<Product> products { get; set; } = new List<Product>();

        public static void DisplayMenu()
        {
            Console.WriteLine("\nWelcome to the Product Application");
            while (true)
            {
                Console.WriteLine("\nWhich Operation do you wish to perform\n" +
                    "1.Add a new Product\n" +
                    "2.Update product Details\n" +
                    "3.Delete a Product\n" +
                    "4.View product Details\n" +
                    "5.View all products\n" +
                    "6.Exit\n");

                Console.WriteLine("Enter your choice");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    DoTask(choice);
                }
                catch (DuplicateProductException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (ProductNotFoundException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
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
                    AddProduct();
                    break;
                case 2:
                    Update();
                    break;
                case 3:
                    Delete();
                    break;
                case 4:
                    ProdDetails();
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

        public static void AddProduct()
        {
            Console.WriteLine("Enter the product name");
            string name = Console.ReadLine();
            if (productRepo.GetByName(name) != null)
            {
                throw new DuplicateProductException("Product with this name already exists.");
            }
            Console.WriteLine("Enter the product Description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter the product quantity");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the price of Product");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the Inventory number");
            int inventoryId = Convert.ToInt32(Console.ReadLine());
            var existingInventory = InventoryRepository.GetById(inventoryId);

            var product = new Product
            {
                Name = name,
                Description = description,
                Quantity = quantity,
                Price = price,
                InventoryId = inventoryId
            };

            productRepo.Add(product);
            Console.WriteLine("Product Added Successfully");

        }

        public static void Display()
        {
            var products = productRepo.GetAll();
            products.ForEach(product => Console.WriteLine(product));
        }

        public static void Update()
        {
            Console.WriteLine("Enter the product ID");
            int id = Convert.ToInt32(Console.ReadLine());
            var existingProduct = productRepo.GetById(id);
            Console.WriteLine("Enter the new name of the Product");
            string name = Console.ReadLine();
            if (productRepo.GetByName(name) != null && name != existingProduct.Name)
            {
                throw new DuplicateProductException("Product with this name already exists.");
            }
            Console.WriteLine("Enter the new description of the Product");
            string description = Console.ReadLine();
            Console.WriteLine("Enter the new price of the Product");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the Inventory number");
            int inventoryId = Convert.ToInt32(Console.ReadLine());
            var existingInventory = InventoryRepository.GetById(inventoryId);

            var product = new Product
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price,
                InventoryId = inventoryId
            };

            productRepo.Update(product);
            Console.WriteLine("Product Updated Successfully");
        }

        public static void Delete()
        {
            Console.WriteLine("Enter the product ID");
            int id = Convert.ToInt32(Console.ReadLine());

            productRepo.Delete(id);
            Console.WriteLine("Product Deleted Successfully");
        }
        public static void ProdDetails()
        {
            Console.WriteLine("Enter the product ID");
            int id = Convert.ToInt32(Console.ReadLine());

            var product = productRepo.GetById(id);
            Console.WriteLine(product);
        }
    }
}
