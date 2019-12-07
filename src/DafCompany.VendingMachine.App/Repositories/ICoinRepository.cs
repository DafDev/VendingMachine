using DafCompany.VendingMachine.App.Enumerations;
using DafCompany.VendingMachine.App.Models;
using System.Collections.Generic;

namespace DafCompany.VendingMachine.App.Repositories
{
    public interface ICoinRepository
    {
        IEnumerable<CoinRoll> GetCoinRolls();
        CoinRoll GetCoinRoll(CoinDenomination coinDenomination, int count = 100);
    }
}
