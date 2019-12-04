using System;
using System.Collections.Generic;
using System.Text;

namespace DafCompany.VendingMachine.UnitTests.Loaders
{
    public class ProductLoaderTest
    {
        [Fact]
        public void LoadAll_Should_Get_All_CoinDenomination()
        {
            //arrange
            ProductLoader productLoader = new ProductLoader();
            //act
            IEnumerable<CoinRoll> coinRolls = productLoader.LoadAll();
            //assert
            coinRolls.Select(c => c.Coin.Denomination).Should().AllBeOfType<CoinDenomination>();
        }

        [Theory, AutoData]
        public void LoadCoinRoll_Should_Get_Expected_CoinDenomination_and_100_coins(Product product)
        {
            ProductLoader productLoader = new ProductLoader();
            //act
            CoinRoll coinRoll = productLoader.LoadCoinRoll(product);
            //assert
            coinRoll.Coin.Denomination.Should().Be(product);
            coinRoll.Count.Should().Be(100);
        }

        [Theory]
        [InlineData(100)]
        public void LoadAll_Gets_ExpectedNumber_Of_Coins_Per_CoinRoll(int expectedNumberOfProducts)
        {
            ProductLoader productLoader = new ProductLoader();
            IEnumerable<CoinRoll> coinRolls = productLoader.LoadAll(expectedNumberOfProducts);
            coinRolls.Select(p => p.Count).Should().AllBeEquivalentTo(expectedNumberOfProducts);
        }
    }
}
