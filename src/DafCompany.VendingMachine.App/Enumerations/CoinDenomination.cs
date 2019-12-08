using System;
using System.Globalization;

namespace DafCompany.VendingMachine.App.Enumerations
{
    public class CoinDenomination : CustomEnumeration
    {
        public static readonly CoinDenomination Cent1 = new CoinDenomination("0,01 euro",0);
        public static readonly CoinDenomination Cent2 = new CoinDenomination("0,02 euro",1);
        public static readonly CoinDenomination Cent5 = new CoinDenomination("0,05 euro",2);
        public static readonly CoinDenomination Cent10 = new CoinDenomination("0,1 euro",3);
        public static readonly CoinDenomination Cent20 = new CoinDenomination("0,2 euro",4);
        public static readonly CoinDenomination Cent50 = new CoinDenomination("0,5 euro",5);
        public static readonly CoinDenomination Euro1 = new CoinDenomination("1 euro",6);
        public static readonly CoinDenomination Euro2 = new CoinDenomination("2 euro",7);
        public CoinDenomination(string name, int id) : base(name, id)
        {
        }
        public override string ToString() => Name;
        public double GetDenominationValue()
        {
            string valueAsString = Name.Split(' ')[0];
            return double.TryParse(valueAsString, NumberStyles.AllowDecimalPoint,null,out double value) ? value : 0;
        }
    }
}