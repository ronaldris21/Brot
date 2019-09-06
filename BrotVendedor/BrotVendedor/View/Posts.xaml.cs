using BrotVendedor.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        PostsViewModel BindingObject;
        public Posts()
        {
            InitializeComponent();
            BindingObject = new PostsViewModel();
            BindingContext = BindingObject;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = (sender as ImageButton);
            if (int.TryParse(btn.ClassId, out int id))
            {
                BindingObject.PLike.Execute(id);
            }
            //BindingObject.HelloWorld.Execute(btn.ClassId);
        }

        private void LikeButton_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = (sender as ImageButton);
            if (int.TryParse(btn.ClassId, out int id))
            {
                BindingObject.PLike.Execute(id);
                Debug.Print(btn.ClassId);
            }
        }
    }
}