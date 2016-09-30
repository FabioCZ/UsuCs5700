using System.Collections.Generic;

namespace Cs5700Hw2.Model
{
    public class Portfolio
    {
        public List<Company> Companies { get; private set; }

        public Portfolio(List<Company> companies)
        {
            Companies = companies;
        }
    }
}