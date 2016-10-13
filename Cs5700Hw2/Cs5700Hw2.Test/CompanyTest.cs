using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
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

        [TestMethod]
        public void TestSymbol()
        {
            var c = new WatchedCompany(new SimpleCompany("A", 1, "Company A"));
            Assert.AreEqual(Symbol.Forward,c.Direction);
            var mockBytes = TestingHelpers.GetMockCompAMessageBytes();
            var message = new TickerMessage(mockBytes);
            c.AddMessage(message);
            Assert.AreEqual(Symbol.Forward, c.Direction);
            var msg2 = new TickerMessage(TestingHelpers.GetMockCompAMessageBytes());
            typeof(TickerMessage)
            .GetProperty("CurrPrice")
            .SetValue(msg2, message.CurrPrice + 10);
            c.AddMessage(msg2);

            Assert.AreEqual(Symbol.Upload, c.Direction);

            Assert.IsNotNull(c.LatestMessage);
        }

    }
}
