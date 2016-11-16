using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw4.Lib.Model
{
    public class Puzzle
    {
        private List<List<string>> board;
        private int size;
        private List<string> symbols;

        public Puzzle(List<List<string>> board, List<string> symbols)
        {
            this.board = board;
            this.symbols = symbols;
        }
    }
}
