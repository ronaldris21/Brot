
namespace Brot.ViewModels
{

    using Rg.Plugins.Popup.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class ChangeDescriptionViewModel : BaseViewModel
    {
        public ICommand CancelCommand
        {
            get
            {
                return new Xamarin.Forms.Command(()=> Cancel());
            }
        }

        private async Task Cancel()
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}
