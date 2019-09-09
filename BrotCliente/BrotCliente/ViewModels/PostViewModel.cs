using DLL.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrotCliente.ViewModels
{
    public class PostViewModel : BaseViewModel
    {
        private ResponsePublicacionFeed _Post;

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
