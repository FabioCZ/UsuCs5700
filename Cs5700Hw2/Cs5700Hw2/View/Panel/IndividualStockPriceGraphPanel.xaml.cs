using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Cs5700Hw2.Model;
using Cs5700Hw2.Net;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Cs5700Hw2.View.Panel
{
    public sealed partial class IndividualStockGraphPanel : UserControl, IStockObserverPanel
    {
        public event PanelRemovalArgs PanelMarkedForRemoval;

        public List<WatchedCompany> companies { get; private set; }
        public IndividualStockGraphPanel()
        {
            this.InitializeComponent();
            this.RightTapped += (o, args) => this.PanelMarkedForRemoval?.Invoke(this);
        }

        public void OnMessageReceived(object sender, WatchedCompany company)
        {
            throw new NotImplementedException();
        }

        public async Task Initialize(Portfolio portfolio)
        {
          
        }

    }
}
