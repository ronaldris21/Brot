using DLL.Models;
using BrotCliente.Patterns;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BrotCliente.Services
{
    public class UserJson
    {
        private readonly string _Path;
        private readonly string _FilePath;

        public UserJson()
        {
            this._Path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            this._FilePath = Path.Combine(this._Path, "user.json");
        }
        public void SaveUser(userModel user)
        {
            String result = Newtonsoft.Json.JsonConvert.SerializeObject(user);

            using (var file = File.Open(this._FilePath, FileMode.Create, FileAccess.Write))

            using (var strm = new StreamWriter(file))
            {
                strm.Write(result);
                strm.Close();
            }
        }
        public userModel ReadUser()
        {            
            using (var file = File.Open(this._FilePath, FileMode.Open, FileAccess.Read))

            using (var strm = new StreamReader(file))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<userModel>(strm.ReadToEnd());
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
                await Singleton.Instance.Dialogs.Message("Error al borrar user.json", ex.Message);
            }
        }
    }
}
