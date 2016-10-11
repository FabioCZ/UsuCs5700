using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw2.Model
{
    class SimpleCompany : Company
    {
        public override string TickerName { get; protected set; }
        public override double? SomeNumber { get; protected set; }
        public override string LongName { get; protected set; }

        public SimpleCompany(string tickerName, double? someNumber, string longName)
        {
            TickerName = tickerName;
            SomeNumber = someNumber;
            LongName = longName;
        }
    }
}