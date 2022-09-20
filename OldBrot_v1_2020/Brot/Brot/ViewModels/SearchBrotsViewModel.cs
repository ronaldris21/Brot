using AsyncAwaitBestPractices;
using Brot.Models;
using Brot.Services;
using Brot.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Brot.ViewModels
{
    class SearchBrotsViewModel : BaseViewModel
    {
        private string text;
        private ObservableCollection<userModel> all;
        private ObservableCollection<userModel> _vendedores;
        private ObservableCollection<string> _categorias;
        private int _sind;
        private userModel usuario;
        public userModel Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                SetProperty(ref usuario, value); GoToProfile();
            }
        }
        public int Selectedindice
        {
            get => _sind;
            set => SetProperty(ref _sind, value);
        }
        public ObservableCollection<userModel> Vendedores
        {
            get => _vendedores;
            set => SetProperty(ref _vendedores, value);
        }
        public ObservableCollection<string> Categorias
        {
            get => _categorias;
            set => SetProperty(ref _categorias, value);
        }
        public string Texto
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public SearchBrotsViewModel()
        {
            LoadDataFirstTime().SafeFireAndForget();
            //TODO: Traer categorias del API
            Categorias = new ObservableCollection<string>
            {
                "Todos",
                "Tortas",
                "HotDogs",
                "Cafeteria",
                "Tienda"
            };
        }

        public ICommand updateListCommand
        {
            get
            {
                return new Xamarin.Forms.Command(UpdateList);
            }
        }
        public ICommand refreshCommand
        {
            get
            {
                return new Xamarin.Forms.Command(() => LoadDataFirstTime().SafeFireAndForget());
            }
        }

        private async void GoToProfile()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SellerProfile(new SellerProfileViewModel(Usuario)));
            Usuario = null;
        }
        private async Task LoadDataFirstTime()
        {
            IsRefreshing = true;

            try
            {
                Response resp = await RestClient.GetAll<userModel>("users/vendors/").ConfigureAwait(false);
                if (!resp.IsSuccess)
                {
                    //await App.Current.MainPage.DisplayAlert("Error", "No se han podido cargar los vendedores", "Aceptar");
                    return;
                }
                all = (ObservableCollection<userModel>)resp.Result;
                for (int i = 0; i < all.Count; i++)
                {
                    all[i].img = String.IsNullOrEmpty(all[i].img) ? DLL.constantes.ProfileImageError
                                    : DLL.constantes.urlImages + all[i].img;
                }
                Vendedores = all;
            }
            catch (Exception ex)
            {
                Microsoft.AppCenter.Crashes.Crashes.TrackError(ex);
            }

            //vendedores = (ObservableCollection<userModel>)resp.Result;
            IsRefreshing = false;
        }
        private void UpdateList()
        {

            if (!String.IsNullOrWhiteSpace(Texto))
            {
                string TextoMinusculas = Texto.ToLower();
                if (Selectedindice != 0)
                {
                    var ele = from item in all
                              where item.nombreCategoria.Equals(Categorias[Selectedindice])
                              select item;
                    var elementos = from item in ele
                                    where item.puesto_name.ToLower().Contains(TextoMinusculas) ||
                                    item.descripcion.ToLower().Contains(TextoMinusculas)
                                    select item;

                    Vendedores = new ObservableCollection<userModel>(elementos.ToList());
                }
                else
                {
                    //0 means ALL categories
                    var elementos = from item in all
                                    where item.puesto_name.ToLower().Contains(TextoMinusculas) ||
                                    item.descripcion.ToLower().Contains(TextoMinusculas)
                                    select item;
                    ObservableCollection<userModel> temp =
                    Vendedores = new ObservableCollection<userModel>(elementos.ToList());
                }

            }
            else if (Selectedindice != 0)
            {
                string categoryLowerCase = Categorias[Selectedindice].ToLower();
                var ele = from item in all
                          where item.nombreCategoria.ToLower().Equals(categoryLowerCase)
                          select item;
                Vendedores = new ObservableCollection<userModel>(ele.ToList());

            }
            else
            {
                Vendedores = all;
            }

        }
    }
}
