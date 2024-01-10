using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace AppForMobile
{
    public partial class App : Application
    {
        public const string DBFILENAME = "lab13app.db";
        public App()
        {
            InitializeComponent();
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(DBFILENAME);
            using (var db = new ApplicationContext(dbPath))
            {
                // Создаем бд, если она отсутствует
                db.Database.EnsureCreated();
                if (db.PriceOfTariffs.Count() == 0)
                {
                    Tariff tar1 = new Tariff { InternetSpeed = 100, MaxValume = 20 };
                    db.Tariffs.Add(tar1);
                    db.PriceOfTariffs.Add(new PriceOfTariff { TariffId = 1, IPaddress = true, Price = 300 });
                    db.PriceOfTariffs.Add(new PriceOfTariff { TariffId = 1, IPaddress = false, Price = 250 });
                    db.SaveChanges();
                }
            }
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
