using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DafCompany.VendingMachine.App.Models;
using DafCompany.VendingMachine.App.Repositories;

namespace DafCompany.VendingMachine.App.Services
{
    public class VendingMachineService : IVendingMachineService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICliInterpreterService _cliInterpreterService;
        private readonly ICoinRepository _coinRepository;

        public VendingMachineService(ICoinRepository coinRepository,
            IProductRepository productRepository, ICliInterpreterService cliInterpreterService)
        {
            _coinRepository = coinRepository;
            _productRepository = productRepository;
            _cliInterpreterService = cliInterpreterService;
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
        /// gives back change
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
        public IEnumerable<Product> ShowProducts()
        {
            return _productRepository.GetProducts();
        }

        /// <summary>
        /// Launches the vending machine service.
        /// </summary>
        public void Run()
        {
            IEnumerable<Product> products = ShowProducts();
            Product chosenProduct = ChooseProduct(
                _cliInterpreterService.GetProductIdFromClient(products));
            while (chosenProduct == null)
            {
                Console.WriteLine("This product doesn't exist!");
                chosenProduct = ChooseProduct(
                    _cliInterpreterService.GetProductIdFromClient(products));
            }
            Console.WriteLine($"You chose a {chosenProduct.Name} which costs {chosenProduct.Price} euros");
            Console.WriteLine("Pay up!");
            double inputMoney = _cliInterpreterService.CheckInputMoney(chosenProduct.Price);
            Console.WriteLine($"Here is your {chosenProduct.Name} and your change which consists in");
            _cliInterpreterService.PrintChange(GiveChange(GetMoney(chosenProduct, inputMoney)));
            Console.WriteLine($"For a total of {inputMoney - chosenProduct.Price} euros");
            Console.ReadLine();
        }
    }
}
