using System;
using System.Drawing;
using System.Linq;
using Cs5700Hw3.Commands;
using Cs5700Hw3.Drawables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw3.Test.Commands
{
    [TestClass]
    public class MoveCommandTest
    {
        [TestMethod]
        public void TestMoveCommand()
        {
            var picture = new PictureInfo();
            var initPoint = new Point(1, 1);
            var invoker = new CommandInvoker(picture);
            invoker.ExecuteCommand(typeof(AddCommand), new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat1), TargetLocation = initPoint });
            picture.SelectedDrawable = picture.Drawables.Last();
            picture.SelectedDrawable.IsSelected = true;
            Assert.AreEqual(initPoint, picture.Drawables.Last().Location);
            invoker.ExecuteCommand(typeof(MoveCommand), new CommandArgs() {Direction = MoveDirection.Down});
            initPoint.Offset(0, 5);
            Assert.AreEqual(initPoint,picture.Drawables.Last().Location);
        }

        [TestMethod]
        public void TestMoveCommand_Undo()
        {
            var picture = new PictureInfo();
            var initPoint = new Point(1, 1);
            var invoker = new CommandInvoker(picture);
            invoker.ExecuteCommand(typeof(AddCommand), new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat1), TargetLocation = initPoint });
            picture.SelectedDrawable = picture.Drawables.Last();
            picture.SelectedDrawable.IsSelected = true;
            Assert.AreEqual(initPoint, picture.Drawables.Last().Location);
            invoker.ExecuteCommand(typeof(MoveCommand), new CommandArgs() { Direction = MoveDirection.Down });
            initPoint.Offset(0, 5);
            Assert.AreEqual(initPoint, picture.Drawables.Last().Location);
            invoker.Undo();
            initPoint.Offset(0, -5);
            Assert.AreEqual(initPoint,picture.Drawables.Last().Location);
        }
    }
}
