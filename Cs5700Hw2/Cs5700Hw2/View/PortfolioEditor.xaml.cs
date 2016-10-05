using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
        public List<SelectionCompany> AvailableCompanies { get; set; }
        public ObservableCollection<SelectionCompany> FilteredCompanies { get; set; }

        public List<Company> SelectedCompanies
        {
            get { return AvailableCompanies.Where(c => c.Selected).Select(c => c as Company).ToList(); }
        }

        public PortfolioEditor(List<SelectionCompany>  availableCompanies)
        {
            AvailableCompanies = availableCompanies.OrderBy(e => e.TickerName).ToList();
            FilteredCompanies = new ObservableCollection<SelectionCompany>(AvailableCompanies.ToList());    //copy
            InitializeComponent();
            companyListView.ItemsSource = FilteredCompanies;
            MaxWidth = ActualWidth;
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
       
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var boxText = searchBox.Text.ToLower();
            var source = showSelectedToggleSwitch.IsOn ? FilteredCompanies.Where(c => c.Selected) : FilteredCompanies;
            if (string.IsNullOrEmpty(boxText))
            {
                companyListView.ItemsSource = source;
            }
            companyListView.ItemsSource = source.Where((item) => item.LongName.ToLower().Contains(boxText) || item.TickerName.ToLower().Contains(boxText));
        }

        private void showSelectedToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            searchBox_TextChanged(sender,null);
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var selected = (sender as CheckBox).IsChecked;
            for (var i = 0; i < AvailableCompanies.Count;i++)
            {
                if (AvailableCompanies[i] == (sender as CheckBox).DataContext)
                {
                    AvailableCompanies[i].Selected = selected.Value;

                    break;
                }
            }
            portfolioSizeTextBlock.Text = "Portfolio size: " + FilteredCompanies.Count(c => c.Selected);

        }
    }
}
