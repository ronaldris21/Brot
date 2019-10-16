namespace BrotVendedor.ViewModel.Tabs
{
    using BrotVendedor.Class;
    using BrotVendedor.View;
    using BrotVendedor.View.Tabs.Buttons;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
    public class ProfileDetailViewModel
    {
        #region Commands
        public ICommand GoToAnalytics
        {
            get
            {
                return new RelayCommand(gotoAnalytics);
            }
        }
        public ICommand GoToSettings
        {
            get
            {
                return new RelayCommand(gotoSettings);
            }
        }
        public ICommand GoToLocation
        {
            get
            {
                return new RelayCommand(gotoLocation);
            }
        }
        public ICommand GoToPublications
        {
            get
            {
                return new RelayCommand(gotoPublications);
            }
        }
        #endregion

        #region Metodos
        private void gotoPublications()
        {
            App.Current.MainPage.Navigation.PushAsync(new AllPosts());
        }

        private void gotoLocation()
        {
            App.Current.MainPage.Navigation.PushAsync(new ChooseLocation(Singleton.current.user,"Actualizar"));
        }

        private void gotoSettings()
        {
            App.Current.MainPage.Navigation.PushAsync(new Profile());
        }

        private void gotoAnalytics()
        {
            App.Current.MainPage.Navigation.PushAsync(new Analytics());
        }
        #endregion
    }
}
