using AutoFixture.Xunit2;
using DafCompany.VendingMachine.App.Enumerations;
using System;
using System.Collections.Generic;
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

            //act
            //assert
        }

        [Theory, AutoData]
        public void LoadCoinRoll_Should_Get_Expected_CoinDenomination(CoinDenomination coinDenomination)
        {

        }
    }
}
