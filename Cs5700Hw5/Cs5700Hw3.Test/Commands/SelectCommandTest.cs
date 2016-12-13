using System;
using System.Drawing;
using Cs5700Hw3.Commands;
using Cs5700Hw3.Drawables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw3.Test.Commands
{
    [TestClass]
    public class SelectCommandTest
    {
        [TestMethod]
        public void TestSelectCommand_Valid()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            invoker.ExecuteCommand(typeof(AddCommand), new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat1), TargetLocation = new Point(1, 1) });
            invoker.ExecuteCommand(typeof(SelectCommand), new CommandArgs() {TargetLocation = new Point(2, 2)});
            Assert.IsNotNull(picture.SelectedDrawable);
            Assert.AreEqual(new Point(1,1), picture.SelectedDrawable.Location);
            Assert.AreEqual(true,picture.SelectedDrawable.IsSelected);
        }

        [TestMethod]
        public void TestSelectCommand_NoSelection()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            invoker.ExecuteCommand(typeof(AddCommand), new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat1), TargetLocation = new Point(10, 10) });
            invoker.ExecuteCommand(typeof(SelectCommand), new CommandArgs() { TargetLocation = new Point(2, 2) });
            Assert.IsNull(picture.SelectedDrawable);
        }

        [TestMethod]
        public void TestSelectCommand_Undo()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            invoker.ExecuteCommand(typeof(AddCommand), new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat1), TargetLocation = new Point(1, 1) });
            invoker.ExecuteCommand(typeof(SelectCommand), new CommandArgs() { TargetLocation = new Point(2, 2) });
            Assert.IsNotNull(picture.SelectedDrawable);
            Assert.AreEqual(new Point(1, 1), picture.SelectedDrawable.Location);
            Assert.AreEqual(true, picture.SelectedDrawable.IsSelected);
            invoker.Undo();
            Assert.IsNull(picture.SelectedDrawable);
        }

        [TestMethod]
        public void TestSelectCommand_TwoSelectionUndo()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            invoker.ExecuteCommand(typeof(AddCommand), new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat1), TargetLocation = new Point(1, 1) });
            invoker.ExecuteCommand(typeof(AddCommand), new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat2), TargetLocation = new Point(400,400) });

            invoker.ExecuteCommand(typeof(SelectCommand), new CommandArgs() { TargetLocation = new Point(2, 2) });
            Assert.IsNotNull(picture.SelectedDrawable);
            Assert.AreEqual(new Point(1, 1), picture.SelectedDrawable.Location);
            Assert.AreEqual(true, picture.SelectedDrawable.IsSelected);
            invoker.ExecuteCommand(typeof(SelectCommand), new CommandArgs() { TargetLocation = new Point(410,410) });
            Assert.IsNotNull(picture.SelectedDrawable);
            Assert.AreEqual(new Point(400,400), picture.SelectedDrawable.Location);
            Assert.AreEqual(true, picture.SelectedDrawable.IsSelected);
            invoker.Undo();
            Assert.IsNotNull(picture.SelectedDrawable);
            Assert.AreEqual(new Point(1, 1), picture.SelectedDrawable.Location);
            Assert.AreEqual(true, picture.SelectedDrawable.IsSelected);

        }
    }
}
