using System;
using System.Drawing;
using System.Linq;
using Cs5700Hw3.Commands;
using Cs5700Hw3.Drawables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw3.Test.Commands
{
    [TestClass]
    public class ResizeCommandTest
    {
        [TestMethod]
        public void TestResizeCommand()
        {
            var picture = new PictureState();
            picture.ExecuteCommand(typeof(AddCommand), new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat1), TargetLocation = new Point(1, 1) });
            Assert.AreEqual(1, picture.Drawables.Count);
            picture.SelectedDrawable = picture.Drawables.First();
            picture.SelectedDrawable.IsSelected = true;
            var oldSize = picture.SelectedDrawable.Size;
            picture.ExecuteCommand(typeof(ResizeCommand), new CommandArgs() {Scale = 0.5f});
            Assert.AreEqual(oldSize.Height * 0.5,picture.SelectedDrawable.Size.Height,1.0d);
            Assert.AreEqual(oldSize.Width * 0.5, picture.SelectedDrawable.Size.Width, 1.0d);
        }

        [TestMethod]
        public void TestResizeCommand_Undo()
        {
            var picture = new PictureState();
            picture.ExecuteCommand(typeof(AddCommand), new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat1), TargetLocation = new Point(1, 1) });
            Assert.AreEqual(1, picture.Drawables.Count);
            picture.SelectedDrawable = picture.Drawables.First();
            picture.SelectedDrawable.IsSelected = true;
            var oldSize = picture.SelectedDrawable.Size;
            picture.ExecuteCommand(typeof(ResizeCommand), new CommandArgs() { Scale = 0.5f });
            Assert.AreEqual(oldSize.Height * 0.5, picture.SelectedDrawable.Size.Height, 1.0d);
            Assert.AreEqual(oldSize.Width * 0.5, picture.SelectedDrawable.Size.Width, 1.0d);
            picture.Undo();
            Assert.AreEqual(oldSize,picture.SelectedDrawable.Size);
        }
    }
}
