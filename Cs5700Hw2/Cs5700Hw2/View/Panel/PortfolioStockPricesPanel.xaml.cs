﻿using System;
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
    public sealed partial class PortfolioStockPricesPanel : UserControl, IStockObserverPanel
    {
        public ObservableCollection<WatchedCompany> companies;

        public event PanelRemovalArgs PanelMarkedForRemoval;
        public PortfolioStockPricesPanel()
        {
            this.InitializeComponent();
        }

        public void OnMessageReceived(object sender, WatchedCompany company)
        {
            if (companies == null) return;
            for (var i = 0; i < companies?.Count; i++)
            {
                if (companies[i].TickerName == company.TickerName)
                {
                    companies[i] = company;
                }
            }
            this.companyListView.UpdateLayout();
        }

        public async Task Initialize(Portfolio portfolio)
        {
            var selectedCompanies = string.Empty;
            var suggest = new AutoSuggestBox();
            suggest.ItemsSource = portfolio.WatchedCompanies.Select(e => e.TickerName);
            suggest.AutoMaximizeSuggestionArea = false;
            suggest.UpdateTextOnSelect = false;
            suggest.IsSuggestionListOpen = false;
            suggest.LostFocus += (sender, args) => suggest.IsSuggestionListOpen = false;
            suggest.TextChanged += (sender, args) =>
            {
                if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    var curr = sender.Text.Split(',').Last() ?? sender.Text;
                    sender.ItemsSource =
                        portfolio.WatchedCompanies.Select(e => e.TickerName).Where(c => c.Contains(curr.ToUpper()));
                    Debug.WriteLine("." + curr + ".");
                    var open = !string.IsNullOrWhiteSpace(curr);
                    Debug.WriteLine(open);
                    sender.IsSuggestionListOpen = open;
                }
                else
                {
                    suggest.IsSuggestionListOpen = false;
                }
            };
            suggest.SuggestionChosen += (sender, args) =>
            {
            };
            suggest.QuerySubmitted += (sender, args) =>
            {
                var curr = sender.Text.Split(',').Last() ?? sender.Text;
                if (curr.Length > 0)
                {
                    sender.Text = sender.Text.Remove(sender.Text.Length - curr.Length);
                }
                sender.IsSuggestionListOpen = false;
                sender.Text += args.ChosenSuggestion.ToString() + ",";
            };
            var dialog = new ContentDialog
            {
                Title = "Enter up to 5 comma separated company names",
                Content = new StackPanel()
                {
                    Children =
                    {
                        suggest
                    }
                },
                PrimaryButtonText = "OK"
            };
            await dialog.ShowAsync();
            if (suggest.Text.Length == 0)
            {
                return;
            }
            var split = suggest.Text.Split(',');
            companies = new ObservableCollection<WatchedCompany>();
            for (var i = 0; i < 5 && i < split.Length;i++)
            {
                if(split[i].Length > 0)
                    companies.Add(portfolio.WatchedCompanies.First(e => e.TickerName == split[i]));
            }
        }

        private void SymbolIcon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PanelMarkedForRemoval?.Invoke(this);
        }
    }
}
