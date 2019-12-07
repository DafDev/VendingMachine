using System;
using System.Collections.Generic;
using System.Linq;
using DafCompany.VendingMachine.App.Enumerations;
using DafCompany.VendingMachine.App.Models;

namespace DafCompany.VendingMachine.App.Loaders
{
    public class CoinLoader : ICoinLoader
    {
        public IEnumerable<CoinRoll> LoadAll(int numberOfLoadedCoins = 100)
        {
            return new List<CoinRoll>
            {
                new CoinRoll(new Coin(CoinDenomination.Cent1, 0.01), numberOfLoadedCoins),
                new CoinRoll(new Coin(CoinDenomination.Cent2, 0.02), numberOfLoadedCoins),
                new CoinRoll(new Coin(CoinDenomination.Cent5, 0.05), numberOfLoadedCoins),
                new CoinRoll(new Coin(CoinDenomination.Cent10, 0.1), numberOfLoadedCoins),
                new CoinRoll(new Coin(CoinDenomination.Cent20, 0.2), numberOfLoadedCoins),
                new CoinRoll(new Coin(CoinDenomination.Cent50, 0.5), numberOfLoadedCoins),
                new CoinRoll(new Coin(CoinDenomination.Euro1, 1d), numberOfLoadedCoins),
                new CoinRoll(new Coin(CoinDenomination.Euro2, 2d), numberOfLoadedCoins)
            };
        }

        public CoinRoll LoadCoinRoll(CoinDenomination coinDenomination, int numberOfLoadedCoins = 100)
        {
            double coinValue = coinDenomination != null ? coinDenomination.GetDenominationValue() : 0;
            return new CoinRoll(new Coin(coinDenomination, coinValue), 100);
        }
    }
}
