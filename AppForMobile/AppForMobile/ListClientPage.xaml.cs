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
    public partial class ListClientPage : ContentPage
    {
        public ListClientPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            using (ApplicationContext db = new ApplicationContext(dbPath))
            {
                clientsList.ItemsSource = db.Clients.ToList();
            }
            base.OnAppearing();
        }

        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Client selectedClient = (Client)e.SelectedItem;
            ClientPage clientPage = new ClientPage();
            clientPage.BindingContext = selectedClient;
            await Navigation.PushAsync(clientPage);
        }
        // обработка нажатия кнопки добавления
        private async void CreateClient(object sender, EventArgs e)
        {
            Client client = new Client();
            ClientPage clientPage = new ClientPage();
            clientPage.BindingContext = client;
            await Navigation.PushAsync(clientPage);
        }
    }
}