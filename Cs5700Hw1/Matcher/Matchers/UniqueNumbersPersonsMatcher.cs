using System;
using Cs5700Hw1.Model;
using static System.String;

namespace Cs5700Hw1.Matcher.Matchers
{
    class UniqueNumbersPersonsMatcher : PersonMatcher
    {
        protected override Predicate<Person> GetPredicate(Person per)
        {
            return p =>
            {
                if (per is Child && p is Child
                    && !IsNullOrEmpty(((Child) per).NewbornScreeningNumber)
                    && !IsNullOrEmpty(((Child) p).NewbornScreeningNumber))
                {
                    return ((Child) per).NewbornScreeningNumber == ((Child) p).NewbornScreeningNumber;
                }

                if (!IsNullOrEmpty(per.StateFileNumber)
                    && !IsNullOrEmpty(p.StateFileNumber))
                {
                    return per.StateFileNumber == p.StateFileNumber;
                }

                if (!IsNullOrEmpty(per.SocialSecurityNumber)
                    && !IsNullOrEmpty(p.SocialSecurityNumber))
                {
                    return per.SocialSecurityNumber == p.SocialSecurityNumber;
                }
                return false;
            };
        }
    }
}