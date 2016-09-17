using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw1.Tests
{
    [TestClass]
    public class MatchTest
    {
        [TestMethod]
        public void TestEquality_Equal()
        {
            var m1 = new Match.Match(MockPersonFactory.GetAdult(), MockPersonFactory.GetAdult2());
            var m2 = new Match.Match(MockPersonFactory.GetAdult2(), MockPersonFactory.GetAdult());
            Assert.AreEqual(m1, m2);
        }

        [TestMethod]
        public void TestEquality_Not_Equal()
        {
            var m1 = new Match.Match(MockPersonFactory.GetAdult(), MockPersonFactory.GetAdult2());
            var m2 = new Match.Match(MockPersonFactory.GetAdult3(), MockPersonFactory.GetAdult());
            Assert.AreNotEqual(m1, m2);
        }
    }
}