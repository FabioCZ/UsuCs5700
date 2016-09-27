using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Cs5700Hw2.Model;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Cs5700Hw2.View
{
    public sealed partial class PortfolioEditor : ContentDialog
    {
        public List<Company> AvailableCompanies { get; set; }
        public List<Company> FilteredCompanies { get; set; }
        public List<Company> SelectedCompanies { get; private set; }

        public PortfolioEditor(List<Company>  availableCompanies)
        {
            AvailableCompanies = availableCompanies.OrderBy(e => e.TickerName).ToList();
            FilteredCompanies = AvailableCompanies.ToList();    //copy
            this.InitializeComponent();
            this.MaxWidth = this.ActualWidth;

        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
       
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var boxText = (sender as TextBox)?.Text.ToLower();
            //var selected = companyListView.SelectedRanges;
            //foreach (var c in FilteredCompanies.ToList())
            //{
            //    if (!c.LongName.ToLower().Contains(boxText) || !c.TickerName.ToLower().Contains(boxText))
            //    {
            //        FilteredCompanies.Remove(c);
            //    }
            //}

            //foreach (var c in AvailableCompanies)
            //{
            //    if (!FilteredCompanies.Contains(c) &&
            //        (c.LongName.Contains(boxText) || c.TickerName.Contains(boxText)))
            //    {
            //        FilteredCompanies.Add(c);
            //    }
            //}
            //foreach(var r in selected)
            //{
            //    companyListView.SelectRange(r);
            //}


        }
    }
}
