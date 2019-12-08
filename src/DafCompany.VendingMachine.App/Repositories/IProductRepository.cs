using DafCompany.VendingMachine.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DafCompany.VendingMachine.App.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<ProductStack> StoreProductsFromLoader();
        Product GetProduct(int id);
        ProductStack GetProductStackFromLoader(Product product, int count);
        IEnumerable<Product> GetProducts();
    }
}
