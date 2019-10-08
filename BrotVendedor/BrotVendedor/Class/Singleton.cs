using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrotVendedor.Class
{
    public class Singleton
    {
        private static Singleton instance;
        private userJson json;
        private MediaFile _mediaFile;
        private PickPhotoAsync img;
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
