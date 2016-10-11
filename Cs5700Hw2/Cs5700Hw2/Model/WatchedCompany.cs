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

        public Symbol Direction
        {
            get
            {
                //if(Messages == null || Messages.Count < 2) return new SymbolIcon(Symbol.Accept);
                //else if (Messages.Last().CurrPrice > Messages[Messages.Count - 1].CurrPrice) return new SymbolIcon(Symbol.Up);
                //else return new SymbolIcon(Symbol.Download);
                if (Messages == null || Messages.Count < 2) return Symbol.Forward;
                else if (Messages.Last().CurrPrice > Messages[Messages.Count - 1].CurrPrice) return Symbol.Up;
                else return Symbol.Download;
            }
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
