using System;
using System.Drawing;
using Cs5700Hw3.Drawables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw3.Test.Drawables
{
    [TestClass]
    public class DrawableWithStateTest
    {
        [TestMethod]
        public void TestDrawableWithState_Clone()
        {
            var drw = new DrawableWithState(DrawableFactory.GetDrawable(CatDrawable.Cat1));
            var drw2 = drw.Clone();
            Assert.AreEqual(new Point(10,10),drw2.Location);
        }
    }
}
