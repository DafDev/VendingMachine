using System;
using System.Collections.Generic;
using System.Text;

namespace DafCompany.VendingMachine.App.Models
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }
    }
}
