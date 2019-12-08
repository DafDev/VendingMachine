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
        public IEnumerable<Product> ShowProduct()
        {
            return _productRepository.GetProducts();
        }

        /// <summary>
        /// Launches the vending machine service.
        /// </summary>
        public void Run()
        {
            Console.WriteLine($"Welcome to Daf's Vending Machine\nHere are our fabulous product!");
            foreach (Product product in ShowProduct())
            {
                Console.WriteLine($"Id: {product.Id}\tName: {product.Name}\tPrice: {product.Price} €");
            }
            Console.WriteLine($"Type the id of the product you want to buy: ");
            string chosenProductStringId = Console.ReadLine();
            int chosenProductId;
            while (!int.TryParse(chosenProductStringId, out chosenProductId))
            {
                Console.WriteLine($"Invalid entry!!\nType the id of the product you want to buy: ");
                chosenProductStringId = Console.ReadLine();
            }
            Product chosenProduct = ChooseProduct(chosenProductId);
            if (chosenProduct != null)
            {
                Console.WriteLine($"You chose a {chosenProduct.Name} which costs {chosenProduct.Price} euros");
                Console.WriteLine("Pay up!");
                double inputMoney;
                while (!double.TryParse(Console.ReadLine(), out inputMoney))
                {
                    Console.WriteLine($"Invalid entry!!\nI don't accept monkey change");
                }
                Console.WriteLine($"Here is your {chosenProduct.Name} and your change which consists in");
                IEnumerable<Coin> change = GiveChange(GetMoney(chosenProduct, inputMoney));
                foreach (Coin coin in change.Select(c => c).Distinct())
                {
                    Console.WriteLine($"{change.Where(c => c.Value == coin.Value).Count()} " +
                        $"coin(s) of {coin.Denomination.ToString()}");
                }
                Console.WriteLine($"For a total of {inputMoney - chosenProduct.Price} euros");
            }
            else
            {
                Console.WriteLine("This product doesn't exist!");
            }
            Console.ReadLine();
        }
    }
}
