namespace DafCompany.VendingMachine.App.Models
{
    public class CoinRoll
    {
        public Coin Coin { get; set; }
        public int Count { get; set; }

        public CoinRoll(Coin coin, int count)
        {
            Coin = coin;
            Count = count;
        }
    }
}
