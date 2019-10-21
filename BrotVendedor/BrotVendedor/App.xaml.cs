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
        public App()
        {
            InitializeComponent();
            inicializar();
        }

        private async void inicializar()
        {
            try
            {

                if (Singleton.current.Json.IsUserLogged())
                {
                    //if (await Singleton.current.Json.validarUsuarioinDB())
                    //{
                    MainPage = new NavigationPage(new Inicio());
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
            catch (Exception) { }

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
