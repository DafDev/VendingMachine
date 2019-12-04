using DafCompany.VendingMachine.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DafCompany.VendingMachine.App.Loaders
{
    interface IProductLoader
    {
        IEnumerable<ProductStack> LoadAll(int numberOfLoadedProducts = 100);
        ProductStack LoadProduct(int productId, int numberOfLoadedProducts = 100);
    }
}
