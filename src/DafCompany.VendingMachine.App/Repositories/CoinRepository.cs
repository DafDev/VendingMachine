using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DafCompany.VendingMachine.App.Enumerations;
using DafCompany.VendingMachine.App.Loaders;
using DafCompany.VendingMachine.App.Models;

namespace DafCompany.VendingMachine.App.Repositories
{
    public class CoinRepository : ICoinRepository
    {
        private readonly ICoinLoader _coinLoader;
        private List<CoinRoll> _coinRollsInMemoryRepo;

        public CoinRepository(ICoinLoader coinLoader)
        {
            _coinLoader = coinLoader;
            _coinRollsInMemoryRepo = GetCoinRolls().ToList();
        }

        public CoinRoll GetCoinRoll(CoinDenomination coinDenomination, int count = 100)
        {
            CoinRoll coinRoll = _coinLoader.LoadCoinRoll(coinDenomination, count);
            if (coinRoll != null && _coinRollsInMemoryRepo.Any(c => c.Coin.Denomination == coinDenomination))
            {
                _coinRollsInMemoryRepo
                        .First(c => c.Coin.Denomination == coinDenomination).Count += count;
            }
            else if(coinDenomination != null )
            {
                _coinRollsInMemoryRepo
                    .Add(new CoinRoll(
                        new Coin(coinDenomination, coinDenomination.GetDenominationValue()), count));
            }
            return _coinRollsInMemoryRepo
                        .FirstOrDefault(c => c.Coin.Denomination == coinDenomination); ;
        }

        public IEnumerable<CoinRoll> GetCoinRolls()
        {
            return _coinLoader.LoadAll();
        }

        /// <summary>
        /// Get a list of coins corresponding to an input
        /// </summary>
        /// <param name="change"></param>
        /// <returns>list of Coin objects</returns>
        public IEnumerable<Coin> GetCoins(double change)
        {
            List<Coin> coinsToGiveBack = new List<Coin>();
            if (change < 0)
            {
                return coinsToGiveBack;
            }
            int multiplicationFactor = 100; //This is a mutliplication/precision factor we'll use to manipulate int instead of doubles ofr the rest of the method
            int intChange = (int)(change * multiplicationFactor);
            List<int> coinValuexHundredList = new List<int>();
            foreach (CoinDenomination coinDenomination in _coinRollsInMemoryRepo.Select(d => d.Coin.Denomination).Distinct())
            {
                double coinValuexHundred = coinDenomination.GetDenominationValue() * multiplicationFactor;
                coinValuexHundredList.Add((int)coinValuexHundred);
            }
            coinValuexHundredList = coinValuexHundredList.OrderByDescending(c => c).ToList();
            foreach (var coinValue in coinValuexHundredList)
            {
                if(intChange < coinValue)
                {
                    continue;
                }
                
                int res = intChange / coinValue;
                int mod = intChange % coinValue;
                intChange = mod;
                coinsToGiveBack.AddRange(CoinsToGiveBackByValue(res, coinValue,multiplicationFactor));  
            }
            return coinsToGiveBack;
        }

        private IEnumerable<Coin> CoinsToGiveBackByValue(int numberOfCoins, int coinValue, int multiplicationFactor)
        {
            List<Coin> coins = new List<Coin>();
            double realCoinValue = (double)coinValue / multiplicationFactor;
            for (int i = 0; i < numberOfCoins; i++)
            {
                coins.Add(new Coin(GetDenominationFromValue(realCoinValue), realCoinValue));
            }
            return coins;
        }

        public void PutCoins(double change)
        {
            List<Coin> coins = GetCoins(change).ToList();
            //put coins right in the list()
        }

        private CoinDenomination GetDenominationFromValue(double realCoinValue) => realCoinValue switch
        {
            0.01 => CoinDenomination.Cent1,
            0.02 => CoinDenomination.Cent2,
            0.05 => CoinDenomination.Cent5,
            0.1 => CoinDenomination.Cent10,
            0.2 => CoinDenomination.Cent20,
            0.5 => CoinDenomination.Cent50,
            1 => CoinDenomination.Euro1,
            2 => CoinDenomination.Euro2,

            _ => new CoinDenomination("Not a coin", 100),
        };
    }
}
