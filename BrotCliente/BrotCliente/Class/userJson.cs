using BrotCliente.Class;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BrotCliente.Class
{
    public class userJson
    {
        public void SaveData(UserLogged u)
        {
            String result = Newtonsoft.Json.JsonConvert.SerializeObject(u);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(path, "user.txt");
            using (var file = File.Open(filePath, FileMode.Create, FileAccess.Write))
            using (var strm = new StreamWriter(file))
            {
                strm.Write(result);
            }
        }
        public UserLogged ReadData()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(path, "user.txt");
            using (var file = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (var strm = new StreamReader(file))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<UserLogged>(strm.ReadToEnd());
            }
        }
    }
}
