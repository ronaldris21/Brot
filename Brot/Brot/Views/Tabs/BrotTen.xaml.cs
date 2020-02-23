namespace Brot.Views.Tabs
{
    using Models.ResponseApi;
    using System.ComponentModel;
    using ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;



    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class BrotTen : ContentPage
    {
        public BrotTen()
        {
            InitializeComponent();
            BindingContext = new BrotTenViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void FeedListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is ResponseUsuariosFiltro selected))
                return;

            //await Navigation.PushAsync(new SellerProfile(new SellerProfileViewModel(item)));
            await Navigation.PushAsync(new SellerProfile(new SellerProfileViewModel(selected.userData)));

            //Se quita la seleccion del item
            ((ListView)sender).SelectedItem = null;
        }
    }
}