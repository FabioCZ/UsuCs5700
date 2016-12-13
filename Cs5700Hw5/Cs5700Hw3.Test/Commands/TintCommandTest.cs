using System;
using System.Drawing;
using System.Linq;
using Cs5700Hw3.Commands;
using Cs5700Hw3.Drawables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw3.Test.Commands
{
    [TestClass]
    public class TintCommandTest
    {
        /// <summary>
        /// This doesn't test the tint command per say (that requires UI layer, but it tests the tinting method
        /// </summary>
        [TestMethod]
        public void TestTintCommand()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            invoker.ExecuteCommand(typeof(AddCommand), new CommandArgs() { Drawable = DrawableFactory.GetDrawable(CatDrawable.Cat1), TargetLocation = new Point(1, 1) });
            Assert.AreEqual(1, picture.Drawables.Count);
            picture.SelectedDrawable = picture.Drawables.First();
            picture.SelectedDrawable.IsSelected = true;
            var size = picture.SelectedDrawable.Size;
            var pixelBefore = picture.SelectedDrawable.Map.GetPixel(size.Width/2, size.Height/2);
            //PictureInfo.ExecuteCommand(typeof(TintCommand), new CommandArgs() {TintColor = Color.Red});
            picture.SelectedDrawable.Map = picture.SelectedDrawable.Map.ColorTint(0.5f, 0.5f, 0.5f);
            var pixelAfter = picture.SelectedDrawable.Map.GetPixel(size.Width / 2, size.Height / 2);
            Assert.AreNotEqual(pixelBefore,pixelAfter);
        }
    }
}
