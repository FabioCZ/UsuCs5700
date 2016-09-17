using System;
using Cs5700Hw1.Model;
using static System.String;

namespace Cs5700Hw1.Match.Matchers
{
    public class MotherPersonMatcher : PersonMatcher
    {
        protected override Predicate<Person> GetPredicate(Person per)
        {
            return p =>
            {
                if (!(p is Child) || !(per is Child))
                    return false;
                var pChild = p as Child;
                var perChild = per as Child;

                if (IsNullOrEmpty(pChild.MotherFirstName) || IsNullOrEmpty(perChild.MotherFirstName)
                    || IsNullOrEmpty(pChild.MotherLastName) || IsNullOrEmpty(perChild.MotherLastName)
                    || IsNullOrEmpty(pChild.IsPartOfMultipleBirth) || IsNullOrEmpty(perChild.IsPartOfMultipleBirth)
                    || (pChild.BirthOrder == null) || (pChild.BirthOrder < 1) || (perChild.BirthOrder == null) ||
                    (pChild.BirthOrder < 1))
                    return false;

                return (pChild.MotherFirstName == perChild.MotherFirstName) &&
                       (pChild.MotherLastName == perChild.MotherLastName)
                       && (pChild.IsPartOfMultipleBirth == perChild.IsPartOfMultipleBirth) &&
                       (pChild.BirthOrder == perChild.BirthOrder);
            };
        }
    }
}