using BrotVendedor.Class;
using BrotVendedor.Model;
using BrotVendedor.View;
using DLL.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace BrotVendedor.ViewModel
{
    public class ChooseLocationViewModel : BaseViewModel
    {
        #region Atributos
        private ObservableCollection<Pin> pins;
        private userModel local;
        private ApiService api;
        private String estado;
        #endregion
        #region Propiedades
        public ObservableCollection<Pin> Pins
        {
            get
            {
                return pins;
            }
            set
            {
                pins = value;OnPropertyChanged("Pins");
            }
        }
        #endregion
        #region Constructor
        public ChooseLocationViewModel(userModel item,String estado)
        {
            this.estado = estado;
            api = new ApiService();
            if (local==default(userModel))
            {
                local = item;
            }
            Pins = new ObservableCollection<Pin>();
            ObservableCollection<Pin> temp = new ObservableCollection<Pin>();
            if (Singleton.current.user != null)
            {
                temp.Add(new Pin
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin100.png"),
                    Label = "Has clic en el icono de posicion para confirmar tu ubicación",
                    Position = new Position((double)Singleton.current.user.xlat, (double)Singleton.current.user.ylon)
                });

            }
            Pins = temp;
        }
        #endregion
        #region Comandos
        public ICommand Locate
        {
            get
            {
                return new RelayCommand(locateMe);
            }
        }

        public Command<MapClickedEventArgs> MapClickedCommand =>
            new Command<MapClickedEventArgs>(args =>
            {
                Pins.Clear();
                Pins.Add(new Pin
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin100.png"),
                    Label = "Has clic en el icono de posicion para confirmar tu ubicación",
                    Position = args.Point
                });
            });
        #endregion
        #region Metodos
        public async void locateMe()
        {
            if (Pins.Count <= 0)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe seleccionar una ubicacion antes de completar con el registro", "Aceptar");
            }
            else
            {
                local.xlat =(float) Pins[0].Position.Latitude;
                local.ylon = (float) Pins[0].Position.Longitude;
                if (estado=="Registrar")
                {
                    Response response = await api.Post<userModel>("users", local);
                    if (!response.isSuccess)
                    {
                        await App.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                        return;
                    }
                    await App.Current.MainPage.DisplayAlert("Exito", "La ubicacion ha sido guardada y el usuario registrado", "Aceptar");
                    App.Current.MainPage = new NavigationPage(new Login());
                }
                else
                {
                    ///Actualizar
                    Response response = await api.Put<userModel>("users", local.id_user,local);
                    if (!response.isSuccess)
                    {
                        await App.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                        return;
                    }
                    await App.Current.MainPage.DisplayAlert("Exito", "La ubicacion ha sido actualizada", "Aceptar");
                    await App.Current.MainPage.Navigation.PopAsync();
                }
            }
                
        }
        #endregion
    }
}
