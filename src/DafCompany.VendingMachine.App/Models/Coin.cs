using DafCompany.VendingMachine.App.Enumerations;
using System;

namespace DafCompany.VendingMachine.App.Models
{
    public class Coin : IEquatable<Coin>
    {
        public CoinDenomination Denomination { get; set; }
        public double Value { get; set; }

        public Coin(CoinDenomination denomination, double value)
        {
            Denomination = denomination;
            Value = value;
        }

        public bool Equals(Coin other)
        {
            //Check whether the compared object is null. 
            if (ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data. 
            if (ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal. 
            return Denomination.Equals(other.Denomination) && Value.Equals(other.Value);
        }

        // If Equals() returns true for a pair of objects  
        // then GetHashCode() must return the same value for these objects. 
        public override int GetHashCode()
        {
            //Get hash code for the Name field if it is not null. 
            int hashCoinDenomination = Denomination == null ? 0 : Denomination.Name.GetHashCode();

            //Get hash code for the Code field. 
            int hashCoinValue = Value.GetHashCode();

            //Calculate the hash code for the product. 
            return hashCoinDenomination ^ hashCoinValue;
        }
    }
}
