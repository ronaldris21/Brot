
namespace Brot.ViewModels
{
    using Models;
    using Brot.Patterns;
    using Brot.Services;
    using Models.ResponseApi;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Text;
    using System.Windows.Input;
    using Views;
    using System.Threading.Tasks;
    using AsyncAwaitBestPractices;
    using AsyncAwaitBestPractices.MVVM;

    public class FeedViewModel : BaseViewModel
    {
        #region Attributes

        private ObservableCollection<ResponsePublicacionFeed> _lPosts;
        private String _texto;
        private bool _isVendor;
        private ResponsePublicacionFeed _selectedItemLista;
        #endregion

        #region Properties

        public bool IsVendor
        {
            get { return _isVendor; }
            set { SetProperty(ref _isVendor, value); }
        }
        public String texto
        {
            get => _texto;
            set => SetProperty(ref _texto, value);
        }
        public ResponsePublicacionFeed selectedItemLista
        {
            get { return _selectedItemLista; }
            set
            {
                if (value != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new Post(new PostViewModel(value), value.publicacion.id_user));
                    SetProperty(ref _selectedItemLista, null);
                }
            }
        }
        public ObservableCollection<ResponsePublicacionFeed> lPosts
        {
            get { return this._lPosts; }
            set => SetProperty(ref _lPosts, value);
        }

        #endregion

        #region Constructor

        public FeedViewModel()
        {
            IsVendor = Singleton.Instance.User.isVendor;
            //LoadFeed().SafeFireAndForget();
            this.RefreshCommand.Execute(null);
        }

        #endregion

        #region Commands
        public ICommand takePhoto
        {
            get
            {
                return new Xamarin.Forms.Command(cp);
            }
        }
        private async void cp()
        {
            await Singleton.Instance.ChangePic();
        }
        private Xamarin.Forms.Command _RefreshCommand;
        public Xamarin.Forms.Command RefreshCommand
        {
            get => _RefreshCommand ?? (_RefreshCommand = new Xamarin.Forms.Command(()=>LoadFeed().SafeFireAndForget()));
        }

        private IAsyncCommand _PostSomething;
        public IAsyncCommand PostSomething => _PostSomething ??= new AsyncCommand(AddPost);
        public async Task AddPost()
        {
            IsRefreshing = true;
            publicacionesModel niu = new publicacionesModel();
            niu.fecha_creacion = DateTime.Now;
            niu.id_user = Singleton.Instance.User.id_user;
            if (PickPhotoAsync.name == null)
            {
                niu.img = null;
                niu.isImg = false;
            }
            else
            {
                niu.img = PickPhotoAsync.name;
                niu.isImg = true;
            }
            niu.descripcion = texto;
            niu.isDeleted = false;
            niu.fecha_actualizacion = null;
            texto = "";
            PickPhotoAsync.name = null;
            Response resp = await RestClient.Post<publicacionesModel>("publicaciones", niu).ConfigureAwait(false);
            if (!resp.IsSuccess)
            {
                Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Error", resp.Message, "Aceptar");
                    IsRefreshing = false;
                });
                return;
            }

            lPosts = new ObservableCollection<ResponsePublicacionFeed>();
            await LoadFeed().ConfigureAwait(false);
            IsRefreshing = false;
        }


        #endregion

        #region Methods

        public async Task LoadFeed()
        {

            IsRefreshing = true;
            var result = await RestClient.GetAll<ResponsePublicacionFeed>($"publicaciones/all/{Singleton.Instance.User.id_user}/").ConfigureAwait(false);

            if (!result.IsSuccess)
            {
                Plugin.Toast.CrossToastPopUp.Current.ShowToastError("Hubo un problema intentando cargar las publicaciones");
                return;
            }
            var datosNuevos= new List<ResponsePublicacionFeed>();
            foreach (var post in (ObservableCollection<ResponsePublicacionFeed>)result.Result)
            {

                post.publicacion.img = DLL.constantes.urlImages + post.publicacion.img;

                if (string.IsNullOrEmpty(post.UsuarioCreator.img))
                {
                    post.UsuarioCreator.img = DLL.constantes.ProfileImageError;
                }
                else
                {
                    post.UsuarioCreator.img = DLL.constantes.urlImages + post.UsuarioCreator.img;
                }
                datosNuevos.Add(post);
            }
            lPosts = new ObservableCollection<ResponsePublicacionFeed>(datosNuevos);

            IsRefreshing = false;
        }

        #endregion
    }
}
