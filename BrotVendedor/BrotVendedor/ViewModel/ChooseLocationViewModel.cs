using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms.GoogleMaps;

namespace BrotVendedor.ViewModel
{
    public class ChooseLocationViewModel:BaseViewModel
    {
        #region Atributos
        private double _lat;
        private double _lon;
        private Map _mapa;
        #endregion
        #region Propiedades
        public Map mapa
        {
            get
            {
                return _mapa;
            }
            set
            {
                _mapa = value;OnPropertyChanged("mapa");
            }
        }
        #endregion
        #region Constructor
        public ChooseLocationViewModel()
        {
            _mapa.MoveToRegion(new MapSpan(new Position(1,1),13.994778,-89.556642));
            //13.994778, -89.556642
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
        public ICommand Pin
        {
            get
            {
                return new RelayCommand(SetPin);
            }
        }
        #endregion
        #region Metodos
        public void SetPin()
        {
            
        }
        public void locateMe()
        {
            //terminar registro
        }
        #endregion
    }
}
