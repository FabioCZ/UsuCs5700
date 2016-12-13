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
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            invoker.ExecuteCommand(typeof(AddCommand), new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat1), TargetLocation = new Point(1, 1) });

            picture.SelectedDrawable = picture.Drawables.First();
            picture.SelectedDrawable.IsSelected = true;
            Assert.AreEqual(1, picture.Drawables.Count);
            invoker.ExecuteCommand(typeof(RemoveCommand));
            Assert.AreEqual(0, picture.Drawables.Count);
        }

        [TestMethod]
        public void TestRemoveCommand_Undo()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            invoker.ExecuteCommand(typeof(AddCommand), new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat1), TargetLocation = new Point(1, 1) });

            picture.SelectedDrawable = picture.Drawables.First();
            picture.SelectedDrawable.IsSelected = true;
            Assert.AreEqual(1, picture.Drawables.Count);
            invoker.ExecuteCommand(typeof(RemoveCommand));
            Assert.AreEqual(0, picture.Drawables.Count);
            invoker.Undo();
            Assert.AreEqual(1, picture.Drawables.Count);
        }

        [TestMethod]
        public void TestRemoveCommand_NoSelection()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            invoker.ExecuteCommand(typeof(AddCommand), new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat1), TargetLocation = new Point(1, 1) });

            Assert.AreEqual(1, picture.Drawables.Count);
            invoker.ExecuteCommand(typeof(RemoveCommand));
            Assert.AreEqual(1, picture.Drawables.Count);
        }
    }
}
