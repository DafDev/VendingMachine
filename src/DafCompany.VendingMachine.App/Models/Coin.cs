using DafCompany.VendingMachine.App.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DafCompany.VendingMachine.App.Models
{
    public class Coin
    {
        public Coin(CoinDenomination denomination, double value)
        {
            Denomination = denomination;
            Value = value;
        }

        public CoinDenomination Denomination { get; set; }
        public double Value { get; set; }
    }
}
