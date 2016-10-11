using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw2.Model
{
    public abstract class CompanyDecorator : Company
    {
        protected Company company;

        public override string TickerName { get; protected set; }
        public override double? SomeNumber { get; protected set; }
        public override string LongName { get; protected set; }
        protected CompanyDecorator(Company company)
        {
            this.company = company;
        }
    }
}
