using AutoFixture.Xunit2;
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
    public class ProductLoaderTest
    {
        [Fact]
        public void LoadAll_Should_Get_Only_ProductStacks()
        {
            //arrange
            ProductLoader productLoader = new ProductLoader();
            //act
            IEnumerable<ProductStack> products = productLoader.LoadAll();
            //assert
            products.Should().AllBeOfType<ProductStack>();
        }

        [Theory, AutoData]
        public void LoadProduct_Should_Get_Expected_Product_and_100_Product(Product product1)
        {
            ProductLoader productLoader = new ProductLoader();
            //act
            ProductStack productStack = productLoader.LoadProduct(product1);
            //assert
            productStack.Product.Should().Be(product1);
            productStack.Count.Should().Be(100);
        }

        [Theory]
        [InlineData(100)]
        public void LoadAll_Gets_ExpectedNumber_Of_Coins_Per_CoinRoll(int expectedNumberOfProducts)
        {
            ProductLoader productLoader = new ProductLoader();
            IEnumerable<ProductStack> coinRolls = productLoader.LoadAll(expectedNumberOfProducts);
            coinRolls.Select(p => p.Count).Should().AllBeEquivalentTo(expectedNumberOfProducts);
        }
    }
}
