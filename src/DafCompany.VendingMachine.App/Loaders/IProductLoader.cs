using DafCompany.VendingMachine.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DafCompany.VendingMachine.App.Loaders
{
    interface IProductLoader
    {
        IEnumerable<Product> loadAll();
        IEnumerable<Product> loadProduct(int productId);
    }
}
