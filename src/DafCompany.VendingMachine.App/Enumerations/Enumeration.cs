using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DafCompany.VendingMachine.App.Enumerations
{
    public class Enumeration : IComparable
    {
        public string Name { get; private set; }
        public int Id { get; private set; }

        protected Enumeration(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public override string ToString() => Name;
        public static IEnumerable<T> GetAll<T>() where T : Enumeration
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
            return Id.CompareTo(((Enumeration)other).Id);
        }

        public override bool Equals(object obj)
        {
            Enumeration otherValue = obj as Enumeration;

            if(otherValue == null)
            {
                return false;
            }

            bool typeMatches = GetType().Equals(obj.GetType());
            bool idMatches = Id.Equals(otherValue.Id);

            return typeMatches && idMatches;
        }

        public static bool operator ==(Enumeration left, Enumeration right)
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

        public static bool operator !=(Enumeration left, Enumeration right)
        {
            return !(left == right);
        }

        public static bool operator >(Enumeration left, Enumeration right)
        {
            throw new NotImplementedException();
        }

        public static bool operator <(Enumeration left, Enumeration right)
        {
            throw new NotImplementedException();
        }
        public static bool operator >=(Enumeration left, Enumeration right)
        {
            throw new NotImplementedException();
        }

        public static bool operator <=(Enumeration left, Enumeration right)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
