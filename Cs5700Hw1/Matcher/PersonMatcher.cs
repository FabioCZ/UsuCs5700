using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw1.Model;

namespace Cs5700Hw1.Matcher
{
    internal abstract class PersonMatcher
    {
        public List<Match> FindMatches(List<Person> persons)
        {
            var allMatches = new List<Match>();
            foreach (var per in persons)
            {
                var personMatches = persons.FindAll(p => p.ObjectId != per.ObjectId).FindAll(GetPredicate(per)).Select(p => new Match(per, p)).ToList();
                allMatches.AddRange(personMatches.Except(allMatches));
            }
            return allMatches;
        }

        protected abstract Predicate<Person> GetPredicate(Person per);  
    }
}
