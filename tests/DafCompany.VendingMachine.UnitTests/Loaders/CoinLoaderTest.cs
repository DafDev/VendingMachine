using AutoFixture.Xunit2;
using DafCompany.VendingMachine.App.Enumerations;
using DafCompany.VendingMachine.App.Loaders;
using DafCompany.VendingMachine.App.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DafCompany.VendingMachine.UnitTests.Loaders
{
    public class CoinLoaderTest
    {
        [Fact]
        public void LoadAll_Should_Get_All_CoinDenomination()
        {
            //arrange
            CoinLoader changeLoader = new CoinLoader();
            //act
            IEnumerable<CoinRoll> coinRolls = changeLoader.LoadAll();
            //assert
            coinRolls.Select(c => c.Coin.Denomination).Should().AllBeOfType<CoinDenomination>();
        }

        [Theory, AutoData]
        public void LoadCoinRoll_Should_Get_Expected_CoinDenomination_and_100_coins(CoinDenomination coinDenomination)
        {
            CoinLoader changeLoader = new CoinLoader();
            //act
            CoinRoll coinRoll = changeLoader.LoadCoinRoll(coinDenomination);
            //assert
            coinRoll.Coin.Denomination.Should().Be(coinDenomination);
            coinRoll.Count.Should().Be(100);
        }

        [Theory]
        [InlineData(100)]
        public void LoadAll_Gets_ExpectedNumber_Of_Coins_Per_CoinRoll(int expectedNumberOfCoins)
        {
            CoinLoader changeLoader = new CoinLoader();
            IEnumerable<CoinRoll> coinRolls = changeLoader.LoadAll(expectedNumberOfCoins);
            coinRolls.Select(p => p.Count).Should().AllBeEquivalentTo(expectedNumberOfCoins);
        }
    }
}
