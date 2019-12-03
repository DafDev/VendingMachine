namespace DafCompany.VendingMachine.App.Enumerations
{
    public class CoinDenomination : Enumeration
    {
        public static readonly CoinDenomination Cent1 = new CoinDenomination("0,01 euro",0);
        public static readonly CoinDenomination Cent2 = new CoinDenomination("0,02 euro",0);
        public static readonly CoinDenomination Cent5 = new CoinDenomination("0,05 euro",0);
        public static readonly CoinDenomination Cent10 = new CoinDenomination("0,1 euro",0);
        public CoinDenomination(string name, int id) : base(name, id)
        {
        }
    }
}