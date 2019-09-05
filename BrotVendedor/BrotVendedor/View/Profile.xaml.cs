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
        }
        #region EnablingEntries
        private void Btn1_Clicked(object sender, EventArgs e)
        {
            txt1.IsEnabled = true;
        }

        private void Btn2_Clicked(object sender, EventArgs e)
        {
            txt2.IsEnabled = true;
        }

        private void Btn3_Clicked(object sender, EventArgs e)
        {
            txt3.IsEnabled = true;
        }

        private void Btn4_Clicked(object sender, EventArgs e)
        {
            txt4.IsEnabled = true;
        }

        private void Btn5_Clicked(object sender, EventArgs e)
        {
            txt5.IsEnabled = true;
        }

        private void Btn6_Clicked(object sender, EventArgs e)
        {
            txt6.IsEnabled = true;
        }

        private void Btn7_Clicked(object sender, EventArgs e)
        {
            txt7.IsEnabled = true;
        }
        #endregion
        #region DisablingEntries

        private void Txt1_Unfocused(object sender, FocusEventArgs e)
        {
            txt1.IsEnabled = false;

        }

        private void Txt2_Unfocused(object sender, FocusEventArgs e)
        {
            txt2.IsEnabled = false;

        }

        private void Txt3_Unfocused(object sender, FocusEventArgs e)
        {
            txt3.IsEnabled = false;

        }

        private void Txt4_Unfocused(object sender, FocusEventArgs e)
        {
            txt4.IsEnabled = false;

        }

        private void Txt5_Unfocused(object sender, FocusEventArgs e)
        {
            txt5.IsEnabled = false;

        }

        private void Txt6_Unfocused(object sender, FocusEventArgs e)
        {
            txt6.IsEnabled = false;

        }

        private void Txt7_Unfocused(object sender, FocusEventArgs e)
        {
            txt7.IsEnabled = false;

        }
        #endregion

    }
}