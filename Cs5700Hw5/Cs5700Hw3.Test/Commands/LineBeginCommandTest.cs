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
    public class LineBeginCommandTest
    {
        [TestMethod]
        public void TestAddCommand()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            var args = new CommandArgs()
            {
                TargetLocation = new Point(5, 5)
            };
            invoker.ExecuteCommand(typeof(LineBeginCommand), args);
            Assert.IsFalse(picture.Lines.Last().IsFinished);
            Assert.AreEqual(new Point(5,5),picture.Lines.Last().FromPoint);
        }

        [TestMethod]
        public void TestAddCommand_Undo()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            var args = new CommandArgs()
            {
                TargetLocation = new Point(5, 5)
            };
            invoker.ExecuteCommand(typeof(LineBeginCommand), args);
            Assert.IsFalse(picture.Lines.Last().IsFinished);
            Assert.AreEqual(new Point(5, 5), picture.Lines.Last().FromPoint);
            invoker.Undo();
            Assert.AreEqual(0,picture.Lines.Count);
        }
    }
}
