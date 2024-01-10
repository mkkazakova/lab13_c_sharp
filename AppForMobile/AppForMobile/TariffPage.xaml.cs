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
    public partial class TariffPage : ContentPage
    {
        string dbPath;

        public TariffPage()
        {
            InitializeComponent();
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
        }

        private void SaveTariff(object sender, EventArgs e)
        {
            var tariff = (Tariff)BindingContext;
            if (tariff.InternetSpeed != 0)
            {
                using (ApplicationContext db = new ApplicationContext(dbPath))
                {
                    if (tariff.Id == 0)
                    {
                        db.Tariffs.Add(tariff);
                        uint aaa=db.Tariffs.Last().Id + 1;
                        db.PriceOfTariffs.Add(new PriceOfTariff { TariffId = aaa, IPaddress = true, Price = 50});
                        db.PriceOfTariffs.Add(new PriceOfTariff { TariffId = aaa, IPaddress = false, Price = 40});
                    }
                    else
                    {
                        db.Tariffs.Update(tariff);
                    }
                    db.SaveChanges();
                }
            }
            this.Navigation.PopAsync();
        }
        private async void DeleteTariff(object sender, EventArgs e)
        {
            var friend = (Tariff)BindingContext;
            using (ApplicationContext db = new ApplicationContext(dbPath))
            {
                if (db.Clients.Any(c => c.TariffId == friend.Id))
                {
                    await DisplayAlert("Ошибка", $"Тариф используется {friend.Id}", "OK");
                }
                else
                {
                    db.Tariffs.Remove(friend);
                    var rowsToDelete = db.PriceOfTariffs.Where(p => p.TariffId == friend.Id);
                    db.PriceOfTariffs.RemoveRange(rowsToDelete);
                    await db.SaveChangesAsync();
                }
                //if (!db.Clients.Any(c => c.TariffId == friend.Id))
                //  db.Tariffs.Remove(friend);
                
                //db.SaveChanges();
            }
            this.Navigation.PopAsync();
        }
    }
}