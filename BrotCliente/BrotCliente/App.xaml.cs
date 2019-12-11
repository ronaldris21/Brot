using System;
using Xamarin.Forms;
using BrotCliente.Views;
using Xamarin.Forms.Xaml;
using BrotCliente.Views.Tabs;
using BrotCliente.Patterns;

namespace BrotCliente
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            inicializar();

        }

        private async void inicializar()
        {
            try
            {

                if (Singleton.Instance.LocalJson.IsUserLogged())
                {
                    //if (await Singleton.Instance.LocalJson.validarUsuarioinDB())
                    //{
                    //    Singleton.Instance.User = Singleton.Instance.LocalJson.ReadData();
                    MainPage = new NavigationPage(new Master());
                    //}
                    //else
                    //{
                    //    MainPage = new NavigationPage(new Login());
                    //}
                }
                else
                {
                    MainPage = new NavigationPage(new Login());
                }
            }
            catch (Exception) { MainPage = new NavigationPage(new Login()); }
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#031540");
        }

        private bool VerifyLogin()
        {
            return Singleton.Instance.LocalJson.IsUserLogged();
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
