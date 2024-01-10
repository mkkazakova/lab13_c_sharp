using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppForMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListTariffPage : ContentPage
    {
        public ListTariffPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            using (ApplicationContext db = new ApplicationContext(dbPath))
            {
                tariffsList.ItemsSource = db.Tariffs.ToList();
            }
            base.OnAppearing();
        }

        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Tariff selectedTariff = (Tariff)e.SelectedItem;
            TariffPage tariffPage = new TariffPage();
            tariffPage.BindingContext = selectedTariff;
            await Navigation.PushAsync(tariffPage);
        }
        // обработка нажатия кнопки добавления
        private async void CreateTariff(object sender, EventArgs e)
        {
            Tariff tariff = new Tariff();
            TariffPage tariffPage = new TariffPage();
            tariffPage.BindingContext = tariff;
            await Navigation.PushAsync(tariffPage);
        }
    }
}