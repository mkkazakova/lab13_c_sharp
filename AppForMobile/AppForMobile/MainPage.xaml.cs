using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppForMobile
{
    public partial class MainPage : ContentPage
    {
        public string dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
        public MainPage()
        {
            InitializeComponent();
        }
        private async void GoToClientPage(object sender, EventArgs e)
        {
            ListClientPage clientPage = new ListClientPage();
            await Navigation.PushAsync(clientPage);
        }
        private async void GoToTariffPage(object sender, EventArgs e)
        {
            ListTariffPage tarPage = new ListTariffPage();
            await Navigation.PushAsync(tarPage);
        }
        private async void GoToPricePage(object sender, EventArgs e)
        {
            ListPricePage pricePage = new ListPricePage();
            await Navigation.PushAsync(pricePage);
        }
    }
}
