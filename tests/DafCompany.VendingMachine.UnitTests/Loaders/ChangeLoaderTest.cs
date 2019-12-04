﻿using AutoFixture.Xunit2;
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
    public class ChangeLoaderTest
    {
        [Fact]
        public void LoadAll_Should_Get_All_CoinDenomination()
        {
            //arrange
            ChangeLoader changeLoader = new ChangeLoader();
            //act
            IEnumerable<CoinRoll> coinRolls = changeLoader.LoadAll();
            //assert
            coinRolls.Select(c => c.Coin.Denomination).Should().AllBeOfType<CoinDenomination>();
        }

        [Theory, AutoData]
        public void LoadCoinRoll_Should_Get_Expected_CoinDenomination_and_100_coins(CoinDenomination coinDenomination)
        {
            ChangeLoader changeLoader = new ChangeLoader();
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
            ChangeLoader changeLoader = new ChangeLoader();
            IEnumerable<CoinRoll> coinRolls = changeLoader.LoadAll(expectedNumberOfCoins);
            coinRolls.Select(p => p.Count).Should().AllBeEquivalentTo(expectedNumberOfCoins);
        }
    }
}
