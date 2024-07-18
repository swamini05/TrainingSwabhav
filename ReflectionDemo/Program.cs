using ReflectionDemo.Models;

namespace ReflectionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reflector reflector = new Reflector();

            // Show details for Object class
            reflector.ShowDetails(typeof(Object));

            // Show details for Account class
            reflector.ShowDetails(typeof(Account));

            // Show details for Customer class
            reflector.ShowDetails(typeof(Customer));
        }
    }
}
