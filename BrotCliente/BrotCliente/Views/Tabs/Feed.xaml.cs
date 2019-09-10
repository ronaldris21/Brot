using BrotCliente.ViewModels;
using DLL.ResponseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrotCliente.Views.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class Feed : ContentPage
    {
        FeedViewModel ViewModel;
        public Feed()
        {
            InitializeComponent();

            BindingContext = ViewModel = new FeedViewModel();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton LikePressed = (sender as ImageButton);

            if (int.TryParse(LikePressed.ClassId, out int idLikeButton))
            {
                this.ViewModel.LikeCommand.Execute(idLikeButton);
            }
        }

        private async void FeedListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var post = e.SelectedItem as ResponsePublicacionFeed;

            if (post == null)
                return;

            await Navigation.PushAsync(new Post(new PostViewModel(post)));

            this.FeedListView.SelectedItem = null;
        }
    }
}