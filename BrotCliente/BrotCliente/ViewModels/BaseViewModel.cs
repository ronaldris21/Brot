using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BrotCliente.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region IPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
