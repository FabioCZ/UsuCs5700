using System.Collections.Generic;

namespace Cs5700Hw2.Model
{
    public class Portfolio
    {
        public List<WatchedCompany> WatchedCompanies { get; private set; }

        public Portfolio(List<Company> companies)
        {
            WatchedCompanies = new List<WatchedCompany>(companies.Count);  //bit of optimization can't hurt
            companies.ForEach(c => WatchedCompanies.Add(new WatchedCompany(c)));
        }
    }
}