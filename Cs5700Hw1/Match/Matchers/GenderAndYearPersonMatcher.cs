using System;
using Cs5700Hw1.Model;
using static System.String;

namespace Cs5700Hw1.Match.Matchers
{
    public class GenderAndYearPersonMatcher : PersonMatcher
    {
        protected override Predicate<Person> GetPredicate(Person per)
        {
            return p =>
            {
                if (IsNullOrEmpty(p.FirstName) || IsNullOrEmpty(per.FirstName) || IsNullOrEmpty(p.LastName) ||
                    IsNullOrEmpty(per.LastName))
                    return false;

                if ((p.FirstName != per.FirstName) && (p.LastName != per.LastName))
                    return false;

                if (IsNullOrEmpty(p.Gender) || (p.BirthYear == null) || IsNullOrEmpty(per.Gender) ||
                    (per.BirthYear == null))
                    return false;

                return (p.Gender == per.Gender) && (p.BirthYear == per.BirthYear);

                return false;
            };
        }
    }
}