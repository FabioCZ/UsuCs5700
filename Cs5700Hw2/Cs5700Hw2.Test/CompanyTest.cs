using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw2.Model;
using Cs5700Hw2.Net;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cs5700Hw2.Test
{
    [TestClass]
    public class CompanyTest
    {
        [TestMethod]
        public void TestMessages()
        {
            var c = new WatchedCompany(new SimpleCompany("A", 1, "Company A"));
            Assert.AreEqual(c.LatestMessage, TickerMessage.Empty);
            var mockBytes = TestingHelpers.GetMockCompAMessageBytes();
            Debug.WriteLine(mockBytes.Length);
            c.AddMessage(new TickerMessage(mockBytes));
            Assert.IsNotNull(c.LatestMessage);
        }
    }
}
