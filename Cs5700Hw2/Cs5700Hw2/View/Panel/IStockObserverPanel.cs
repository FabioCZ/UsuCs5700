using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw2.Model;
using Cs5700Hw2.Net;

namespace Cs5700Hw2.View.Panel
{
    public delegate void PanelRemovalArgs(IStockObserverPanel panel);

    public interface IStockObserverPanel
    {
        void OnMessageReceived(object sender, WatchedCompany company);

        Task Initialize(Portfolio portfolio);   //This will run async, so I guess we need to return Task

        event PanelRemovalArgs PanelMarkedForRemoval;
    }
}
