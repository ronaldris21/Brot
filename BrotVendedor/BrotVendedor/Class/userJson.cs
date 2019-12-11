using BrotVendedor.Model;
using DLL.Models;
using DLL.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BrotVendedor.Class
{
    public class userJson
    {

        private readonly string _Path;
        private readonly string _FilePath;

        public void SaveData(Usuario u)
        {
            
            Singleton.current.user = u;
            String result = Newtonsoft.Json.JsonConvert.SerializeObject(u);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (Device.iOS== Device.RuntimePlatform)
            {
                path = Path.Combine(path, "..", "library");
            }
            string filePath = Path.Combine(path, "user.json");
            using (var file = File.Open(filePath, FileMode.Create, FileAccess.Write))
            using (var strm = new StreamWriter(file))
            {
                strm.Write(result);
            }
        }
        public Usuario ReadData()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (Device.iOS == Device.RuntimePlatform)
            {
                path = Path.Combine(path, "..", "library");
            }
            string filePath = Path.Combine(path, "user.json");
            using (var file = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (var strm = new StreamReader(file))
            {
                Singleton.current.user = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(strm.ReadToEnd());
                return Singleton.current.user;
            }
        }

    }
}
