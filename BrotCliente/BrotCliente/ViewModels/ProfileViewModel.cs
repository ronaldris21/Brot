using BrotCliente.Views;
using DLL.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BrotCliente.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        #region Attributes

        public ICommand EditProfileCommand
        {
            get { return new RelayCommand(EditProfile); }
        }
        public ICommand SignoutCommand { get { return new RelayCommand(Signout); } }




        #endregion

        #region Methods

        private void Signout()
        {
            //Programar el Signout
        }
        private void EditProfile()
        {
            Application.Current.MainPage.Navigation.PushAsync(new EditProfile());
        }

        private userModel _UserData;
        public userModel Usuario
        {
            get { return _UserData; }
            set
            {
                if (_UserData != value)
                {
                    _UserData = value;
                    OnPropertyChanged("Usuario");
                    FullName = Usuario.nombre + Usuario.apellido;

                }
            }
        }

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if(_fullName != value)
                {
                    _fullName =value;
                    OnPropertyChanged("FullName");
                }
            }
        }



        #endregion
    }
}
