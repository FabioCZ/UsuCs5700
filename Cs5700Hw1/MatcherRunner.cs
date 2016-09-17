using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using Cs5700Hw1.Matcher;
using Cs5700Hw1.Matcher.Matchers;
using Cs5700Hw1.Model;
using Cs5700Hw1.Serialization;
using FileInfo = Cs5700Hw1.Serialization.FileInfo;

namespace Cs5700Hw1
{
    internal class MatcherRunner
    {
        public IEnumerable<FileInfo> FileInfos { get; private set; }
        public string OutputFileName { get; private set; }
        public MatcherRunner(IEnumerable<FileInfo> fileInfos, string outputFileName)
        {
            FileInfos = fileInfos;
            OutputFileName = outputFileName;
        }

        public void Run()
        {
            var persons = new List<Person>();
            foreach (var fi in FileInfos)
            {
                 persons.AddRange(DeSerializer.CreateFrom(fi).DeSerialize());
            }

            var matches = new List<Match>();
            var matchers = new List<PersonMatcher>()
            {
                new NamePersonMatcher(),
                new UniqueNumbersPersonsMatcher(),
                new MotherPersonMatcher(),
                new PhonePersonMatcher(),
                new GenderAndYearPersonMatcher()
            };

            foreach (var m in matchers)
            {
                matches.AddRange(m.FindMatches(persons).Except(matches));
            }

            //output to console
            new ConsoleResultWriter().WriteResult(matches);
            //output to file
            //new FileResultWriter(OutputFileName).WriteResult(matches);
            Console.WriteLine(matches.Count);
        }
    }
}
