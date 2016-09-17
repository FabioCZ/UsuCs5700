using System;
using Cs5700Hw1.Model;
using static System.String;

namespace Cs5700Hw1.Match.Matchers
{
    public class PhonePersonMatcher : PersonMatcher
    {
        protected override Predicate<Person> GetPredicate(Person per)
        {
            return p =>
            {
                if (!(p is Adult) || !(per is Adult))
                    return false;

                if (IsNullOrEmpty(p.FirstName) || IsNullOrEmpty(per.FirstName) || IsNullOrEmpty(p.LastName) ||
                    IsNullOrEmpty(per.LastName))
                    return false;

                if ((p.FirstName != per.FirstName) && (p.LastName != per.LastName))
                    return false;

                var pAdult = p as Adult;
                var perAdult = per as Adult;

                return StringEqualWithContent(pAdult.Phone1, perAdult.Phone1) ||
                       StringEqualWithContent(pAdult.Phone1, perAdult.Phone2) ||
                       StringEqualWithContent(pAdult.Phone1, perAdult.Phone2) ||
                       StringEqualWithContent(pAdult.Phone2, perAdult.Phone1);
            };
        }

        private static bool StringEqualWithContent(string s1, string s2)
        {
            if (IsNullOrEmpty(s1) || IsNullOrEmpty(s2)) return false;
            return s1 == s2;
        }
    }
}