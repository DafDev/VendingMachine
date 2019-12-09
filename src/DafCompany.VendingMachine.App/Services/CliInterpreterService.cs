using DafCompany.VendingMachine.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DafCompany.VendingMachine.App.Services
{
    public class CliInterpreterService : ICliInterpreterService
    {
        public double CheckInputMoney(double price)
        {
            double inputMoney = 0d;
            while (inputMoney < price)
            {
                if (!double.TryParse(Console.ReadLine(), out double money))
                {
                    Console.WriteLine($"Invalid entry!!\nI don't accept monkey change");
                    continue;
                }
                Console.WriteLine($"This is not enough! Put more coins!");
                inputMoney += money;
            }
            return inputMoney;
        }

        public int GetProductIdFromClient(IEnumerable<Product> products)
        {
            Console.WriteLine($"Welcome to Daf's Vending Machine\nHere are our fabulous product!");
            foreach (Product product in products)
            {
                Console.WriteLine($"Id: {product.Id}\tName: {product.Name}\tPrice: {product.Price} €");
            }
            Console.WriteLine($"Type the id of the product you want to buy: ");
            int chosenProductId;
            while (!int.TryParse(Console.ReadLine(), out chosenProductId))
            {
                Console.WriteLine($"Invalid entry!!\nType the id of the product you want to buy: ");
            }
            return chosenProductId;
        }
        
        public void PrintChange(IEnumerable<Coin> change)
        {
            foreach (Coin coin in change.Select(c => c).Distinct())
            {
                Console.WriteLine($"{change.Where(c => c.Value == coin.Value).Count()} " +
                    $"coin(s) of {coin.Denomination.ToString()}");
            }
        }
    }
}
