using BrotVendedor.Model;
using DLL.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BrotVendedor.Class
{
    public class Singleton
    {
        private static Singleton instance;
        private userJson json;
        private MediaFile _mediaFile;
        private PickPhotoAsync img;
        private userModel _user;
        public static Singleton current
        {
            get
            {
                if (instance==null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
        public userJson Json
        {
            get
            {
                return json;
            }
        }
        public userModel user
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }
        public Singleton()
        {
            json = new userJson();
            img = new PickPhotoAsync();
            VerifyLoggedUser();

        }
        public void ChangePic()
        {
            img.ChangePicture();
        }

        private void VerifyLoggedUser()
        {
            if (!this.json.IsUserLogged())
                return;

            this.user = this.json.ReadData();
        }

    }
}
