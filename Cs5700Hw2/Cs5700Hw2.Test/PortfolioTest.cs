using System;
using Cs5700Hw2.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cs5700Hw2.Test
{
    [TestClass]
    public class PortfolioTest
    {
        [TestMethod]
        public void TestPortfolioSize()
        {

            var portfolio = new Portfolio(TestingHelpers.GetMockCompanies());
            Assert.AreEqual(portfolio.Size, 4);
        }

        [TestMethod]
        public void TestSerialization()
        {
            var availCompanies = TestingHelpers.GetMockCompanies();
            var portfolio = new Portfolio(TestingHelpers.GetMockCompanies());
            var serialized = portfolio.ToXml();
            var deserialized = Portfolio.FromXml(serialized, availCompanies);
            Assert.AreEqual(deserialized.Size, portfolio.Size);
            Assert.AreEqual(deserialized.WatchedCompanies[0].TickerName, portfolio.WatchedCompanies[0].TickerName);

        }
    }
}
