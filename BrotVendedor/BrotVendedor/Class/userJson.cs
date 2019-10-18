using BrotVendedor.Model;
using DLL.Models;
using DLL.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BrotVendedor.Class
{
    public class userJson
    {

        private readonly string _Path;
        private readonly string _FilePath;


        public userJson()
        {
            this._Path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
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

        public void SignOut()
        {
            File.Delete(this._FilePath);
        }

        public async Task<bool> validarUsuarioinDB()
        {
            try
            {
                userModel data = this.ReadData();
                userModel result = await RestAPI.login(data.pass, data.username);
                if (result==null)
                {
                    SignOut();
                }
                this.SaveData(result);
                return true;
            }
            catch (Exception)
            {
                this.SignOut();
            }
            return false;
        }
    }
}
