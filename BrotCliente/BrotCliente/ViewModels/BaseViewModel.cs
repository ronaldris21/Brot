using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BrotCliente.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Attributes

        private bool _IsRefreshing = false;
        private string _Title = "Empty";

        #endregion

        #region properties

        public bool IsRefreshing
        {
            get { return _IsRefreshing; }
            set
            {
                _IsRefreshing = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return this._Title; }
            set
            {
                _Title = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
