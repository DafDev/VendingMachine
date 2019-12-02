using DafCompany.VendingMachine.App.Models;
using System.Collections.Generic;

namespace DafCompany.VendingMachine.App.Services
{
    public interface IVendingMachine
    {
        void GetMoney(double money);
        IEnumerable<Coin> GiveChange();
        Product SellProduct(int id);
    }
}
