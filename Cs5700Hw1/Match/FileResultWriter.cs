using System;
using System.Collections.Generic;
using System.IO;

namespace Cs5700Hw1.Match
{
    public class FileResultWriter : IMatchResultWriter
    {
        public FileResultWriter(string filename)
        {
            Filename = filename;
        }

        public string Filename { get; }

        public void WriteResult(List<Match> matches)
        {
            var res = string.Empty;
            matches.ForEach(m => res += $"({m.Person1.ObjectId}, {m.Person2.ObjectId}){Environment.NewLine}");
            File.WriteAllText(Filename, res);
        }
    }
}