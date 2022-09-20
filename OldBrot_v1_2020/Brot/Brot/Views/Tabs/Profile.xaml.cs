namespace Brot.Views.Tabs
{
    using System.ComponentModel;
    using ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;



    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
        }
        bool isFirst = true;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (isFirst)
            {
                isFirst = false;
                BindingContext = new ProfileViewModel();
            }
        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

    }
}