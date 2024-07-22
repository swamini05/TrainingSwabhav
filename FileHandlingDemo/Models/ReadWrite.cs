using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandlingDemo.Models
{
    internal class ReadWrite
    {
        static string filePath = "D:\\Training\\FileHandlingDemo\\";
        public static void WriteToFile()
        {
            Console.WriteLine("Enter the file name to write to:");
            string fileName = Console.ReadLine();

            Console.WriteLine("Enter the content to write:");
            string content = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(filePath+fileName))
            {
                writer.Write(content);
            }
            Console.WriteLine($"Content written to {fileName}.");
        }
        public static void ReadFromFile()
        {
            Console.WriteLine("Enter the file path to read from:");
            string fileName = Console.ReadLine();
            if (!File.Exists(filePath+fileName))
            {
                Console.WriteLine("create a file first then read it!");
                return;
            }
            using (StreamReader reader = new StreamReader(filePath+fileName))
            {
                Console.WriteLine("File content:");
                Console.WriteLine(reader.ReadToEnd());
            }
        }
        public static void AddUserName()
        {
            Console.WriteLine("Enter your username: ");
            string username = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(filePath+"Usernametest.txt", append: true))
            {
                writer.WriteLine(username);
            }
            Console.WriteLine("Username has been written to the file.");
        }
    }
}
