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
    public partial class PricePage : ContentPage
    {
        string dbPath;

        public PricePage()
        {
            InitializeComponent();
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
        }

        private void SavePrice(object sender, EventArgs e)
        {
            var friend = (PriceOfTariff)BindingContext;
            /*
            if (!String.IsNullOrEmpty(friend.Name))
            {
                using (ApplicationContext db = new ApplicationContext(dbPath))
                {
                    if (friend.Id == 0)
                        db.Clients.Add(friend);
                    else
                    {
                        db.Clients.Update(friend);
                    }
                    db.SaveChanges();
                }
            }
            */
            using (ApplicationContext db = new ApplicationContext(dbPath))
            {
                db.PriceOfTariffs.Update(friend);
                db.SaveChanges();
            }
                
            this.Navigation.PopAsync();
        }
        /*
        private void DeleteClient(object sender, EventArgs e)
        {
            var friend = (PriceOfTariff)BindingContext;
            using (ApplicationContext db = new ApplicationContext(dbPath))
            {
                db.PriceOfTariffs.Remove(friend);
                db.SaveChanges();
            }
            this.Navigation.PopAsync();
        }
        */
    }
}