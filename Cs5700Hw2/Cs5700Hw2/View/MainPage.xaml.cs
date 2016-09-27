using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Cs5700Hw2.FileIO;
using Cs5700Hw2.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Cs5700Hw2.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public FileOpenPicker companyListPicker { get; private set; }
        public FileOpenPicker openPortfolioPicker { get; private set;}
        public FileSavePicker savePortfolioPicker { get; private set;}
        public List<Company> Companies { get; private set; }
        public PortfolioEditor PortfolioEditor { get; private set; }
        public MainPage()
        {
            this.InitializeComponent();

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
            Companies = await CsvUtils.ParseCompanyList(file);
            if (Companies == null || Companies.Count == 0)
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
                PortfolioEditor = new PortfolioEditor(Companies);
            }
            await PortfolioEditor.ShowAsync();
        }

        private void AddPanelButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
