using BrotCliente.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrotCliente.Views.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeLastname
    {
        private ChangeLastnameViewModel ViewModel;
        public ChangeLastname()
        {
            InitializeComponent();

            BindingContext = ViewModel = new ChangeLastnameViewModel();
        }
    }
}