
namespace Brot.Patterns
{
    using Models;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class Singleton
    {

        public Singleton()
        {
            stores = new ObservableCollection<userModel>();
            this._Dialogs = new DialogService();
            this._LocalJson = new UserJson();
            img = new PickPhotoAsync();
            isLoggued = VerifyLoggedUser();
        }



        #region Attributes

        private static Singleton _Instance;
        private UserJson _LocalJson;
        private userModel _User;
        private DialogService _Dialogs;
        private PickPhotoAsync img;
        private ObservableCollection<userModel> stores;
        #endregion

        #region MyRegion
        public bool isLoggued;
        public static string passw = String.Empty; 
        public static bool fromProfile;
        public static ImageSource profilepic;
        public static Singleton Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Singleton();

                return _Instance;
            }
        }

        public int id_UserCreator_post { get; set; }

        public userModel User
        {
            set
            {
                if (this._User == value)
                    return;

                this._User = value;
            }
            get { return this._User; }
        }

        public DialogService Dialogs
        {
            get { return this._Dialogs; }
        }

        public UserJson LocalJson
        {
            get { return this._LocalJson; }
        }

        #endregion



        #region Methods
        public void AddStores(ObservableCollection<userModel> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].img = DLL.constantes.urlImages + items[i].img;
            }
            stores = items;
        }
        public void AddStore(userModel item)
        {
            stores.Add(item);
        }
        public userModel GetStore(int id)
        {
            return stores[id];
        }
        private bool VerifyLoggedUser()
        {
            if (!this._LocalJson.IsUserLogged())
            {
                this.User = new userModel() { id_user = 0 };
                return false;
            }

            this.User = this._LocalJson.ReadData();
            return true;
        }
        public async Task<string> ChangePic()
        {
            return await img.ChangePicture();
        }
        #endregion
    }
}
