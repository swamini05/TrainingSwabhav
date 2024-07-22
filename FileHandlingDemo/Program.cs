using FileHandlingDemo.Models;

namespace FileHandlingDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter:\n1. To write to a file \n" +
                    "2. To read from a file\n" +
                    "3. To add username to the file\n" +
                    "4. Exit");
                int action = Convert.ToInt32(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        ReadWrite.WriteToFile();
                        break;
                    case 2:
                        ReadWrite.ReadFromFile();
                        break;
                    case 3:
                        ReadWrite.AddUserName();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid action, please try again.\n");
                        break;
                }
            }
        }
    }
}
