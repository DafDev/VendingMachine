using DafCompany.VendingMachine.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DafCompany.VendingMachine.App.Loaders
{
    public interface IProductLoader
    {
        IEnumerable<ProductStack> LoadAll(int numberOfLoadedProducts = 100);
        ProductStack LoadProduct(Product product, int numberOfLoadedProducts = 100);
    }
}
