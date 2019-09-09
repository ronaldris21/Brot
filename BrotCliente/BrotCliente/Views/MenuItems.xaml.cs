﻿using BrotCliente.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrotCliente.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuItems : ContentPage
    {
        private MenuItemsViewModel ViewModel;
        public MenuItems()
        {
            InitializeComponent();

            BindingContext = ViewModel = new MenuItemsViewModel();
        }
    }
}