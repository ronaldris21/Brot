using DLL.Models;
using BrotCliente.Patterns;
using BrotCliente.Services;
using DLL.ResponseModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using BrotCliente.Views;

namespace BrotCliente.ViewModels
{
    public class FeedViewModel : BaseViewModel
    {
        #region Attributes

        private ObservableCollection<ResponsePublicacionFeed> _lPosts;

        #endregion

        #region Properties
        private ResponsePublicacionFeed _selectedItemLista;
        public ResponsePublicacionFeed selectedItemLista
        {
            get { return _selectedItemLista; }
            set
            {
                if (!EqualityComparer<object>.Default.Equals(_selectedItemLista, value))
                {
                    _selectedItemLista = value;
                    App.Current.MainPage.Navigation.PushAsync(new Post(new PostViewModel(_selectedItemLista)));
                    _selectedItemLista = null;
                    OnPropertyChanged("selectedItemLista");

                }
            }
        }
        public ObservableCollection<ResponsePublicacionFeed> lPosts
        {
            get { return this._lPosts; }
            set
            {
                if (this._lPosts == value)
                    return;

                this._lPosts = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public FeedViewModel()
        {
            this.lPosts = new ObservableCollection<ResponsePublicacionFeed>();
            LoadFeed();
        }

        #endregion

        #region Commands

        public ICommand RefreshCommand
        {
            get { return new RelayCommand(Refresh); }
        }

        public ICommand LikeCommand
        {
            get
            {
                return new RelayCommand<int>(Like);
            }
        }

        #endregion

        #region Methods

        public async void Refresh()
        {
            if (IsRefreshing)
                return;

            IsRefreshing = true;

            try
            {
                this.lPosts.Clear();
                LoadFeed();
            }
            catch (Exception)
            {
                await Singleton.Instance.Dialogs.Message("Is busy", "Couldn't load items");
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private async void Like(int idLike)
        {
            await App.Current.MainPage.DisplayAlert("EXITO", "Has presionado el boton " + idLike, "Ok");
        }

        public async void LoadFeed()
        {
            var result = await RestClient.GetAll<ResponsePublicacionFeed>($"publicaciones/all/{Singleton.Instance.User.id_user}/");

            if (!result.IsSuccess)
            {
                await Singleton.Instance.Dialogs.Message("There was a problem trying to get the feed", result.Message);
                return;
            }

            foreach (var post in (ObservableCollection<ResponsePublicacionFeed>) result.Result)
            {
                post.publicacion.img = "http://images.somee.com/uploads/" + post.publicacion.img;
                this.lPosts.Add(post);
            }
        }

        

        #endregion
    }
}
