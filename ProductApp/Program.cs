using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ProductApp.Models;

namespace ProductApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product();
            SetProductDetails(product1, 1, "Product A", 1000, 0.2);



            Product product2 = new Product();
            SetProductDetails(product2, 2, "Product B", 500, 0.6);

            DisplayProductDetails(product1);
            DisplayProductDetails(product2);
        }

        static void SetProductDetails(Product product, int id, string name, int price, double discountPercentage)
        {
            product.Id = id;
            product.Name= name;
            product.Price = price;
            product.DiscountPercentage = discountPercentage;
            product.CalculateDiscountedPrice();
           
        }
        static void DisplayProductDetails(Product product)
        {
            Console.WriteLine($"Product ID: {product.Id}\n" +
                $"Product Name: {product.Name} \n" +
                $"Product Price: {product.Price} \n" +
                $"Discount Percentage: {product.DiscountPercentage} \n" +
                $"Price After Discount: {product.CalculateDiscountedPrice()} \n");


        }
    }
}