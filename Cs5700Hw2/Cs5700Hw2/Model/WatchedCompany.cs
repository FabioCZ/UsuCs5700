using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw2.Net;

namespace Cs5700Hw2.Model
{
    public class WatchedCompany : Company
    {
        public List<TickerMessage> Messages { get; private set; }

        public WatchedCompany(Company c) : base(c.TickerName,c.SomeNumber,c.LongName)
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
