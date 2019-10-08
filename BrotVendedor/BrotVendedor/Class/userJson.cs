using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BrotVendedor.Class
{
    public class userJson
    {
        public void SaveData(LocalUser u)
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
        public LocalUser ReadData()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(path, "user.txt");
            using (var file = File.Open(filePath, FileMode.Open, FileAccess.Read))
            using (var strm = new StreamReader(file))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<LocalUser>(strm.ReadToEnd());
            }
        }
    }
}
