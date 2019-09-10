using DLL.ResponseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BrotCliente.ViewModels
{
    public class PostViewModel : BaseViewModel
    {
        public ObservableCollection<string> lista { get; }
        private ResponsePublicacionFeed _Post;

        public PostViewModel()
        {
            this.lista = new ObservableCollection<string>();
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
            this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        }

        public ResponsePublicacionFeed Post
        {
            get { return _Post; }
            set
            {
                _Post = value;
                OnPropertyChanged();
            }
        }
        public PostViewModel(ResponsePublicacionFeed item)
        {
            this.Post = item;
        }
    }
}
