﻿

namespace Brot.Services
{

    using Models;
    using Brot.Patterns;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AppCenter.Crashes;

    public class UserJson
    {
        private readonly string _Path;
        private readonly string _FilePath;

        public UserJson()
        {
            this._Path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (Xamarin.Forms.Device.iOS == Xamarin.Forms.Device.RuntimePlatform)
            {
                this._Path = Path.Combine(this._Path, "..", "Library");
            }
            this._FilePath = Path.Combine(this._Path, "user.json");
        }
        public void SaveData(userModel user)
        {
            String result = Newtonsoft.Json.JsonConvert.SerializeObject(user);

            using (var file = File.Open(this._FilePath, FileMode.Create, FileAccess.Write))

            using (var strm = new StreamWriter(file))
            {
                strm.Write(result);
                strm.Close();
            }
        }
        public userModel ReadData()
        {
            try
            {
                using (var file = File.Open(this._FilePath, FileMode.Open, FileAccess.Read))
                using (var strm = new StreamReader(file))
                {
                    //TODO Aqui muere en iOS!!
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<userModel>(strm.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string>() { { "Json", "ReadData" } });
                return new userModel();
            }

        }

        public bool IsUserLogged()
        {
            return File.Exists(this._FilePath);
        }

        public async void SignOut()
        {
            try
            {
                File.Delete(this._FilePath);
            }
            catch (Exception ex)
            {
                await Singleton.Instance.Dialogs.Message("Error al cerrar sesión, vuelve a intentarlo", ex.Message);
                Crashes.TrackError(ex, new Dictionary<string, string>() { { "Json", "Signout" } });
            }
        }

        public async Task<bool> validarUsuarioinDB()
        {
            //TODO Implementar validarUsuarioinDB para iniciar sesión!!!! NICE
            try
            {
                userModel data = this.ReadData();
                userModel result = await RestAPI.login(data.pass, data.username);
                if (result == null)
                {
                    SignOut();
                    return false;
                }
                this.SaveData(result);
                return true;
            }
            catch (Exception ex)
            {
                this.SignOut();
                Crashes.TrackError(ex, new Dictionary<string, string>() { { "Json", "validarUsuarioinDB" } });
            }
            return false;
        }
    }
}
