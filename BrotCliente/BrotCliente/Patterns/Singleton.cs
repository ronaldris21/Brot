using DLL.Models;
using BrotCliente.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrotCliente.Patterns
{
    public class Singleton
    {
        #region Attributes

        private static Singleton _Instance;
        private UserJson _LocalJson;
        private userModel _User;
        private DialogService _Dialogs;

        #endregion

        #region MyRegion

        public static Singleton Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Singleton();

                return _Instance;
            }
        }

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

        #region Constructor

        public Singleton()
        {
            this._Dialogs = new DialogService();
            this._LocalJson = new UserJson();

            VerifyLoggedUser();
        }

        #endregion

        #region Methods

        public void VerifyLoggedUser()
        {
            if (!this._LocalJson.IsUserLogged())
                return;

            this.User = this._LocalJson.ReadUser();
        }

        public void SignOut()
        {
            if (this.User == null)
                return;

            this._LocalJson.SignOut();
        }

        #endregion
    }
}
