using DafCompany.VendingMachine.App.Enumerations;
using DafCompany.VendingMachine.App.Models;
using System.Collections.Generic;

namespace DafCompany.VendingMachine.App.Loaders
{
    public interface IChangeLoader
    {
        IEnumerable<CoinRoll> loadAll();
        IEnumerable<CoinRoll> loadCoinRoll(CoinDenomination coinDenomination);
    }
}