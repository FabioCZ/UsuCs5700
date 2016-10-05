using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;
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
        public FileOpenPicker companyListPicker { get; private set; }
        public FileOpenPicker openPortfolioPicker { get; private set;}
        public FileSavePicker savePortfolioPicker { get; private set;}
        public List<Company> AvailableCompanies { get; private set; }
        public Portfolio Portfolio { get; private set; }
        public PortfolioEditor PortfolioEditor { get; private set; }
        public ICommListener UdpCommListener {get; private set; }
        public ObservableCollection<IStockObserver> Panels { get; private set; }
        public MainPage()
        {
            this.InitializeComponent();
            Panels = new ObservableCollection<IStockObserver>();
            ChooseCompanyList();
        }

        public async void ChooseCompanyList()
        {
            var introDialog = new MessageDialog("You will be now asked to select the company list csv") {DefaultCommandIndex = 0, Title =  "Welcome"};
            introDialog.Commands.Add(new UICommand("OK") {Id = 0});
            await introDialog.ShowAsync();
            companyListPicker = new FileOpenPicker {CommitButtonText = "Select Company list"};
            companyListPicker.FileTypeFilter.Add(".csv");
            var file = await companyListPicker.PickSingleFileAsync();
            AvailableCompanies = await CsvUtils.ParseCompanyList(file);
            if (AvailableCompanies == null || AvailableCompanies.Count == 0)
            {
                await new MessageDialog("The supplied file is empty/invalid, please select a different one").ShowAsync();
                ChooseCompanyList();
            }
        }


        private async void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            openPortfolioPicker = new FileOpenPicker();
            openPortfolioPicker.FileTypeFilter.Add(".csv");
            var f = await openPortfolioPicker.PickSingleFileAsync();
            if (f != null)
            {
                await new MessageDialog(f.Name).ShowAsync();
            }
        }
        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void EditPortfolioButton_Click(object sender, RoutedEventArgs e)
        {
            if (PortfolioEditor == null)
            {
                var selectionCompanies = AvailableCompanies.Select(c => new SelectionCompany(c)).ToList();
                PortfolioEditor = new PortfolioEditor(selectionCompanies);
            }
            await PortfolioEditor.ShowAsync();
            Portfolio = new Portfolio(PortfolioEditor.SelectedCompanies);
            if (UdpCommListener == null)
            {
                UdpCommListener = new UdpCommListener();
            }
            UdpCommListener.Portfolio = Portfolio;
        }

        private void AddPanelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void StartPauseMonitoringButton_Click(object sender, RoutedEventArgs e)
        {
            if (UdpCommListener == null || Portfolio == null)
            {
                await new MessageDialog("Please select the companies in your portfolio via the Edit Portfolio button")
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
            Panels.Add(new PortfolioStockPricesPanel());
            UdpCommListener.OnDataReceived += Panels[0].OnMessageReceived;
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
