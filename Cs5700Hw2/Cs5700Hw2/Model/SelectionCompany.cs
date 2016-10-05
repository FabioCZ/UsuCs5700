using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs5700Hw2.Model
{
    public class SelectionCompany : Company
    {
        public bool Selected { get; set; }

        public SelectionCompany(Company c) : base(c.TickerName,c.SomeNumber,c.LongName)
        {
            Selected = false;
        }
    }
}
