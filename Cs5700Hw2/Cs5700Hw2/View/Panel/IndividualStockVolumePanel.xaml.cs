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
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Cs5700Hw2.View.Panel
{
    public sealed partial class IndividualStockVolumePanel : UserControl, IStockObserverPanel
    {
        public event PanelRemovalArgs PanelMarkedForRemoval;

        public WatchedCompany Company { get; private set; }

        public ObservableCollection<TimestampedMetric<int>> VolumeHistory;

        public IndividualStockVolumePanel()
        {
            this.InitializeComponent();
            VolumeHistory = new ObservableCollection<TimestampedMetric<int>>();
            //((UIElement) ((LineSeries)Chart.Series[0]).Title).Visibility = Visibility.Collapsed;
        }

        public void OnMessageReceived(object sender, WatchedCompany company)
        {
            if (company?.TickerName != Company?.TickerName) return;
            if (VolumeHistory.Count == 60)   //only keep the latest 60 entries
            {
                VolumeHistory.RemoveAt(0);
            }

            VolumeHistory.Add(new TimestampedMetric<int>(company.LatestMessage.Timestamp.Value, company.LatestMessage.CurrVolume));
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
        }

        private void SymbolIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.PanelMarkedForRemoval?.Invoke(this);
        }
    }
}
