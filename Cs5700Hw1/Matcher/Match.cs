using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw1.Model;

namespace Cs5700Hw1.Matcher
{
    internal class Match
    {
        public Person Person1 { get; private set; }
        public Person Person2 { get; private set; }

        public Match(Person person1, Person person2)
        {
            Person1 = person1;
            Person2 = person2;
        }

        protected bool Equals(Match other)
        {
            return Equals(Person1, other.Person1) && Equals(Person2, other.Person2) ||
                   Equals(Person1, other.Person2) && Equals(Person2, other.Person1);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Match) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Person1 != null ? Person1.GetHashCode() : 0)*397) ^ (Person2 != null ? Person2.GetHashCode() : 0);
            }
        }

        public override string ToString()
        {
            return $"({Person1.ObjectId}, {Person2.ObjectId})";
        }
    }
}
