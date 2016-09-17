using System;
using System.Collections.Generic;
using System.Linq;
using Cs5700Hw1.Model;

namespace Cs5700Hw1.Match.Matchers
{
    public abstract class PersonMatcher
    {
        public List<Match> FindMatches(List<Person> persons)
        {
            var allMatches = new List<Match>();
            foreach (var per in persons)
            {
                var personMatches =
                    persons.FindAll(p => p.ObjectId != per.ObjectId)
                        .FindAll(GetPredicate(per))
                        .Select(p => new Match(per, p))
                        .ToList();
                var personMatchesFiltered = personMatches.Except(allMatches).ToList();
                allMatches.AddRange(personMatchesFiltered);
            }
            return allMatches;
        }

        protected abstract Predicate<Person> GetPredicate(Person per);
    }
}