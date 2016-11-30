using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw4.Lib.IO;
using Cs5700Hw4.Lib.Solver;
using Mono.Options;

namespace Cs5700Hw4.Runner
{
    public class ConsoleRunner
    {
        public static void Main(string[] args)
        {
            var inputFileName = string.Empty;
            var outputFileName = string.Empty;
            var shouldShowHelp = false;
            var options = new OptionSet()
            {
                {"i|input=", "Path to the input file", n => inputFileName = n},
                {"o|output=", "Path to the output file", n => outputFileName = n},
                { "h|help", "show this message and exit", h => shouldShowHelp = h != null },
            };

            options.Parse(args);

            if (shouldShowHelp)
            {
                Console.WriteLine("Sudoku puzzle solver, options:");
                options.WriteOptionDescriptions(Console.Out);
                return;
            }
            var readerWriter = new PuzzleFileReaderWriter();
            var puzzle = readerWriter.Read(inputFileName);
            var solver = new MutliAlgorithmPuzzleSolver();
            var solutions = solver.Solve(puzzle);
            readerWriter.Write(solutions,outputFileName);
        }
    }
}
