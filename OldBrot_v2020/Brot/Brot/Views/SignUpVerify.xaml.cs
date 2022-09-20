using Brot.Models;
using Brot.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Brot.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpVerify : ContentPage
    {
        public SignUpVerify(userModel item, string code)
        {
            InitializeComponent();
            BindingContext = new SignUpVerifyViewModel(item, code);
        }
    }
}