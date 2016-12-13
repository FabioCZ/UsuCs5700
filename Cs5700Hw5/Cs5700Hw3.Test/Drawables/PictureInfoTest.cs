using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Commands;
using Cs5700Hw3.Drawables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw3.Test.Drawables
{
    [TestClass]
    public class PictureInfoTest
    {
        [TestMethod]
        public void TestPictureInfo()
        {
            var picture = new PictureInfo();
            var invoker = new CommandInvoker(picture);
            var args = new CommandArgs()
            {
                Drawable = DrawableFactory.GetDrawable(CatDrawable.Bowl),
                TargetLocation = new Point(5,5)
            };
            invoker.ExecuteCommand(typeof(AddCommand),args);
            var res= picture.FindDrawableAtPoint(new Point(10, 10));
            Assert.IsNotNull(res);
        }
    }
}
