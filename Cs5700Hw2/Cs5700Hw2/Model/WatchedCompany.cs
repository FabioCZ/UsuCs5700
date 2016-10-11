using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Cs5700Hw2.Net;

namespace Cs5700Hw2.Model
{
    public class WatchedCompany : CompanyDecorator
    {
        public List<TickerMessage> Messages { get; private set; }

        public override string TickerName => company.TickerName;
        public override double? SomeNumber => company.SomeNumber;
        public override string LongName => company.LongName;

        public TickerMessage LatestMessage => Messages?.LastOrDefault() ?? TickerMessage.Empty;

        public SymbolIcon Direction
        {
            get { return new SymbolIcon(Symbol.Up); }
        }

        public WatchedCompany(Company c) : base(c)
        {
        }

        public void AddMessage(TickerMessage msg)
        {
            if (Messages == null)
            {
                Messages = new List<TickerMessage>();
            }
            if (msg.TickerName != TickerName)
            {
                throw new ArgumentException($"Trying to add message for comapny {msg.TickerName} to company {TickerName}");
            }
            Messages.Add(msg);
        }
    }
}
