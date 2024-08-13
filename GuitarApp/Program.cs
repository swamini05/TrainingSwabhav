using GuitarApp.Models;


namespace GuitarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();


            inventory.AddGuitar(new Guitar("SN12345", 1500.00, new GuitarSpecs { Builder = Builder.Martin, GuitarType = GuitarType.Electric, BackWood = Wood.Mahogany, TopWood = Wood.Maple }));
            inventory.AddGuitar(new Guitar("SN23456", 1200.00, new GuitarSpecs { Builder = Builder.Fender, GuitarType = GuitarType.Electric, BackWood = Wood.Mahogany, TopWood = Wood.Mahogany }));
            inventory.AddGuitar(new Guitar("SN34567", 1800.00, new GuitarSpecs { Builder = Builder.Ibanez, GuitarType = GuitarType.Electric, BackWood = Wood.Maple, TopWood = Wood.Maple }));
            inventory.AddGuitar(new Guitar("SN45678", 1700.00, new GuitarSpecs { Builder = Builder.Fender, GuitarType = GuitarType.Electric, BackWood = Wood.Mahogany, TopWood = Wood.Maple }));
            inventory.AddGuitar(new Guitar("SN56789", 1300.00, new GuitarSpecs { Builder = Builder.Martin, GuitarType = GuitarType.Acoustic, BackWood = Wood.Brazilian_Rosewood, TopWood = Wood.Mahogany }));


            Console.WriteLine("\nSearching for Electric guitars made by Gibson with Maple top wood and Mahogany back wood...");
            GuitarSpecs searchSpecs = new GuitarSpecs { Builder = Builder.Gibson, GuitarType = GuitarType.Electric, BackWood = Wood.Mahogany, TopWood = Wood.Maple };
            List<Guitar> matchingGuitars = inventory.Search(searchSpecs);


            if (matchingGuitars.Count > 0)
            {
                Console.WriteLine("Matching Guitars:");
                foreach (var guitar in matchingGuitars)
                {
                    DisplayGuitar(guitar);
                }
            }
            else
            {
                Console.WriteLine("No guitars match the search criteria.");
            }
        }

        static void DisplayGuitar(Guitar guitar)
        {
            Console.WriteLine($"Serial Number: {guitar.SerialNumber}, Price: ${guitar.Price}");
            Console.WriteLine($"Builder: {guitar.GuitarSpecs.Builder}, Type: {guitar.GuitarSpecs.GuitarType}");
            Console.WriteLine($"Top Wood: {guitar.GuitarSpecs.TopWood}, Back Wood: {guitar.GuitarSpecs.BackWood}");
            Console.WriteLine();
        }
    }
}










//internal class Program
//{
//    static void Main(string[] args)
//    {
//        Inventory inventory = new Inventory();
//        bool exit = false;

//        while (!exit)
//        {
//            Console.WriteLine("\nGuitar Inventory System");
//            Console.WriteLine("1. Add a Guitar");
//            Console.WriteLine("2. Search Guitars");
//            Console.WriteLine("3. Search Guitar by Serial Number");
//            Console.WriteLine("4. Exit");
//            Console.Write("Select an option (1-4): ");

//            string choice = Console.ReadLine();

//            switch (choice)
//            {
//                case "1":
//                    AddGuitar(inventory);
//                    break;

//                case "2":
//                    SearchGuitars(inventory);
//                    break;

//                case "3":
//                    SearchGuitarBySerialNumber(inventory);
//                    break;

//                case "4":
//                    exit = true;
//                    break;

//                default:
//                    Console.WriteLine("Invalid selection. Please choose a valid option.");
//                    break;
//            }
//        }
//    }

//    static void AddGuitar(Inventory inventory)
//    {
//        Console.Write("Enter Serial Number: ");
//        string serialNumber = Console.ReadLine();

//        Console.Write("Enter Price: ");
//        if (!double.TryParse(Console.ReadLine(), out double price))
//        {
//            Console.WriteLine("Invalid price format.");
//            return;
//        }

//        Console.Write("Enter Builder: ");
//        string builder = Console.ReadLine();

//        Console.Write("Enter Model: ");
//        string model = Console.ReadLine();

//        Console.Write("Enter Type: ");
//        string type = Console.ReadLine();

//        Console.Write("Enter Backwood: ");
//        string backwood = Console.ReadLine();

//        Console.Write("Enter Topwood: ");
//        string topwood = Console.ReadLine();

//        Guitar guitar = new Guitar(serialNumber, price, builder, model, type, backwood, topwood);
//        inventory.AddGuitar(guitar);

//        Console.WriteLine("Guitar added successfully.");
//    }

//    static void SearchGuitars(Inventory inventory)
//    {
//        Console.Write("Enter Builder (or leave empty to skip): ");
//        string builder = Console.ReadLine();

//        Console.Write("Enter Model (or leave empty to skip): ");
//        string model = Console.ReadLine();

//        Console.Write("Enter Type (or leave empty to skip): ");
//        string type = Console.ReadLine();

//        Console.Write("Enter Backwood (or leave empty to skip): ");
//        string backwood = Console.ReadLine();

//        Console.Write("Enter Topwood (or leave empty to skip): ");
//        string topwood = Console.ReadLine();

//        List<Guitar> matchingGuitars = inventory.Search(
//            string.IsNullOrWhiteSpace(builder) ? null : builder,
//            string.IsNullOrWhiteSpace(model) ? null : model,
//            string.IsNullOrWhiteSpace(type) ? null : type,
//            string.IsNullOrWhiteSpace(backwood) ? null : backwood,
//            string.IsNullOrWhiteSpace(topwood) ? null : topwood
//        );

//        if (matchingGuitars.Count == 0)
//        {
//            Console.WriteLine("No matching guitars found.");
//        }
//        else
//        {
//            Console.WriteLine("Matching Guitars:");
//            foreach (Guitar guitar in matchingGuitars)
//            {
//                Console.WriteLine($"Serial Number: {guitar.SerialNumber}, Builder: {guitar.Builder}, Model: {guitar.Model}, Type: {guitar.Type}, Backwood: {guitar.Backwood}, Topwood: {guitar.Topwood}, Price: {guitar.Price}");
//            }
//        }
//    }

//    static void SearchGuitarBySerialNumber(Inventory inventory)
//    {
//        Console.Write("Enter Serial Number: ");
//        string serialNumber = Console.ReadLine();
//        Guitar guitar = inventory.GetGuitar(serialNumber);

//        if (guitar != null)
//        {
//            Console.WriteLine($"Guitar found: Serial Number: {guitar.SerialNumber}, Builder: {guitar.Builder}, Model: {guitar.Model}, Type: {guitar.Type}, Backwood: {guitar.Backwood}, Topwood: {guitar.Topwood}, Price: {guitar.Price}");
//        }
//        else
//        {
//            Console.WriteLine("No guitar found with the given serial number.");
//        }
//    }
//}
