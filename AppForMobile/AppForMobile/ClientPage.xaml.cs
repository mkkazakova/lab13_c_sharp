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
    public partial class ClientPage : ContentPage
    {
        string dbPath;

        public ClientPage()
        {
            InitializeComponent();
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
        }
        
        private void SaveClient(object sender, EventArgs e)
        {
            var friend = (Client)BindingContext;
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
            this.Navigation.PopAsync();
        }
        private void DeleteClient(object sender, EventArgs e)
        {
            var friend = (Client)BindingContext;
            using (ApplicationContext db = new ApplicationContext(dbPath))
            {
                db.Clients.Remove(friend);
                db.SaveChanges();
            }
            this.Navigation.PopAsync();
        }
    }
}