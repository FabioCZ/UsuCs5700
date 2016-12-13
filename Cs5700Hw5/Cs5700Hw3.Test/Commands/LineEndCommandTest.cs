using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Commands;
using Cs5700Hw3.Drawables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw3.Test.Commands
{
    [TestClass]
    public class LineEndCommandTest
    {
        [TestMethod]
        public void TestLineEndCommand()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            var args = new CommandArgs()
            {
                TargetLocation = new Point(5, 5)
            };
            invoker.ExecuteCommand(typeof(LineBeginCommand), args);
            var args2 = new CommandArgs()
            {
                TargetLocation = new Point(10, 10)
            };
            invoker.ExecuteCommand(typeof(LineEndCommand), args2);
            Assert.IsTrue(picture.Lines.Last().IsFinished);
            Assert.AreEqual(new Point(10, 10), picture.Lines.Last().ToPoint);

        }

        [TestMethod]
        public void TestLineEndCommand_Undo()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            var args = new CommandArgs()
            {
                TargetLocation = new Point(5, 5)
            };
            invoker.ExecuteCommand(typeof(LineBeginCommand), args);
            var args2 = new CommandArgs()
            {
                TargetLocation = new Point(10, 10)
            };
            invoker.ExecuteCommand(typeof(LineEndCommand), args2);
            Assert.IsTrue(picture.Lines.Last().IsFinished);
            invoker.Undo();
            Assert.IsFalse(picture.Lines.Last().IsFinished);
            Assert.AreEqual(new Point(5, 5), picture.Lines.Last().FromPoint);
            Assert.AreEqual(1, picture.Lines.Count);
        }

        [TestMethod]
        public void TestLineEndCommand_NoCommand()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            var args = new CommandArgs()
            {
                TargetLocation = new Point(5, 5)
            };
            invoker.ExecuteCommand(typeof(LineEndCommand), args);
            Assert.AreEqual(0, picture.Lines.Count);
        }
    }
}
