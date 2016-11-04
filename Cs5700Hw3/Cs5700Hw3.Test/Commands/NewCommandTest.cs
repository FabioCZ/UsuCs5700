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
            var picture = new PictureState();
            var cmd = CommandFactory.CreateCommand(typeof(NewPicCommand));
            //picture.ExecuteCommand(cmd);
            Assert.IsNotNull(cmd);
        }
    }
}
