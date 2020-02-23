﻿namespace Brot.Views.Tabs
{
    using ViewModels;
    using System;
    using System.ComponentModel;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;


    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class Feed : ContentPage
    {
        public Feed()
        {
            InitializeComponent();
            BindingContext = new FeedViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((FeedViewModel)BindingContext).selectedItemLista = null;
        }

        private void ListView_ItemSelected(ListView sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            sender.SelectedItem = null;
        }

    }
}