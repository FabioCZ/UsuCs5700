using System;
using Cs5700Hw3.Commands;
using Cs5700Hw3.Drawables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw3.Test.Commands
{
    [TestClass]
    public class NewCommandTest
    {
        [TestMethod]
        public void TestNewCommand()
        {
            var picture = new PictureInfo();
            var cmd = CommandFactory.CreateCommand(typeof(NewPicCommand));
            Assert.IsNotNull(cmd);
        }

        [TestMethod]
        public void TestNewCommand_Undo()
        {
            var picture = new PictureInfo();
            var cmd = CommandFactory.CreateCommand(typeof(NewPicCommand));
            Assert.IsNotNull(cmd);
            picture.CommandHistory.Push(cmd);   //don't execute, but push it on the history stack
            Assert.AreEqual(false,picture.Undo());
        }
    }
}
