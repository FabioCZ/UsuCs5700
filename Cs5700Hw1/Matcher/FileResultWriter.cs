using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw1.Matcher
{
    internal class FileResultWriter : IMatchResultWriter
    {
        public string Filename { get; private set; }
        public FileResultWriter(string filename)
        {
            Filename = filename;
        }
        public void WriteResult(List<Match> matches)
        {
            var res = string.Empty;
            matches.ForEach(m => res += $"({m.Person1.ObjectId}, {m.Person2.ObjectId}){Environment.NewLine}");
            File.WriteAllText(Filename,res);
        }

    }
}
