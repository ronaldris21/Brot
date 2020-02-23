

namespace Brot.ViewModels
{
    using AsyncAwaitBestPractices;
    using Brot.Patterns;
    using Brot.Services;
    using Brot.Views;
    using Models.ResponseApi;
    using System.Threading.Tasks;

    public class SellerProfileViewModel : BaseViewModel
    {
        private ResponseUserProfile _Usuario;
        private ResponsePublicacionFeed _publicacionesThis;
        private int idUser;
        public ResponsePublicacionFeed publicacionesThis
        {
            get { return _publicacionesThis; }
            set
            {
                if (value != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new Post(new PostViewModel(value),value.publicacion.id_user));
                    SetProperty(ref _publicacionesThis, null);
                }
            }
        }
        public ResponseUserProfile UserProfile
        {
            get { return this._Usuario; }
            set => SetProperty(ref _Usuario, value);
        }
        private bool _isMyProfile;
        public bool isMyProfile
        {
            get => _isMyProfile;
            set => SetProperty(ref _isMyProfile, value);
        }

        private Xamarin.Forms.Command _RefreshCommand;
        public Xamarin.Forms.Command RefreshCommand
        {
            get => _RefreshCommand ??= new Xamarin.Forms.Command(()=>CargarDatos().SafeFireAndForget());
        }


        public SellerProfileViewModel(Brot.Models.userModel usuarioModel)
        {
            isMyProfile = usuarioModel.id_user == Singleton.Instance.User.id_user;
            UserProfile = new ResponseUserProfile()
            {
                UserProfile = usuarioModel
            };
            idUser = usuarioModel.id_user;
            CargarDatos().SafeFireAndForget();
        }

        public async Task CargarDatos()
        {
            IsRefreshing = true;
            ResponseUserProfile profiledata = new ResponseUserProfile();
            if (isMyProfile)
            {
                //Mi perfil!
                profiledata = await RestAPI.userprofile(Singleton.Instance.User.id_user).ConfigureAwait(false); 
            }
            else
            {
                //Perfil de otro
                profiledata = await RestAPI.GetOtherUserrofile(idUser, Singleton.Instance.User.id_user).ConfigureAwait(false);
            }

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

                for (int i = 0; i < profiledata.publicacionesUser.Count; i++)
                {
                    ///No verifico si la imagen es null, porque ya lo hice en alguna page anterior
                    profiledata.publicacionesUser[i].UsuarioCreator = profiledata.UserProfile;
                    profiledata.publicacionesUser[i].publicacion.img = DLL.constantes.urlImages + profiledata.publicacionesUser[i].publicacion.img;
                }
                UserProfile = profiledata;
            }
            IsRefreshing = false;
            OnPropertyChanged(nameof(IsRefreshing));
        }

    }
}
