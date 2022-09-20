namespace Brot.ViewModels
{

    #region BaseViewmodel Class
    using System;
    public class BaseViewModel : ObservableObject 
    {

        private string _Title = String.Empty;
        public string Title
        {
            get { return this._Title; }
            set => SetProperty(ref _Title, value);
        }


        bool isRefreshing;
        public bool IsRefreshing
		{
			get => isRefreshing;
			set
			{
				if (SetProperty(ref isRefreshing, value))
					IsNotBusy = !isRefreshing;
			}
		}
		bool isNotBusy = true;
		public bool IsNotBusy
		{
			get => isNotBusy;
			set
			{
				if (SetProperty(ref isNotBusy, value))
					IsRefreshing = !isNotBusy;
			}
		}
        

    }


    #endregion
}
