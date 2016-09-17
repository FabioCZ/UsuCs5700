using System.Collections.Generic;
using System.Linq;
using Cs5700Hw1.Match;
using Cs5700Hw1.Match.Matchers;
using Cs5700Hw1.Model;
using Cs5700Hw1.Serialization;

namespace Cs5700Hw1
{
    public class MatcherRunner
    {
        public MatcherRunner(IEnumerable<FileInfo> fileInfos, string outputFileName)
        {
            FileInfos = fileInfos;
            OutputFileName = outputFileName;
        }

        public IEnumerable<FileInfo> FileInfos { get; }
        public string OutputFileName { get; }

        public void Run()
        {
            var persons = new List<Person>();
            foreach (var fi in FileInfos)
                persons.AddRange(DeSerializer.CreateFrom(fi).DeSerialize());

            var matches = new List<Match.Match>();
            var matchers = new List<PersonMatcher>
            {
                new NamePersonMatcher(),
                new UniqueNumbersPersonMatcher(),
                new MotherPersonMatcher(),
                new PhonePersonMatcher(),
                new GenderAndYearPersonMatcher()
            };

            foreach (var m in matchers)
                matches.AddRange(m.FindMatches(persons).Except(matches));

            //output to console
            new ConsoleResultWriter().WriteResult(matches);
            //output to file
            new FileResultWriter(OutputFileName).WriteResult(matches);
        }
    }
}