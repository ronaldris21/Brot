namespace BrotVendedor.ViewModel
{
    using BrotApi0.Models;
    using GalaSoft.MvvmLight.Command;
    using Plugin.Media;
    using Plugin.Media.Abstractions;
    using System;
    using System.IO;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ProfileViewModel:BaseViewModel
    {
        #region Atributos
        private String _usuario;
        private String _nombre;
        private String _apellido;
        private String _correo;
        private String _telefono;
        private String _dui;
        private String _clave;
        private ImageSource _picture;
        private MediaFile _mediaFile;
        private users u;
        #endregion
        #region Propiedades
        public String usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value;OnPropertyChanged("usuario");
            }
        }
        public String nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;OnPropertyChanged("nombre");
            }
        }
        public String apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;OnPropertyChanged("apellido");
            }
        }
        public String correo
        {
            get
            {
                return _correo;
            }
            set
            {
                _correo = value;OnPropertyChanged("correo");
            }
        }
        public String telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;OnPropertyChanged("telefono");
            }
        }
        public String dui
        {
            get
            {
                return _dui;
            }
            set
            {
                _dui = value;OnPropertyChanged("dui");
            }
        }
        public String clave
        {
            get
            {
                return _clave;
            }
            set
            {
                _clave = value;OnPropertyChanged("clave");
            }
        }
        public ImageSource picture
        {
            get
            {
                return _picture;
            }
            set
            {
                _picture = value;OnPropertyChanged("picture");
            }
        }
        #endregion
        #region Constructor
        public ProfileViewModel()
        {
            picture = "user128x128";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(path, "user.txt");
            using (var file = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (var strm = new StreamReader(file))
            {
                u = Newtonsoft.Json.JsonConvert.DeserializeObject<users>(strm.ReadToEnd());
            }
            usuario = u.username;
            clave = u.pass;
        }
        #endregion
        #region Commands
        public ICommand ChangeProfilePicture
        {
            get
            {
                return new RelayCommand(ChangePicture);
            }
        }
        #endregion
        #region Metodos
        public async void ChangePicture()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No es posible elegir una foto", "Aceptar");
                return;
            }
            _mediaFile = await CrossMedia.Current.PickPhotoAsync();
            if (_mediaFile==null)
            {
                return;
            }
            picture = ImageSource.FromStream(() =>
            {
                return _mediaFile.GetStream();
            });
        }
        #endregion
    }
}
