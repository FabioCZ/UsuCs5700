using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw4.Lib.Model
{
    public class Puzzle
    {
        public Cell[,] Board { get; private set; }
        public int Size { get; private set; }
        public IReadOnlyList<string> Symbols { get; private set; }
        private readonly int squareSize;

        public Puzzle(Cell[,] board, IReadOnlyList<string> symbols, int size)
        {
            this.Size = size;
            this.Board = board;
            this.Symbols = symbols;
            //Compute this value once at the beginning to optimize
            squareSize = Convert.ToInt32(Math.Sqrt(Size));
        }

        /// <summary>
        /// Deep copy constructor
        /// </summary>
        /// <param name="puzzle"></param>
        public Puzzle(Puzzle puzzle)
        {
            this.Board = new Cell[puzzle.Size, puzzle.Size];
            this.Symbols = puzzle.Symbols;
            this.Size = puzzle.Size;
            for (int i = 0; i < puzzle.Size; i++)
            {
                for (int j = 0; j < puzzle.Size; j++)
                {
                    this.Board[i, j] = new Cell(puzzle.Symbols, string.Copy(puzzle.Board[i, j].CurrentValue));
                }
            }
            //Compute this value once at the beginning to optimize
            squareSize = Convert.ToInt32(Math.Sqrt(Size));
        }

        public bool IsUniqueInRowColSquare(int x, int y, string candidate)
        {
            //row
            for (var i = 0; i < Size; i++)
            {
                if (Board[y, i].CurrentValue == candidate) return false;
            }

            //col
            for (var i = 0; i < Size; i++)
            {
                if (Board[i, x].CurrentValue == candidate) return false;
            }

            //square
            var startX = (x / squareSize) * squareSize;
            var startY = (y / squareSize) * squareSize;
            for (var i = startY; i < startY + squareSize; i++)
            {
                for (int j = startX; j < startX + squareSize; j++)
                {
                    if (Board[i, j].CurrentValue == candidate) return false;

                }
            }
            return true;
        }

        public bool IsValidPuzzle(bool allowEmpty)
        {
            var result = Math.Sqrt(Size);
            var isSquare = Math.Abs(result % 1) < 0.01;
            if (!isSquare)
            {
                return false;
            }
            var encountered = Symbols.ToDictionary(sym => sym, sym => false);

            //each row
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (Board[i, j].CurrentValue == Cell.Empty)
                    {
                        if (allowEmpty) continue;
                        else return false;
                    }
                    if (encountered[Board[i, j].CurrentValue])
                    {
                        return false;
                    }
                    encountered[Board[i, j].CurrentValue] = true;
                }
                encountered = Symbols.ToDictionary(sym => sym, sym => false);   //reset dictionary
            }

            //each col
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (Board[j,i].CurrentValue == Cell.Empty)
                    {
                        if (allowEmpty) continue;
                        else return false;
                    }
                    if (encountered[Board[j,i].CurrentValue])
                    {
                        return false;
                    }
                    encountered[Board[j,i].CurrentValue] = true;
                }
                encountered = Symbols.ToDictionary(sym => sym, sym => false);   //reset dictionary
            }

            //each square
            for (int i = 0; i < Size; i+=squareSize)
            {
                for (int j = 0; j < Size; j += squareSize)
                {
                    //single square
                    for (var y = i; y < squareSize; y++)
                    {
                        for (var x = j; x < squareSize; x++)
                        {
                            if (Board[y, x].CurrentValue == Cell.Empty)
                            {
                                if (allowEmpty) continue;
                                else return false;
                            }
                            if (encountered[Board[y,x].CurrentValue])
                            {
                                return false;
                            }
                            encountered[Board[y,x].CurrentValue] = true;
                        }
                    }
                    encountered = Symbols.ToDictionary(sym => sym, sym => false);   //reset dictionary
                }
            }
            return true;
        }

        public int GetEmptyCellCount()
        {
            return Board.Cast<Cell>().Count(cell => cell.CurrentValue == Cell.Empty);
        }

        public static bool AreSameSolutions(Puzzle a, Puzzle b)
        {
            if (a.Size != b.Size)
            {
                return false;
            }
            if (!a.Symbols.SequenceEqual(b.Symbols))
            {
                return false;
            }
            for (var i = 0; i < a.Size; i++)
            {
                for (var j = 0; j < a.Size; j++)
                {
                    if (a.Board[i, j].CurrentValue != b.Board[i, j].CurrentValue)
                    {
                        return false;
                    }
                }   
            }
            return true;
        }
    }
}
