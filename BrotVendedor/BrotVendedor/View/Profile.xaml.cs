using BrotVendedor.ViewModel;
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
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
            BindingContext = new ProfileViewModel();
        }
        #region EnablingEntries
        private void Btn1_Clicked(object sender, EventArgs e)
        {
            txt1.IsEnabled = true;
            txt1.Focus();
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            txt2.IsEnabled = true;
            txt2.Focus();

        }

        private void Btn3_Clicked(object sender, EventArgs e)
        {
            txt3.IsEnabled = true;
            txt3.Focus();

        }

        private void Btn4_Clicked(object sender, EventArgs e)
        {
            txt4.IsEnabled = true;
            txt4.Focus();

        }

        private void Btn5_Clicked(object sender, EventArgs e)
        {
            txt5.IsEnabled = true;
            txt5.Focus();

        }

        private void Btn6_Clicked(object sender, EventArgs e)
        {
            txt6.IsEnabled = true;
            txt6.Focus();

        }

        private void Btn7_Clicked(object sender, EventArgs e)
        {
            txt7.IsEnabled = true;
            txt7.Focus();

        }
        #endregion
        #region DisablingEntries

        private void Txt1_Unfocused(object sender, FocusEventArgs e)
        {
            txt1.IsEnabled = false;
            if (String.IsNullOrEmpty(txt1.Text))
            {
                txt1.IsEnabled = true;
                DisplayAlert("Error", "El campo no puede quedar vacio", "Aceptar");
                txt1.Focus();
            }

        }

        private void Txt2_Unfocused(object sender, FocusEventArgs e)
        {
            txt2.IsEnabled = false;
            if (String.IsNullOrEmpty(txt2.Text))
            {
                txt2.IsEnabled = true;
                DisplayAlert("Error", "El campo no puede quedar vacio", "Aceptar");
                txt2.Focus();
            }
        }

        private void Txt3_Unfocused(object sender, FocusEventArgs e)
        {
            txt3.IsEnabled = false;
            if (String.IsNullOrEmpty(txt3.Text))
            {
                txt3.IsEnabled = true;
                DisplayAlert("Error", "El campo no puede quedar vacio", "Aceptar");
                txt3.Focus();
            }
        }

        private void Txt4_Unfocused(object sender, FocusEventArgs e)
        {
            txt4.IsEnabled = false;
            if (String.IsNullOrEmpty(txt4.Text))
            {
                DisplayAlert("Error", "El campo no puede quedar vacio", "Aceptar");
                txt4.IsEnabled = true;
                txt4.Focus();
            }
        }

        private void Txt5_Unfocused(object sender, FocusEventArgs e)
        {
            txt5.IsEnabled = false;
            if (String.IsNullOrEmpty(txt5.Text))
            {
                txt5.IsEnabled = true;
                DisplayAlert("Error", "El campo no puede quedar vacio", "Aceptar");
                txt5.Focus();
            }
        }

        private void Txt6_Unfocused(object sender, FocusEventArgs e)
        {
            txt6.IsEnabled = false;
            if (String.IsNullOrEmpty(txt6.Text))
            {
                txt6.IsEnabled = true;
                txt6.Focus();
                DisplayAlert("Error", "El campo no puede quedar vacio", "Aceptar");
            }
        }

        private void Txt7_Unfocused(object sender, FocusEventArgs e)
        {
            txt7.IsEnabled = false;
            if (String.IsNullOrEmpty(txt7.Text))
            {
                txt7.IsEnabled = true;
                txt7.Focus();
                DisplayAlert("Error", "El campo no puede quedar vacio", "Aceptar");
            }
        }
        #endregion
    }
}