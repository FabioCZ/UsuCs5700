using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw4.Lib.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw4.Lib.Test
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void TestBadOrdinalLow()
        {
            var p = TestPuzzleFactory.GetValid4By4Puzzle();
            var cell = p.Board[0, 0];
            var wasThrown = false;
            try
            {
                cell.CurrentValueOrdinal = -1;

            }
            catch (Exception)
            {
                wasThrown = true;
            }
            Assert.IsTrue(wasThrown);
        }

        [TestMethod]
        public void TestBadOrdinalHigh()
        {
            var p = TestPuzzleFactory.GetValid4By4Puzzle();
            var cell = p.Board[0, 0];
            var wasThrown = false;
            try
            {
                cell.CurrentValueOrdinal = 900;

            }
            catch (Exception)
            {
                wasThrown = true;
            }
            Assert.IsTrue(wasThrown);
        }

        [TestMethod]
        public void TestValidOrdinal()
        {
            var p = TestPuzzleFactory.GetValid4By4Puzzle();
            var cell = p.Board[0, 0];
            var wasThrown = false;
            try
            {
                cell.CurrentValueOrdinal = 1;

            }
            catch (Exception)
            {
                wasThrown = true;
            }
            Assert.IsFalse(wasThrown);
        }

        [TestMethod]
        public void TestBadString()
        {
            var p = TestPuzzleFactory.GetValid4By4Puzzle();
            var cell = p.Board[0, 0];
            var prev = cell.CurrentValue;
            cell.CurrentValue = "asd";
            Assert.AreEqual(prev,cell.CurrentValue);

        }

        [TestMethod]
        public void TestValidString()
        {
            var p = TestPuzzleFactory.GetValid4By4Puzzle();
            var cell = p.Board[0, 0];
            var wasThrown = false;
            try
            {
                cell.CurrentValue = "1";

            }
            catch (Exception)
            {
                wasThrown = true;
            }
            Assert.IsFalse(wasThrown);
        }
    }
}
