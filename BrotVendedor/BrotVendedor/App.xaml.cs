using BrotVendedor.Class;
using BrotVendedor.View;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using BrotVendedor.Model;

namespace BrotVendedor
{
    public partial class App : Application
    {
        Usuario u;
        public App()
        {
            InitializeComponent();
            try
            {
                u = Singleton.current.Json.ReadData();
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
