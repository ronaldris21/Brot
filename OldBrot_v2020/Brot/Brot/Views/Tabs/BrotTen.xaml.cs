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
        }
        bool isFirst = true;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (isFirst)
            {
                isFirst = false;
                BindingContext = new BrotTenViewModel();
            }
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