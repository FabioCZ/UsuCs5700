using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw4.Lib.Model;
using Cs5700Hw4.Lib.Solver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw4.Lib.Test
{
    [TestClass]
    public class TestBruteForceSolver
    {
        [TestMethod]
        public void TestValid()
        {
            var solver = new BruteForcePuzzleSolver();
            var p = TestPuzzleFactory.GetValid4By4Puzzle();
            var sol = solver.Solve(p);
            Assert.AreEqual(SolutionState.OneSolution, sol.SolutionState);
        }

        [TestMethod]
        public void TestInvalid()
        {
            var solver = new BruteForcePuzzleSolver();
            var p = TestPuzzleFactory.GetInvalid4By4Repeat();
            var sol = solver.Solve(p);
            Assert.AreEqual(SolutionState.InvalidPuzzle, sol.SolutionState);
        }
    }
}
