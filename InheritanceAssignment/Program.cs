using InheritanceAssignment.Models;

namespace InheritanceAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(101, "Kalyan", new DateOnly(2002, 10, 21));
            Professor professor = new Professor(201, "Dombivli", new DateOnly(1975, 5, 15),50000);
            Student student = new Student(301, "Thane", new DateOnly(2000, 8, 30),"Computer");

            PrintPersonDetails(person);
            PrintPersonDetails(professor);
            PrintPersonDetails(student);

        }
        static void PrintPersonDetails(Person person)
        {
            Console.WriteLine($"\n=============={person.GetType().Name}===============");
            Console.WriteLine(person.PrintDetails());
        }
    }
}
