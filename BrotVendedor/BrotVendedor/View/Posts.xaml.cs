﻿using BrotVendedor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrotVendedor.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Posts : ContentPage
    {
        public Posts()
        {
            InitializeComponent();
            BindingContext = new PostsViewModel();
        }
    }
}