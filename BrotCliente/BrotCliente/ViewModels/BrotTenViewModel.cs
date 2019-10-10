
using DLL.Models;
using DLL.ResponseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BrotCliente.ViewModels
{
    class BrotTenViewModel : BaseViewModel
    {
        private ObservableCollection<ResponseUserProfile> _lBrotTen;

        public ObservableCollection<ResponseUserProfile> lBrotTen
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
            this.lBrotTen = new ObservableCollection<ResponseUserProfile>();

            cargarUsers();
        }

        //SOLO PRUBEA
        //BORRAR CUANDO FUNCIONE EL API 
        public void cargarUsers()
        {
            ResponseUserProfile u1 = new ResponseUserProfile()
            {
                cantSeguidores = 100,
                user = new userModel()
                {
                    nombre = "Ingeniero",
                    apellido = "Original",
                    username = "IngeUes123",
                    img = "https://py-softwaresv.com/wp-content/uploads/2019/08/Logo_Square_512-300x300.png",
                    descripcion = "Estamos arriba de la UES",
                    isActive = true
                }
            };

            ResponseUserProfile u2 = new ResponseUserProfile()
            {
                cantSeguidores = 100,
                user = new userModel()
                {
                    nombre = "Panito",
                    apellido = "Original",
                    username = "PanitoISA",
                    img = "https://py-softwaresv.com/wp-content/uploads/2019/08/Logo_Square_512-300x300.png",
                    descripcion = "Estamos afuera del INSA",
                    isActive = false
                }
            };

            ResponseUserProfile u3 = new ResponseUserProfile()
            {
                cantSeguidores = 100,
                user = new userModel()
                {
                    nombre = "Catedral",
                    apellido = "Unknown",
                    username = "CatedraSanta2019",
                    img = "https://py-softwaresv.com/wp-content/uploads/2019/08/Logo_Square_512-300x300.png",
                    descripcion = "Estamos afuera de la catedral",
                    isActive = true
                }
            };

            ResponseUserProfile u4 = new ResponseUserProfile()
            {
                cantSeguidores = 100,
                user = new userModel()
                {
                    nombre = "Otros",
                    apellido = "Panes",
                    username = "FacturaPuertas",
                    img = "https://py-softwaresv.com/wp-content/uploads/2019/08/Logo_Square_512-300x300.png",
                    descripcion = "Panes oficiales de Microsoft",
                    isActive = true
                }
            };

            this.lBrotTen.Add(u1);
            this.lBrotTen.Add(u2);
            this.lBrotTen.Add(u3);
            this.lBrotTen.Add(u4);
        }
    }
}
