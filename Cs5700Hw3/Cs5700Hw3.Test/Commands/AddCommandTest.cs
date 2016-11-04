using System;
using System.Drawing;
using System.Linq;
using Cs5700Hw3.Commands;
using Cs5700Hw3.Drawables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw3.Test.Commands
{
    [TestClass]
    public class AddCommandTest
    {
        [TestMethod]
        public void TestAddCommand()
        {
            var picture = new PictureState();
            var cmd = CommandFactory.CreateCommand(typeof(AddCommand));
            picture.ExecuteCommand(cmd,new CommandArgs() {Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat1), TargetLocation = new Point(1,1)});
            Assert.AreEqual(1,picture.Drawables.Count);
            Assert.AreEqual(DrawableFactory.GetDrawable(CatDrawable.Cat1).ReadableName,picture.Drawables.Last().ReadableName);
            picture.ExecuteCommand(cmd, new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat2), TargetLocation = new Point(2, 2) });
            Assert.AreEqual(2,picture.Drawables.Count);
            Assert.AreEqual(DrawableFactory.GetDrawable(CatDrawable.Cat2).ReadableName,picture.Drawables.Last().ReadableName);

        }

        [TestMethod]
        public void TestAddCommand_Undo()
        {
            var picture = new PictureState();
            var cmd = CommandFactory.CreateCommand(typeof(AddCommand));
            picture.ExecuteCommand(cmd, new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat1), TargetLocation = new Point(1, 1) });
            Assert.AreEqual(1, picture.Drawables.Count);
            picture.Undo();
            Assert.AreEqual(0, picture.Drawables.Count);


        }
    }
}
