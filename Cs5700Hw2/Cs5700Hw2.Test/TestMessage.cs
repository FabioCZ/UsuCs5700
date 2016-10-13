using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw2.Net;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Cs5700Hw2.Test
{
    [TestClass]
    public class TestMessage
    {
        [TestMethod]
        public void TestEmpty()
        {
            var msg = TickerMessage.Empty;
            Assert.AreEqual("N/A",msg.TickerName);
            Assert.AreEqual(DateTime.FromFileTime(0), msg.Timestamp);
            Assert.AreEqual(0,msg.OpeningPrice);
            Assert.AreEqual(0, msg.PrevClosingPrice);
            Assert.AreEqual(0, msg.CurrPrice);
            Assert.AreEqual(0, msg.BidPrice);
            Assert.AreEqual(0, msg.CurrVolume);
            Assert.AreEqual(0, msg.AvgTenDayVolume);
            Assert.AreEqual("0.00",msg.DollarOpeningPrice);

        }
    }
}
