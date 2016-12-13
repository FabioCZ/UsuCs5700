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
    public class NewPicCommandTest
    {
        [TestMethod]
        public void TestNewPicCommand()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            var args = new CommandArgs()
            {
                BackgroundColor = Color.DarkGray
            };
            invoker.ExecuteCommand(typeof(NewPicCommand), args);
            Assert.IsNotNull(invoker.LatestCommand.TargetPicture);
            Assert.AreEqual(Color.DarkGray, ((SolidBackground) invoker.LatestCommand.TargetPicture.Background).Color);
        }

        [TestMethod]
        public void TestNewPicCommand_Invalid()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            var args = new CommandArgs()
            {
            };
            var wasCaught = false;
            try
            {
                invoker.ExecuteCommand(typeof(NewPicCommand), args);

            }
            catch (ArgumentNullException e)
            {
                wasCaught = true;
            }
            Assert.IsTrue(wasCaught);
        }

        [TestMethod]
        public void TestNewPicCommand_NotNull()
        {
            var picture = new PictureInfo();
            var cmd = CommandFactory.CreateCommand(typeof(NewPicCommand));
            Assert.IsNotNull(cmd);
        }

        [TestMethod]
        public void TestNewPicCommand_Undo()
        {
            var picture = new PictureInfo();
            var cmd = CommandFactory.CreateCommand(typeof(NewPicCommand));
            Assert.IsNotNull(cmd);
            var invoker = new CommandInvoker(picture);
            invoker.CommandHistory.Push(cmd);   //don't execute, but push it on the history stack
            Assert.AreEqual(false, invoker.Undo());
        }
    }
}
