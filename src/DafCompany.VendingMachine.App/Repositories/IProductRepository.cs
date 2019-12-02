using DafCompany.VendingMachine.App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DafCompany.VendingMachine.App.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetParticularProduct();
    }
}
