using ProductSupplierDb.Data;
using ProductSupplierDb.Repositories;

namespace ProductSupplierDb.Controller
{
    internal class TransactionStore
    {
        static TransactionRepository transactionRepo = new TransactionRepository(new InventoryContext());

        public TransactionStore(TransactionRepository transactionrepo)
        {
            transactionRepo = transactionrepo;
        }

        public static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine($"Transaction Menu:\n" +
                    "1. Add Stock\n" +
                    "2. Remove Stock\n" +
                    "3. View Transaction History\n" +
                    "4. Go Back to Main Menu");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStock();
                        break;
                    case "2":
                        RemoveStock();
                        break;
                    case "3":
                        ViewTransactionHistory();
                        break;
                    case "4":
                        InventoryStore.InventoryMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        private static void AddStock()
        {
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());
            Console.Write("Enter Quantity to Add: ");
            int quantity = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter the Inventory number");
            //int inventoryId = Convert.ToInt32(Console.ReadLine());
            try
            {
                transactionRepo.AddStock(productId, quantity);
                Console.WriteLine("Stock added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RemoveStock()
        {
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());
            Console.Write("Enter Quantity to Remove: ");
            int quantity = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter the Inventory number");
            //int inventoryId = Convert.ToInt32(Console.ReadLine());
            try
            {
                transactionRepo.RemoveStock(productId, quantity);
                Console.WriteLine("Stock removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ViewTransactionHistory()
        {
            var transactions = transactionRepo.GetAll();
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}

