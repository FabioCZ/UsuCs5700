using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw1.Matcher
{
    internal class ConsoleResultWriter : IMatchResultWriter
    {
        public void WriteResult(List<Match> matches)
        {
            matches.ForEach(m => Console.WriteLine(m.ToString()));
        }
    }
}
