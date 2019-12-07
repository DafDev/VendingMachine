using DafCompany.VendingMachine.App.Enumerations;
using DafCompany.VendingMachine.App.Models;
using System.Collections.Generic;

namespace DafCompany.VendingMachine.App.Loaders
{
    public interface ICoinLoader
    {
        IEnumerable<CoinRoll> LoadAll(int numberOfLoadedCoins = 100);
        CoinRoll LoadCoinRoll(CoinDenomination coinDenomination, int numberOfLoadedCoins = 100);
    }
}