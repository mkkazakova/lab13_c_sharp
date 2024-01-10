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
    public partial class ListPricePage : ContentPage
    {
        public ListPricePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            using (ApplicationContext db = new ApplicationContext(dbPath))
            {
                pricesList.ItemsSource = db.PriceOfTariffs.ToList();
            }
            base.OnAppearing();
        }

        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            PriceOfTariff selectedClient = (PriceOfTariff)e.SelectedItem;
            PricePage pricePage = new PricePage();
            pricePage.BindingContext = selectedClient;
            await Navigation.PushAsync(pricePage);
        }
        // обработка нажатия кнопки добавления
        /*
        private async void CreatePrice(object sender, EventArgs e)
        {
            PriceOfTariff price = new PriceOfTariff();
            PricePage pricePage = new PricePage();
            pricePage.BindingContext = price;
            await Navigation.PushAsync(pricePage);
        }
        */
    }
}