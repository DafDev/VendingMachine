using System;
using System.Collections.Generic;
using System.Text;
using DafCompany.VendingMachine.App.Models;

namespace DafCompany.VendingMachine.App.Loaders
{
    public class ProductLoader : IProductLoader
    {
        public IEnumerable<ProductStack> LoadAll(int numberOfLoadedProducts = 100)
        {
            throw new NotImplementedException();
        }

        public ProductStack LoadProduct(int productId, int numberOfLoadedProducts = 100)
        {
            throw new NotImplementedException();
        }
    }
}
