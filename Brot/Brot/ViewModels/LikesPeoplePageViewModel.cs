using AsyncAwaitBestPractices;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Brot.ViewModels
{
    public enum likeType
    {
        comentarios,
        publicacion,
        seguidos,
        seguidores
    }


    public class LikesPeoplePageViewModel : BaseViewModel
    {
        private likeType tipolike;
        private int id;

        public Models.ResponseApi.ResponseLikes likesRoot;

        private ObservableCollection<Models.userModel> _users;
        public ObservableCollection<Models.userModel> USUARIOS
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        public LikesPeoplePageViewModel(int id, ViewModels.likeType tipolike)
        {
            switch (tipolike)
            {
                case likeType.comentarios:
                    Title = "Likes";
                    break;
                case likeType.publicacion:
                    Title = "Likes";
                    break;
                case likeType.seguidos:
                    Title = "Seguidos";
                    break;
                case likeType.seguidores:
                    Title = "Seguidores";
                    break;
                default:
                    Title = "";
                    break;
            }
            this.id = id;
            this.tipolike = tipolike;
            RefreshMethodAsync().ConfigureAwait(false);
        }

        private ICommand _RefreshCommand;
        public ICommand RefreshCommand => _RefreshCommand ??= new Xamarin.Forms.Command(() => RefreshMethodAsync().SafeFireAndForget());

        async System.Threading.Tasks.Task RefreshMethodAsync()
        {
            IsRefreshing = true;

            likesRoot = null;

            try
            {
                switch (tipolike)
                {
                    case likeType.comentarios:
                        likesRoot = await Services.RestAPI.GetLikesbyIDComentario(id).ConfigureAwait(false);
                        break;

                    case likeType.publicacion:
                        likesRoot = await Services.RestAPI.GetLikesbyIDPost(id).ConfigureAwait(false);
                        break;
                    case likeType.seguidos:
                        likesRoot = new Models.ResponseApi.ResponseLikes();
                        likesRoot.usuarios = await Services.RestAPI.getSeguidos(id).ConfigureAwait(false);
                        break;
                    case likeType.seguidores:
                        likesRoot = new Models.ResponseApi.ResponseLikes();
                        likesRoot.usuarios = await Services.RestAPI.getSeguidores(id).ConfigureAwait(false);
                        break;
                }

                if (likesRoot != null)
                {
                    USUARIOS = new ObservableCollection<Models.userModel>();
                    for (int i = 0; i < likesRoot.usuarios.Count; i++)
                    {
                        if (likesRoot.usuarios[i].img == null)
                        {
                            likesRoot.usuarios[i].img = DLL.constantes.ProfileImageError;
                        }
                        else
                        {
                            likesRoot.usuarios[i].img = DLL.constantes.urlImages + likesRoot.usuarios[i].img;
                        }
                        USUARIOS.Add(likesRoot.usuarios[i]);
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }


            IsRefreshing = false;
            OnPropertyChanged(nameof(IsRefreshing));
        }

    }
}
