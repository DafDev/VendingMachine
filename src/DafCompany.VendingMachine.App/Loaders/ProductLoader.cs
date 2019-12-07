using System;
using System.Collections.Generic;
using DafCompany.VendingMachine.App.Models;

namespace DafCompany.VendingMachine.App.Loaders
{
    public class ProductLoader : IProductLoader
    {
        public IEnumerable<ProductStack> LoadAll(int numberOfLoadedProducts = 100)
        {
            Product snickers = new Product("Snickers", 2.5);
            Product coke = new Product("Coca-Cola", 1.25);
            Product lays = new Product("Lays", 2);
            Product dragibus = new Product("Dragibus", 1.30);
            return new List<ProductStack>
            {
                new ProductStack(snickers, numberOfLoadedProducts),
                new ProductStack(coke, numberOfLoadedProducts),
                new ProductStack(lays, numberOfLoadedProducts),
                new ProductStack(dragibus, numberOfLoadedProducts),
            };
        }

        public ProductStack LoadProduct(Product product, int numberOfLoadedProducts = 100)
        {
            return new ProductStack(product, numberOfLoadedProducts);
        }
    }
}
