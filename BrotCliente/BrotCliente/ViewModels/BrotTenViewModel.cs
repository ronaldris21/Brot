
using BrotCliente.Class;
using DLL.Models;
using DLL.ResponseModels;
using DLL.Service;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace BrotCliente.ViewModels
{
    class BrotTenViewModel : BaseViewModel
    {
        private ObservableCollection<ResponseUsuariosFiltro> _lBrotTen;
        public ICommand RefreshCommand { get { return new RelayCommand(RefreshMethod); } }

        

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
            RefreshMethod();
            //cargarUsers();
        }

        private async void RefreshMethod()
        {
            if (IsRefreshing)
                return;

            IsRefreshing = true;
            try
            {
                var result = await RestAPI.getBrotTen();
                if (result!=null)
                {
                    lBrotTen = new ObservableCollection<ResponseUsuariosFiltro>(result);
                    Dialogos.ToastOk("Broten actualizado", 1000);
                }
                else
                {
                    Dialogos.ToastBAD("No es posible actualizar", 1200);
                }
            }
            catch (Exception)
            {
                IsRefreshing = false;
            }
        }


        //SOLO PRUBEA
        //BORRAR CUANDO FUNCIONE EL API 
        //public void cargarUsers()
        //{
        //    ResponseUserProfile u1 = new ResponseUserProfile()
        //    {
        //        cantSeguidores = 100,
        //        user = new userModel()
        //        {
        //            nombre = "Ingeniero",
        //            apellido = "Original",
        //            username = "IngeUes123",
        //            img = "https://py-softwaresv.com/wp-content/uploads/2019/08/Logo_Square_512-300x300.png",
        //            descripcion = "Estamos arriba de la UES",
        //            isActive = true
        //        }
        //    };

        //    ResponseUserProfile u2 = new ResponseUserProfile()
        //    {
        //        cantSeguidores = 100,
        //        user = new userModel()
        //        {
        //            nombre = "Panito",
        //            apellido = "Original",
        //            username = "PanitoISA",
        //            img = "https://py-softwaresv.com/wp-content/uploads/2019/08/Logo_Square_512-300x300.png",
        //            descripcion = "Estamos afuera del INSA",
        //            isActive = false
        //        }
        //    };

        //    ResponseUserProfile u3 = new ResponseUserProfile()
        //    {
        //        cantSeguidores = 100,
        //        user = new userModel()
        //        {
        //            nombre = "Catedral",
        //            apellido = "Unknown",
        //            username = "CatedraSanta2019",
        //            img = "https://py-softwaresv.com/wp-content/uploads/2019/08/Logo_Square_512-300x300.png",
        //            descripcion = "Estamos afuera de la catedral",
        //            isActive = true
        //        }
        //    };

        //    ResponseUserProfile u4 = new ResponseUserProfile()
        //    {
        //        cantSeguidores = 100,
        //        user = new userModel()
        //        {
        //            nombre = "Otros",
        //            apellido = "Panes",
        //            username = "FacturaPuertas",
        //            img = "https://py-softwaresv.com/wp-content/uploads/2019/08/Logo_Square_512-300x300.png",
        //            descripcion = "Panes oficiales de Microsoft",
        //            isActive = true
        //        }
        //    };

        //    this.lBrotTen.Add(u1);
        //    this.lBrotTen.Add(u2);
        //    this.lBrotTen.Add(u3);
        //    this.lBrotTen.Add(u4);
        //}

    }
}
