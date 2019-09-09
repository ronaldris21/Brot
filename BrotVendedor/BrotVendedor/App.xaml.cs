using BrotVendedor.Class;
using BrotVendedor.View;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrotVendedor
{
    public partial class App : Application
    {
        LocalUser u;
        public App()
        {
            InitializeComponent();
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string filePath = Path.Combine(path, "user.txt");
                using (var file = File.Open(filePath, FileMode.Open, FileAccess.Read))
                using (var strm = new StreamReader(file))
                {
                    u = Newtonsoft.Json.JsonConvert.DeserializeObject<LocalUser>(strm.ReadToEnd());
                }
                if (u.RememberMe)
                {
                    MainPage = new NavigationPage(new Inicio());
                }
                else
                {
                    MainPage = new NavigationPage(new Login());
                }
            }
            catch (Exception)
            {
                MainPage = new NavigationPage(new Login());
            }
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
