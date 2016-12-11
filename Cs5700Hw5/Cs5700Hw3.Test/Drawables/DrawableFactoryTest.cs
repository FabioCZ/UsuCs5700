using System;
using Cs5700Hw3.Drawables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw3.Test.Drawables
{
    [TestClass]
    public class DrawableFactoryTest
    {
        public const int DrawableCount = 6;

        [TestMethod]
        public void TestDrawableFactory_GetDrawable()
        {
            foreach (var val in Enum.GetValues(typeof(CatDrawable)))
            {
                var drw = DrawableFactory.GetDrawable((CatDrawable) val);
                Assert.IsNotNull(drw);
            }
        }

        [TestMethod]
        public void TestDrawableFactory_GetAllDrawables()
        {
            var drws = DrawableFactory.GetAllDrawables;
            Assert.AreEqual(DrawableCount,drws.Count);
        }
    }
}
