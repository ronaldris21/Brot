using System;
using Xamarin.Forms;
using BrotCliente.Views;
using Xamarin.Forms.Xaml;
using BrotCliente.Views.Tabs;
using BrotCliente.Class;

namespace BrotCliente
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            try
            {
                UserLogged user = Singleton.current.Json.ReadData();

                if (user.Rememberme)
                {
                    Singleton.Usuario = user;
                    MainPage = new NavigationPage(new Master());
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
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#ff5001");
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
