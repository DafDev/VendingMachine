using System;
using System.Collections.Generic;
using System.Text;
using DafCompany.VendingMachine.App.Models;
using DafCompany.VendingMachine.App.Repositories;

namespace DafCompany.VendingMachine.App.Services
{
    public class VendingMachineService : IVendingMachineService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICoinRepository _coinRepository;

        public VendingMachineService(ICoinRepository coinRepository,
            IProductRepository productRepository)
        {
            _coinRepository = coinRepository;
            _productRepository = productRepository;
        }
        /// <summary>
        /// choose the product
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Chosen Product</returns>
        public Product ChooseProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        /// <summary>
        /// Get the price for the product calculate the change
        /// put the money in the coin repo
        /// </summary>
        /// <param name="product"></param>
        /// <returns>The change: the difference between the product's price and the given money</returns>
        public double GetMoney(Product product, double input)
        {
            _coinRepository.PutCoins(input);
            return product != null ? input - product.Price : -1d;
        }

        /// <summary>
        /// give back change
        /// </summary>
        /// <param name="money"></param>
        /// <returns>a list of coins (POCO Coin)</returns>
        public IEnumerable<Coin> GiveChange(double money)
        {
            if (money < 0)
            {
                return new List<Coin>();
            }
            return _coinRepository.GetCoins(money);
        }

        /// <summary>
        /// show the product 
        /// </summary>
        /// <returns>A list aof product to be displayed on the CLI</returns>
        public IEnumerable<Product> ShowProduct()
        {
            return _productRepository.GetProducts();
        }
    }
}
