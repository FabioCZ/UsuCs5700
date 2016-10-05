using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Cs5700Hw2.Net;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Cs5700Hw2.View.Panel
{
    public sealed partial class PortfolioStockPricesPanel : UserControl, IStockObserver
    {
        public PortfolioStockPricesPanel()
        {
            this.InitializeComponent();
        }

        public void OnMessageReceived(object sender, TickerMessage message)
        {
            Debug.WriteLine(message.TickerName);
        }
    }
}
