using AutoFixture.Xunit2;
using DafCompany.VendingMachine.App.Enumerations;
using DafCompany.VendingMachine.App.Loaders;
using DafCompany.VendingMachine.App.Models;
using DafCompany.VendingMachine.App.Repositories;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DafCompany.VendingMachine.UnitTests.Repositories
{
    public class CoinRepositoryTest
    {
        [Theory, AutoData]
        public void GetCoinRolls_Returns_All_CoinDenonimination(int numberOfLoadedCoins)
        {
            //arrange
            ICoinLoader coinLoader = Substitute.For<ICoinLoader>();
            List<CoinRoll> coins = new List<CoinRoll>
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
            coinLoader.LoadAll().Returns(coins);
            CoinRepository coinRepository = new CoinRepository(coinLoader);
            //act
            var expected = coinRepository.GetCoinRolls();
            //assert
            expected.Should().NotBeNull().And.NotBeEmpty()
                .And.Contain(r => r.Coin.Denomination == CoinDenomination.Cent1)
                .And.Contain(r => r.Coin.Denomination == CoinDenomination.Cent2)
                .And.Contain(r => r.Coin.Denomination == CoinDenomination.Cent5)
                .And.Contain(r => r.Coin.Denomination == CoinDenomination.Cent10)
                .And.Contain(r => r.Coin.Denomination == CoinDenomination.Cent20)
                .And.Contain(r => r.Coin.Denomination == CoinDenomination.Cent50)
                .And.Contain(r => r.Coin.Denomination == CoinDenomination.Euro1)
                .And.Contain(r => r.Coin.Denomination == CoinDenomination.Euro2);
        }

        [Theory, AutoData]
        public void GetCoinRoll_Returns_Expected_CoinDenonimination(int numberOfLoadedCoins)
        {
            //arrange
            CoinDenomination coinDenomination = CoinDenomination.Cent1;
            ICoinLoader coinLoader = Substitute.For<ICoinLoader>();
            CoinRoll coinRoll = new CoinRoll(new Coin(coinDenomination, 0.01), numberOfLoadedCoins);
            coinLoader.LoadCoinRoll(coinDenomination).Returns(coinRoll);
            CoinRepository coinRepository = new CoinRepository(coinLoader);
            //act
            var expected = coinRepository.GetCoinRoll(coinDenomination);
            //assert
            expected.Should().Be(coinRoll);
        }

        [Theory, AutoData]
        public void GetCoins_CoinsSum_Returns_Same_Value_As_Expected(double change)
        {
            //arrange
            int numberOfLoadedCoins = 100;
            ICoinLoader coinLoader = Substitute.For<ICoinLoader>();
            List<CoinRoll> coins = new List<CoinRoll>
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
            coinLoader.LoadAll().Returns(coins);
            CoinRepository coinRepository = new CoinRepository(coinLoader);
            //act
            List<Coin> coinList = coinRepository.GetCoins(0).ToList();
            double expected = 0;
            coinList.ForEach(c => expected += c.Value);
            //assert
            expected.Should().Be(expected);
        }

        [Fact]
        public void GetCoins_Returns_Empty_If_Change_Null()
        {
            //arrange
            int numberOfLoadedCoins = 100;
            ICoinLoader coinLoader = Substitute.For<ICoinLoader>();
            List<CoinRoll> coins = new List<CoinRoll>
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
            coinLoader.LoadAll().Returns(coins);
            CoinRepository coinRepository = new CoinRepository(coinLoader);
            //act
            var expected = coinRepository.GetCoins(0);
            //assert
            expected.Should().BeEmpty();
        }
    }
}
