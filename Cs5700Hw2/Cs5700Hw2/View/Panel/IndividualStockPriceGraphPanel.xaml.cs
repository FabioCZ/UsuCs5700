using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public WatchedCompany Company { get; private set; }

        public ObservableCollection<TimestampedMetric<double>> priceHistory;

        public IndividualStockGraphPanel()
        {
            this.InitializeComponent();
            this.RightTapped += (o, args) => this.PanelMarkedForRemoval?.Invoke(this);
            priceHistory = new ObservableCollection<TimestampedMetric<double>>();
        }

        public void OnMessageReceived(object sender, WatchedCompany company)
        {
            if (priceHistory.Count == 30)
            {
                priceHistory.RemoveAt(0);
            }

            priceHistory.Add(new TimestampedMetric<double>(company.LatestMessage.Timestamp.Value, ((double)company.LatestMessage.OpeningPrice)/100));
        }

        public async Task Initialize(Portfolio portfolio)
        {
            var box = new TextBox();
            var dialog = new ContentDialog
            {
                Title = "Enter Company ticker name",
                Content = new StackPanel()
                {
                    Children =
                    {
                        box
                    }
                },
                PrimaryButtonText = "OK"
            };
            await dialog.ShowAsync();
            Company = portfolio.WatchedCompanies.FirstOrDefault(c => c.TickerName == box.Text);
            if (Company == null)
            {
                PanelMarkedForRemoval?.Invoke(this);
            }
            //priceHistory.Add(new TimestampedMetric<double>(DateTime.Now, 0.0));;
        }

    }
}
