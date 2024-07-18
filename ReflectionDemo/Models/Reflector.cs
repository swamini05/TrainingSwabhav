using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo.Models
{
    internal class Reflector
    {
        public void ShowDetails(Type type)
        {
            MethodInfo[] methods = type.GetMethods();
            ConstructorInfo[] constructors = type.GetConstructors();
            PropertyInfo[] properties = type.GetProperties();

            Console.WriteLine($"Type: {type.Name}\n"+
                $"Number of Methods: {methods.Length}\n"+
                $"Number of Constructors: {constructors.Length}\n"+
                $"Number of Properties: {properties.Length}\n");
        }
    }
}
