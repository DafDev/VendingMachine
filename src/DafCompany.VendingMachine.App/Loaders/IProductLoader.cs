using DafCompany.VendingMachine.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DafCompany.VendingMachine.App.Loaders
{
    interface IProductLoader
    {
        IEnumerable<Product> LoadAll(int numberOfLoadedProducts = 100);
        IEnumerable<Product> LoadProduct(int productId, int numberOfLoadedProducts = 100);
    }
}
