namespace Brot.ViewModels
{
    using AsyncAwaitBestPractices;
    using Brot.Models.ResponseApi;
    using Brot.Patterns;
    using Brot.Services;
    using Brot.Views;
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;
    public class ProfileViewModel : BaseViewModel
    {
        private ResponseUserProfile _Usuario;
        public ResponseUserProfile UserProfile
        {
            get { return this._Usuario; }
            set => SetProperty(ref _Usuario, value);
        }

        private string _UsuarioNombreMostrar = "Usuario";
        public string UsuarioNombreMostrar
        {
            set => SetProperty(ref _UsuarioNombreMostrar, value);
            get => _UsuarioNombreMostrar;
        }

        private bool _VerPostPropios;
        public bool VerPostPropios
        {
            get { return _VerPostPropios; }
            set { SetProperty(ref _VerPostPropios, value); }
        }

        private ResponsePublicacionFeed _publicacionesThis;

        public ResponsePublicacionFeed publicacionesThis
        {
            get { return _publicacionesThis; }
            set
            {
                if (value != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new Post(new PostViewModel(value), value.publicacion.id_user));
                    SetProperty(ref _publicacionesThis, null);
                }
            }
        }

        private ObservableCollection<ResponsePublicacionFeed> _PublicacionesMostradas;
        public ObservableCollection<ResponsePublicacionFeed> publicacionesMostradas
        {
            get { return _PublicacionesMostradas; }
            set { SetProperty(ref _PublicacionesMostradas, value); }
        }
        #region Commands

        public ICommand EditProfileCommand
        {
            get { return new Command(EditProfile); }
        }
        public ICommand SignOutCommand { get { return new Command(Signout); } }

        private Xamarin.Forms.Command _RefreshCommand;
        public Xamarin.Forms.Command RefreshCommand
        {
            get => _RefreshCommand ??= new Xamarin.Forms.Command(()=> CargarDatos().SafeFireAndForget());
        }
        #endregion


        public ProfileViewModel()
        {
            VerPostPropios = Singleton.Instance.User.isVendor;
            CargarDatos().SafeFireAndForget();
        }
        public async Task CargarDatos()
        {
            IsRefreshing = true;

            ResponseUserProfile profiledata = await RestAPI.userprofile(Singleton.Instance.User.id_user).ConfigureAwait(false);

            if (profiledata != null)
            {
                if (profiledata.UserProfile.img != null)
                {
                    profiledata.UserProfile.img = DLL.constantes.urlImages + profiledata.UserProfile.img;
                }
                else
                {
                    profiledata.UserProfile.img = DLL.constantes.ProfileImageError;
                }

                //Publicaciones Propias
                for (int i = 0; i < profiledata.publicacionesUser.Count; i++)
                {
                    ///No verifico si la imagen es null, porque ya lo hice en alguna page anterior
                    profiledata.publicacionesUser[i].UsuarioCreator = profiledata.UserProfile;
                    profiledata.publicacionesUser[i].publicacion.img = DLL.constantes.urlImages + profiledata.publicacionesUser[i].publicacion.img;
                }

                //Postsguardados
                for (int i = 0; i < profiledata.publicacionesGuardadas.Count; i++)
                {
                    try
                    {
                        profiledata.publicacionesGuardadas[i].UsuarioCreator.img = String.IsNullOrEmpty(profiledata.publicacionesGuardadas[i].UsuarioCreator.img)
                                    ? DLL.constantes.ProfileImageError
                                    : DLL.constantes.urlImages + profiledata.publicacionesGuardadas[i].UsuarioCreator.img;
                        profiledata.publicacionesGuardadas[i].publicacion.img = DLL.constantes.urlImages + profiledata.publicacionesGuardadas[i].publicacion.img;
                    }
                    catch (Exception)
                    {
                        ///No llegar el usuario
                        ///TODO Modificar api Usuario de pOst guardados
                    }
                }

                //La intención es que el SetProperty solo se ejecute una única vez!
                UserProfile = profiledata;



                if (VerPostPropios)
                {
                    publicacionesMostradas = new ObservableCollection<ResponsePublicacionFeed>(UserProfile.publicacionesUser);
                }
                else
                {
                    publicacionesMostradas = new ObservableCollection<ResponsePublicacionFeed>(UserProfile.publicacionesGuardadas);
                }
            }

            UsuarioNombreMostrar = UserProfile.UserProfile.isVendor ? UserProfile.UserProfile.puesto_name : UserProfile.UserProfile.nombre + " " + UserProfile.UserProfile.apellido;
            IsRefreshing = false;

        }
        #region Methods

        private void EditProfile()
        {
            Application.Current.MainPage.Navigation.PushAsync(new EditProfile());
        }
        private void Signout()
        {
            IsRefreshing = true;
            RestClient.Put<Models.userModel>("users/logout", Singleton.Instance.User.id_user, Singleton.Instance.User).SafeFireAndForget();
            Singleton.Instance.LocalJson.SignOut();
            var newPage = new NavigationPage(new Login());
            App.Current.MainPage = newPage;
            Microsoft.AppCenter.Push.Push.SetEnabledAsync(false).SafeFireAndForget();
        }


        private Xamarin.Forms.Command _ChangePostPropiosViews;
        public Xamarin.Forms.Command ChangePostPropiosViews
        {
            get => _ChangePostPropiosViews ?? (_ChangePostPropiosViews = new Xamarin.Forms.Command<string>(ChangePostPropiosViewsMethod));
        }
        private void ChangePostPropiosViewsMethod(string obj)
        {
            if (obj != "Null")
            {
                if (obj == "True")
                {
                    VerPostPropios = true;
                }
                else
                {
                    VerPostPropios = false;
                }
            }

            if (VerPostPropios)
            {
                if (UserProfile.publicacionesUser != null)
                {
                    publicacionesMostradas = new ObservableCollection<ResponsePublicacionFeed>(UserProfile.publicacionesUser);
                }
            }
            else
            {
                if (UserProfile.publicacionesGuardadas != null)
                {
                    publicacionesMostradas = new ObservableCollection<ResponsePublicacionFeed>(UserProfile.publicacionesGuardadas);
                }
            }

        }

        #endregion
    }
}
