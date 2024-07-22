using System.Configuration;
using SerializationPersonList.Models;
using System.IO;
using System.Text.Json;

namespace SerializationPersonList
{
    internal class Program
    {
        static string filePath = ConfigurationManager.AppSettings["filePath"].ToString();
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>
            {
                new Person(1, "Swamini Chaudhari", "swamini@gmail.com"),
                new Person(2, "Sampada Bhadane", "sam@gmail.com"),
                new Person(3, "Swati Padmanabhan", "swati@gmail.com"),
                new Person(4, "Akshay Jain", "akshay@gmail.com"),
                new Person(5, "Tushar Chaudhari", "tushar@gmail.com")
            };
            DeserializeObject();
            SerializeObject(personList);
        }
        static void SerializeObject(List<Person> personList)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(JsonSerializer.Serialize(personList));
                Console.WriteLine("Person object written to file");
            }
        }
        static void DeserializeObject()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist.");
                return;
            }
            using (StreamReader sr = new StreamReader(filePath,true))
            {
                List<Person> personList = JsonSerializer.Deserialize<List<Person>>(sr.ReadToEnd());
                Console.WriteLine($"No of Persons : {personList.Count}");
                personList.ForEach(person => Console.WriteLine(person));
            }
        }
    }
}
