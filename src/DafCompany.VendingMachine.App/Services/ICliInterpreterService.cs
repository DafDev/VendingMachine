namespace DafCompany.VendingMachine.App.Services
{
    public interface ICliInterpreterService
    {
        double CheckInputMoney(double price);
        int GetProductIdFromClient(System.Collections.Generic.IEnumerable<Models.Product> products);
        void PrintChange(System.Collections.Generic.IEnumerable<Models.Coin> change);
    }
}