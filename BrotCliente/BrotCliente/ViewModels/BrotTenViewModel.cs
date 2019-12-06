
using BrotCliente.Services;
using DLL.Models;
using DLL.ResponseModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BrotCliente.ViewModels
{
    class BrotTenViewModel : BaseViewModel
    {
        private ObservableCollection<ResponseUsuariosFiltro> _lBrotTen;

        public ObservableCollection<ResponseUsuariosFiltro> lBrotTen
        {
            get { return this._lBrotTen; }
            set
            {
                if (this._lBrotTen == value)
                    return;

                this._lBrotTen = value;
                OnPropertyChanged();
            }
        }

        public BrotTenViewModel()
        {
            this.lBrotTen = new ObservableCollection<ResponseUsuariosFiltro>();

            cargarUsers();
        }

        //SOLO PRUBEA
        //BORRAR CUANDO FUNCIONE EL API 
        public async void cargarUsers()
        {
            //this.lBrotTen.Add(u1);
            //this.lBrotTen.Add(u2);
            //this.lBrotTen.Add(u3);
            //this.lBrotTen.Add(u4);


            var resultBrotTEN = await RestAPI.getBrotTen();
            this._lBrotTen.Clear();
            for (int i = 0; i < resultBrotTEN.Count; i++)
            {
                resultBrotTEN[i].userData.img = DLL.constantes.urlImages + resultBrotTEN[i].userData.img;
            }

            lBrotTen = new ObservableCollection<ResponseUsuariosFiltro>(resultBrotTEN);

        }

        public System.Windows.Input.ICommand RefreshCommand { get { return new RelayCommand(cargarUsers); } }
    }
}
