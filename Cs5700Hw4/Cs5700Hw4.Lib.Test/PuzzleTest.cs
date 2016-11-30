using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw4.Lib.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw4.Lib.Test
{
    [TestClass]
    public class PuzzleTest
    {
        [TestMethod]
        public void TestValidateInvalidBadSize()
        {
            var p = TestPuzzleFactory.GetInvalidSizePuzzle();
            Assert.IsFalse(p.IsValidPuzzle(true));
        }

        [TestMethod]
        public void TestValidateInvalidRepeatNumbers()
        {
            var p = TestPuzzleFactory.GetInvalid4By4Repeat();
            Assert.IsFalse(p.IsValidPuzzle(true));
        }

        [TestMethod]
        public void TestValidateValid()
        {
            var p = TestPuzzleFactory.GetValid4By4Puzzle();
            Assert.IsTrue(p.IsValidPuzzle(true));
        }

        [TestMethod]
        public void TestEqualityNotEqual()
        {
            var p = TestPuzzleFactory.GetValid4By4Puzzle();
            var p2 = TestPuzzleFactory.GetValid4By4Puzzle();
            p2.Board[0, 1].CurrentValue = "4";
            Assert.IsFalse(Puzzle.AreSameSolutions(p,p2));
        }

        [TestMethod]
        public void TestEqualityEqual()
        {
            var p = TestPuzzleFactory.GetValid4By4Puzzle();
            var p2 = TestPuzzleFactory.GetValid4By4Puzzle();
            Assert.IsTrue(Puzzle.AreSameSolutions(p, p2));
        }

        [TestMethod]
        public void TestEmptyCellCount()
        {
            var p = TestPuzzleFactory.GetValid4By4Puzzle();
            Assert.AreEqual(4,p.GetEmptyCellCount());
        }

        [TestMethod]
        public void TestUniqueCheckingUnique()
        {
            var p = TestPuzzleFactory.GetValid4By4Puzzle();
            Assert.IsTrue(p.IsUniqueInRowColSquare(1,0,"4"));
        }

        [TestMethod]
        public void TestUniqueCheckingNotUnique()
        {
            var p = TestPuzzleFactory.GetValid4By4Puzzle();
            Assert.IsFalse(p.IsUniqueInRowColSquare(1, 0, "2"));
        }
    }
}
