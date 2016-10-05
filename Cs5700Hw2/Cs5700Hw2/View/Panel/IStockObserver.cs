using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw2.Net;

namespace Cs5700Hw2.View.Panel
{
    public interface IStockObserver
    {
        void OnMessageReceived(object sender, TickerMessage message);
    }
}
