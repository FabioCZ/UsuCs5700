using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw1.Model;
using static System.String;

namespace Cs5700Hw1.Matcher.Matchers
{
    class PhonePersonMatcher : PersonMatcher
    {
        protected override Predicate<Person> GetPredicate(Person per)
        {
            return p =>
            {
                if (!(p is Adult) || !(per is Adult))
                {
                    return false;
                }

                if (IsNullOrEmpty(p.FirstName) || IsNullOrEmpty(per.FirstName) || IsNullOrEmpty(p.LastName) ||
                    IsNullOrEmpty(per.LastName))
                {
                    return false;
                }

                if (p.FirstName != per.FirstName && p.LastName != per.LastName)
                {
                    return false;
                }

                var pAdult = p as Adult;
                var perAdult = per as Adult;

                if (IsNullOrEmpty(pAdult.Phone1) || IsNullOrEmpty(pAdult.Phone2)
                    || IsNullOrEmpty(perAdult.Phone1) || IsNullOrEmpty(perAdult.Phone2))
                {
                    return false;
                }

                return pAdult.Phone1 == perAdult.Phone1 || pAdult.Phone1 == perAdult.Phone2 ||
                       pAdult.Phone1 == perAdult.Phone2 || pAdult.Phone2 == perAdult.Phone1;
            };
        }
    }
}
