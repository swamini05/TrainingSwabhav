using ProductSupplierDb.Repositories;

namespace ProductSupplierDb.Controller
{
    internal class InventoryStore
    {
        public static void InventoryMenu()
        {
            while (true)
            {
                Console.WriteLine("Which menu do you want?\n" +
                    "1. Product Management\n" +
                    "2. Supplier Management\n" +
                    "3. Transaction Management\n" +
                    "4. Generate Report\n" +
                    "5. Exit");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ProductStore.DisplayMenu();
                        break;
                    case 2:
                        SupplierStore.DisplayMenu();
                        break;
                    case 3:
                        TransactionStore.DisplayMenu();
                        break;
                    case 4:
                        InventoryRepository.GenerateReport();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
