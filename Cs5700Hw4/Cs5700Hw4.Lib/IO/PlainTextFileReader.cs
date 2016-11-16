using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw4.Lib.Model;

namespace Cs5700Hw4.Lib.IO
{
    public class PlainTextFileReader : IFileReader
    {
        public Puzzle Read(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            if (lines.Length == 0)
            {
                return null;
            }
            var size = Convert.ToInt32(lines[0]);
            var symbols = lines[1].Split(' ').ToList();
            var board = new List<List<string>>();
            for (var i = 0; i < size; i++)
            {
                var curr = new List<string>();
                curr.AddRange(lines[i+2].Split(' '));
                board.Add(curr);
            }
            return new Puzzle(board,symbols);
        }
    }
}
