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
    public class ChooseLocationViewModel:BaseViewModel
    {
        #region Atributos
        #endregion
        #region Propiedades
        
        public ObservableCollection<Pin> Pins { get; set; }
        #endregion
        #region Constructor
        public ChooseLocationViewModel()
        {

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
                    Label = "Has clic en el icono de posicion para confirmar tu ubicación",
                    Position = args.Point
                });
            });
        #endregion
        #region Metodos
        public void locateMe()
        {
            if (Pins.Count<=0)
            {
                App.Current.MainPage.DisplayAlert("Error", "Debe seleccionar una ubicacion antes de completar con el registro", "Aceptar");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Exito", "Su ubicacion ha sido guardada exitosamente", "Aceptar");
            }
        }
        #endregion
    }
}
