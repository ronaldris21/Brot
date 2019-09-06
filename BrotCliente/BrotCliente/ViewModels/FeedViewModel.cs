using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BrotCliente.ViewModels
{
    class FeedViewModel
    {
        public ObservableCollection<Publicaciones> lPosts;

        public FeedViewModel()
        {
            this.lPosts = new ObservableCollection<Publicaciones>();
        }
    }
}
