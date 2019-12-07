using System;
using System.Collections.Generic;
using System.Text;

namespace DafCompany.VendingMachine.App.Models
{
    public class ProductStack
    {
        public Product Product { get; set; }
        public int Count { get; set; }

        public ProductStack(Product product, int count)
        {
            Product = product;
            Count = count;
        }
    }
}
