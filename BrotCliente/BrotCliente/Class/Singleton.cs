using BrotCliente.Class;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BrotCliente.Class
{
    public class Singleton
    {
        private static  Singleton instance;
        private userJson json;
        private MediaFile _mediaFile;
        private PickPhotoAsync img;
        private static UserLogged _usuario;

        public static UserLogged Usuario
        {
            get
            {
                if (_usuario==null)
                {
                    _usuario = new UserLogged();
                }
                return _usuario;
            }
            set
            {
                if (_usuario!=value)
                {
                    _usuario = value;
                }
            }
        }

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
        public Singleton()
        {
            json = new userJson();
            img = new PickPhotoAsync();
        }
        public void ChangePic()
        {
            img.ChangePicture();
        }
        
    }
}
