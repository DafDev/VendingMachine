using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DafCompany.VendingMachine.App.Enumerations
{
    public class CustomEnumeration : IComparable
    {
        public string Name { get; private set; }
        public int Id { get; private set; }

        protected CustomEnumeration(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public override string ToString() => Name;
        public static IEnumerable<T> GetAll<T>() where T : CustomEnumeration
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |
                                             BindingFlags.Static |
                                             BindingFlags.DeclaredOnly);
            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public int CompareTo(object other)
        {
            if(other == null)
            {
                return -1;
            }
            return Id.CompareTo(((CustomEnumeration)other).Id);
        }

        public override bool Equals(object obj)
        {
            CustomEnumeration otherValue = obj as CustomEnumeration;

            if (ReferenceEquals(otherValue, null)) return false;

            if (ReferenceEquals(this, otherValue)) return true;

            bool typeMatches = GetType().Equals(obj?.GetType());
            bool idMatches = Id.Equals(otherValue.Id);
            bool nameMatches = Name.Equals(otherValue.Name, StringComparison.InvariantCulture);
            return typeMatches && idMatches && nameMatches;
        }

        public static bool operator ==(CustomEnumeration left, CustomEnumeration right)
        {
            if(ReferenceEquals(left,right))
            {
                return true;
            }
            else
            {
                return left?.Id == right?.Id && left.Name == right.Name;
            }
        }

        public static bool operator !=(CustomEnumeration left, CustomEnumeration right)
        {
            return !(left == right);
        }

        public static bool operator >(CustomEnumeration left, CustomEnumeration right)
        {
            throw new NotImplementedException();
        }

        public static bool operator <(CustomEnumeration left, CustomEnumeration right)
        {
            throw new NotImplementedException();
        }
        public static bool operator >=(CustomEnumeration left, CustomEnumeration right)
        {
            throw new NotImplementedException();
        }

        public static bool operator <=(CustomEnumeration left, CustomEnumeration right)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
