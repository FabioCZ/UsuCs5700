using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw2.Model
{
    public class SelectionCompany : CompanyDecorator
    {
        public bool Selected { get; set; }
        public override string TickerName => company.TickerName;
        public override double? SomeNumber => company.SomeNumber;
        public override string LongName => company.LongName;

        public SelectionCompany(Company c) : base(c)
        {
            Selected = false;
        }


    }
}
