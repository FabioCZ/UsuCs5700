using System.Collections.Generic;
using Cs5700Hw1.Model;

namespace Cs5700Hw1.Match
{
    public class Match
    {
        public Match(Person person1, Person person2)
        {
            Person1 = person1;
            Person2 = person2;
        }

        public Person Person1 { get; }
        public Person Person2 { get; }

        protected bool Equals(Match other)
        {
            return (Person1.Equals(other.Person1) && Person2.Equals(other.Person2)) ||
                   (Person1.Equals(other.Person2) && Person2.Equals(other.Person1));
        }

        public override bool Equals(object obj)
        {
            return Equals((Match) obj);
        }

        public override int GetHashCode()
        {
            return 1; //aaah, don't have time to do a good hashcode, so instead forcing .net to fallback to .Equals().
        }

        public override string ToString()
        {
            return $"({Person1.ObjectId}, {Person2.ObjectId})";
        }
    }

    public class MatchComparer : EqualityComparer<Match>
    {
        public override bool Equals(Match x, Match y)
        {
            return x.Equals(y);
        }

        public override int GetHashCode(Match obj)
        {
            return obj.GetHashCode();
        }
    }
}