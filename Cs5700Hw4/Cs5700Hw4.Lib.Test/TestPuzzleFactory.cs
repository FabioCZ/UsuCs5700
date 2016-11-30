using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw4.Lib.IO;
using Cs5700Hw4.Lib.Model;

namespace Cs5700Hw4.Lib.Test
{
    public static class TestPuzzleFactory
    {

        private static IPuzzleConverter converter = new PlainTextPuzzleConverter();
        public static Puzzle GetValid4By4Puzzle()
        {
            const string puzzle = @"4
1 2 3 4
2 - 3 1
1 3 - 4
3 1 4 -
- 2 1 3

";
            return converter.DeSerialize(puzzle);
        }

        public static Puzzle GetInvalidSizePuzzle()
        {
            const string puzzle = @"3
1 2 3
2 - 3
1 3 -
3 1 4
";
            return converter.DeSerialize(puzzle);
        }

        public static Puzzle GetInvalid4By4Repeat()
        {
            const string puzzle = @"4
1 2 3 4
2 - 3 1
1 4 - 4
3 1 4 -
- 2 1 3

";
            return converter.DeSerialize(puzzle);
        }
    }
}
