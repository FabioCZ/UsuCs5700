using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Commands;
using Cs5700Hw3.Drawables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw3.Test.Commands
{
    [TestClass]
    public class CommandInvokerTest
    {
        [TestMethod]
        public void TestLatestCommand()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            invoker.ExecuteCommand(typeof(AddCommand), null);
            Assert.IsNotNull(invoker.LatestCommand);
        }

        [TestMethod]
        public void TestLatestCommandNone()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            Assert.IsNull(invoker.LatestCommand);
        }

        [TestMethod]
        public void TestUndo()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            invoker.ExecuteCommand(typeof(AddCommand), null);
            invoker.ExecuteCommand(typeof(AddCommand), null);
            Assert.IsTrue(invoker.Undo());
            Assert.AreEqual(1,invoker.CommandHistory.Count);

        }

        [TestMethod]
        public void TestUndoNonUndoable()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            invoker.ExecuteCommand(typeof(NewPicCommand), null);
            invoker.ExecuteCommand(typeof(AddCommand), null);

            Assert.IsFalse(invoker.Undo());
            Assert.AreEqual(0, invoker.CommandHistory.Count);   //0 because non-undoable commands are not added to the stack

        }
    }
}
