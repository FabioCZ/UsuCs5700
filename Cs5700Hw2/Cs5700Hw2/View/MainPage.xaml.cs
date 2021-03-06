﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Cs5700Hw2.FileIO;
using Cs5700Hw2.Model;
using Cs5700Hw2.Net;
using Cs5700Hw2.View.Panel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Cs5700Hw2.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public readonly string PlayText = "Start Monitoring";
        public readonly string PauseText = "Stop Monitoring";
        public FileOpenPicker CompanyListPicker { get; private set; }
        public FileOpenPicker OpenPortfolioPicker { get; private set; }
        public FileSavePicker SavePortfolioPicker { get; private set; }
        public List<Company> AvailableCompanies { get; private set; }
        public Portfolio Portfolio { get; private set; }
        public PortfolioEditor PortfolioEditor { get; private set; }
        public ICommListener UdpCommListener { get; private set; }
        //public ObservableCollection<IStockObserverPanel> Panels { get; private set; }
        public Dictionary<string, Type> AvailablePanels { get; private set; }
        public MenuFlyout AddPanelFlyout;

        public Timer TitleUpdateTimer;
        public MainPage()
        {
            this.InitializeComponent();
            //Panels = new ObservableCollection<IStockObserverPanel>();
            StartTitleTimer();
            AvailablePanels = new Dictionary<string, Type>(4)
            {
                {"Porfolio Stock Prices", typeof(PortfolioStockPricesPanel)},
                {"Individual Stock Price Graph", typeof(IndividualStockGraphPanel) },
                {"Individual Stock Volume", typeof(IndividualStockVolumePanel) }
            };
            ChooseCompanyList();
        }

        private async void ChooseCompanyList()
        {
            var introDialog = new MessageDialog("You will be now asked to select the company list csv") { DefaultCommandIndex = 0, Title = "Welcome" };
            introDialog.Commands.Add(new UICommand("OK") { Id = 0 });
            await introDialog.ShowAsync();
            CompanyListPicker = new FileOpenPicker { CommitButtonText = "Select Company list" };
            CompanyListPicker.FileTypeFilter.Add(".csv");
            var file = await CompanyListPicker.PickSingleFileAsync();
            AvailableCompanies = await CsvUtils.ParseCompanyList(file);
            if (AvailableCompanies == null || AvailableCompanies.Count == 0)
            {
                await new MessageDialog("The supplied file is empty/invalid, please select a different one").ShowAsync();
                ChooseCompanyList();
            }
        }


        private async void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (UdpCommListener != null && UdpCommListener.IsRunning)
            {
                await new MessageDialog("Please pause monitoring before opening a new portfolio").ShowAsync();
                return;
            }
            OpenPortfolioPicker = new FileOpenPicker();
            OpenPortfolioPicker.FileTypeFilter.Add(".xml");
            var file = await OpenPortfolioPicker.PickSingleFileAsync();
            if (file != null)
            {
                var text = await Windows.Storage.FileIO.ReadTextAsync(file);
                Portfolio = Portfolio.FromXml(text, AvailableCompanies);
                if (Portfolio == null)
                {
                    await new MessageDialog("There was a problem parsing the provided file").ShowAsync();
                    return;
                }
                if (UdpCommListener == null)
                {
                    UdpCommListener = new UdpCommListener();
                }
                UdpCommListener.Portfolio = Portfolio;
            }
        }
        private async void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            SavePortfolioPicker = new FileSavePicker();
            SavePortfolioPicker.FileTypeChoices.Add("Extensible Markup Language", new List<string>() { ".xml" });
            SavePortfolioPicker.SuggestedFileName = "Portfolio";
            var file = await SavePortfolioPicker.PickSaveFileAsync();
            if (file != null && Portfolio != null)
            {

                await Windows.Storage.FileIO.WriteTextAsync(file, Portfolio.ToXml());
            }

        }

        private void StartTitleTimer()
        {
            if (TitleUpdateTimer == null)
            {
                TitleUpdateTimer = new Timer(async state =>
                {
                    await Dispatcher.RunAsync(CoreDispatcherPriority.High, () => AppBarTitle.Text = $"Portfolio Size: {Portfolio?.Size ?? 0} | Time: {DateTime.Now:HH:mm:ss} ");

                }, null, 0, 16);


            }
        }

        private async void EditPortfolioButton_Click(object sender, RoutedEventArgs e)
        {
            if (UdpCommListener != null && UdpCommListener.IsRunning)
            {
                await new MessageDialog("Please pause monitoring before editing portfolio").ShowAsync();
                return;
            }
            var selectionCompanies = AvailableCompanies.Select(c => new SelectionCompany(c)).ToList();
            if (Portfolio != null && Portfolio.Size > 0)
            {
                foreach (var c in Portfolio.WatchedCompanies)
                {
                    selectionCompanies.First(sc => sc.TickerName == c.TickerName).Selected = true;
                }
            }

            PortfolioEditor = new PortfolioEditor(selectionCompanies);
            await PortfolioEditor.ShowAsync();
            Portfolio = new Portfolio(PortfolioEditor.SelectedCompanies);
            if (UdpCommListener == null)
            {
                UdpCommListener = new UdpCommListener();
            }
            UdpCommListener.Portfolio = Portfolio;
        }

        private async void AddPanelButton_Click(object sender, RoutedEventArgs e)
        {
            if (UdpCommListener == null || Portfolio == null || Portfolio.Size == 0)
            {
                await new MessageDialog("Please select the companies in your portfolio via the Edit Portfolio button or import an existing one") { Title = "Error" }
                        .ShowAsync();
                return;
            }
            if (AddPanelFlyout == null)
            {
                AddPanelFlyout = new MenuFlyout();
                AddPanelFlyout.Items?.Add(new MenuFlyoutItem() { Text = "Choose panel type:" });
                AddPanelFlyout.Items?.Add(new MenuFlyoutSeparator());
                foreach (var p in AvailablePanels)
                {
                    var item = new MenuFlyoutItem { Text = p.Key, DataContext = p.Value };
                    item.Tapped += (o, args) =>
                    {
                        AddPanel(((Control)o).DataContext as Type);
                    };
                    AddPanelFlyout.Items?.Add(item);
                }
            }


            AddPanelFlyout.ShowAt(AddPanelButton);
        }

        private async void AddPanel(Type t)
        {
            if (!t.GetInterfaces().Contains(typeof(IStockObserverPanel)))
            {
                //we screwed up
                return;
            }
            var panel = (IStockObserverPanel)Activator.CreateInstance(t);
            await panel.Initialize(Portfolio);
            UdpCommListener.DataReceived += panel.OnMessageReceived;
            panel.PanelMarkedForRemoval += observerPanel => PanelGrid.Children.Remove((UIElement)panel);
            PanelGrid.Children.Add((UIElement)panel);
        }

        private async void StartPauseMonitoringButton_Click(object sender, RoutedEventArgs e)
        {
            if (UdpCommListener == null || Portfolio == null || Portfolio.Size == 0)
            {
                await new MessageDialog("Please select the companies in your portfolio via the Edit Portfolio button or import an existing one") { Title = "Error" }
                        .ShowAsync();
                return;
            }
            if (!UdpCommListener.IsRunning)
            {
                StartPauseMonitoringButton.Icon = new SymbolIcon(Symbol.Pause);
                StartPauseMonitoringButton.Label = PauseText;
                UdpCommListener.Init();
            }
            else //is running
            {
                StartPauseMonitoringButton.Icon = new SymbolIcon(Symbol.Play);
                StartPauseMonitoringButton.Label = PlayText;
                UdpCommListener.Destroy();

            }
        }

        private async void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            await new MessageDialog(@"Stock Message Simulator
Created by Fabio Gotlicher for CS5700 Fall 2016
github.com/FabioCZ/UsuCs5700").ShowAsync();
        }
    }
}
