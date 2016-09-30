using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw2.Model
{
    public class Company
    {
        public string TickerName { get; private set; }
        public double? SomeNumber { get; private set; }
        public string LongName { get;  private set; }

        public bool Selected { get;  set; }

        public Company(string tickerName, double? someNumber, string longName)
        {
            TickerName = tickerName;
            SomeNumber = someNumber;
            LongName = longName;
            Selected = false;
        }
    }
}
