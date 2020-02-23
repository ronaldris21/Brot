using Brot.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Brot.Views.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchBrots : ContentPage
    {
        private SearchBrotsViewModel VM { get; set; }
        public SearchBrots()
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
                BindingContext = VM = new SearchBrotsViewModel();
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            VM.updateListCommand.Execute(null);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}