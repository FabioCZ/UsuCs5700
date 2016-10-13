using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Cs5700Hw2.Model
{
    public class Portfolio
    {
        public List<WatchedCompany> WatchedCompanies { get; private set; }

        public int Size => WatchedCompanies?.Count ?? 0;

        public Portfolio(List<Company> companies)
        {
            WatchedCompanies = new List<WatchedCompany>(companies.Count);  //bit of optimization can't hurt
            companies.ForEach(c => WatchedCompanies.Add(new WatchedCompany(c)));
        }

        public string ToXml()
        {
            var tickers = WatchedCompanies?.Select(e => new XElement("company", new XAttribute("ticker", e.TickerName)));
            var bodyXml = new XElement("Portfolio", tickers);
            return bodyXml.ToString();
        }

        public static Portfolio FromXml(string xml, List<Company> availableCompanies)
        {
            var selectedCompanies = new List<Company>();
            var parsed = XElement.Parse(xml);
            foreach (var ticker in parsed.Descendants("company"))
            {
                var comp = availableCompanies.FirstOrDefault(c => c.TickerName == ticker.FirstAttribute.Value);
                if (comp != null)
                {
                    selectedCompanies.Add(comp);
                }
            }
            if (selectedCompanies.Count == 0) return null;
            return new Portfolio(selectedCompanies);
        }
    }
}