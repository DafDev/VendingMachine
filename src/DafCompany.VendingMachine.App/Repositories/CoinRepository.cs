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

        public IEnumerable<Coin> GetCoins(double change)
        {
            return new List<Coin>();
        }
    }
}
