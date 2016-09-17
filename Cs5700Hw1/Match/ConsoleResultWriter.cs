using System;
using System.Collections.Generic;

namespace Cs5700Hw1.Match
{
    public class ConsoleResultWriter : IMatchResultWriter
    {
        public void WriteResult(List<Match> matches)
        {
            matches.ForEach(m => Console.WriteLine(m.ToString()));
        }
    }
}