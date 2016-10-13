using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw2.Model
{
    public abstract class Company
    {

        public abstract string TickerName { get; protected set; }
        public abstract double? BasePrice { get; protected set; }
        public abstract string LongName { get; protected set; }
    }
}
