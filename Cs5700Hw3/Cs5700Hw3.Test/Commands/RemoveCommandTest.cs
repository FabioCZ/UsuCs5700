using System;
using System.Drawing;
using System.Linq;
using Cs5700Hw3.Commands;
using Cs5700Hw3.Drawables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw3.Test.Commands
{
    [TestClass]
    public class RemoveCommandTest
    {
        [TestMethod]
        public void TestRemoveCommand()
        {
            var picture = new PictureState();
            var addCmd = CommandFactory.CreateCommand(typeof(AddCommand));
            picture.ExecuteCommand(addCmd, new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat1), TargetLocation = new Point(1, 1) });

            picture.SelectedDrawable = picture.Drawables.First();
            picture.SelectedDrawable.IsSelected = true;
            Assert.AreEqual(1, picture.Drawables.Count);
            var remCmd = CommandFactory.CreateCommand(typeof(RemoveCommand));
            picture.ExecuteCommand(remCmd);
            Assert.AreEqual(0, picture.Drawables.Count);
        }

        [TestMethod]
        public void TestRemoveCommand_Undo()
        {
            var picture = new PictureState();
            var addCmd = CommandFactory.CreateCommand(typeof(AddCommand));
            picture.ExecuteCommand(addCmd, new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat1), TargetLocation = new Point(1, 1) });

            picture.SelectedDrawable = picture.Drawables.First();
            picture.SelectedDrawable.IsSelected = true;
            Assert.AreEqual(1, picture.Drawables.Count);
            var remCmd = CommandFactory.CreateCommand(typeof(RemoveCommand));
            picture.ExecuteCommand(remCmd);
            Assert.AreEqual(0, picture.Drawables.Count);
            picture.Undo();
            Assert.AreEqual(1, picture.Drawables.Count);
        }
    }
}
