using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProductApp.Models
{
    internal class Product
    {
        private int _id;
        private string _name;
        private int _price;
        private double _discountPercentage;

        //public int GetId() { return _id; }
        //public string GetName() { return _name; }
        //public int GetPrice() { return _price; }
        //public double GetDiscountPercentage() { return _discountPercentage; }

        //public int SetId(int id) { _id = id; return _id; }
        //public string SetName(string name) { _name = name; return _name; }
        //public int SetPrice(int price) { _price = price; return _price; }
        //public double SetDiscountPercentage(double discountPercentage) { _discountPercentage = discountPercentage; return _discountPercentage; }

        public int Id { set { _id = value; } get { return _id; } }
        public string Name { set { _name = value; } get { return _name; } }
        public int Price { set { _price = value; } get { return _price; } }

        public double DiscountPercentage {
            set
            {
                _discountPercentage = value;
                {
                    if (value > 0.4)
                        _discountPercentage = 0.4;
                    else if (value < 0.2) _discountPercentage = 0.2;
                    else _discountPercentage = value;
                }
            }
            get { return _discountPercentage; } 

        }
        public double CalculateDiscountedPrice()
        {
            return _price * (1 - _discountPercentage / 100);
        }

    }
}
