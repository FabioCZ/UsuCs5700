using System;
using Cs5700Hw1.Model;
using static System.String;

namespace Cs5700Hw1.Match.Matchers
{
    public class NamePersonMatcher : PersonMatcher
    {
        protected override Predicate<Person> GetPredicate(Person per)
        {
            return p =>
            {
                if (IsNullOrEmpty(p.FirstName) || IsNullOrEmpty(per.FirstName) || IsNullOrEmpty(p.MiddleName)
                    || IsNullOrEmpty(per.MiddleName) || IsNullOrEmpty(p.LastName) || IsNullOrEmpty(per.LastName))
                    return false;
                return (per.FirstName == p.FirstName) && (per.LastName == p.LastName) &&
                       (p.MiddleName == per.MiddleName);
            };
        }
    }
}