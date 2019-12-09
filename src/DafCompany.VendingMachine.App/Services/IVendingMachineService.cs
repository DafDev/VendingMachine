using DafCompany.VendingMachine.App.Models;
using System.Collections.Generic;

namespace DafCompany.VendingMachine.App.Services
{
    public interface IVendingMachineService
    {
        IEnumerable<Product> ShowProducts();
        IEnumerable<Coin> GiveChange(double money);
        Product ChooseProduct(int id);
        double GetMoney(Product product, double input);
        void Run();
    }
}
