using System;
using System.IO;
using Xamarin.Forms;
using AppForMobile.Droid;

[assembly: Dependency(typeof(AndroidDbPath))]
namespace AppForMobile.Droid
{
    public class AndroidDbPath : IPath
    {
        public string GetDatabasePath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);
        }
    }
}