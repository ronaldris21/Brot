using System;
using System.Collections.Generic;
using System.Text;

namespace BrotVendedor.Class
{
    class LocalUser
    {
        public int id_user { get; set; }
        public string username { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string descripcion { get; set; }
        public string pass { get; set; }
        public Nullable<bool> isVendor { get; set; }
        public Nullable<int> puntaje { get; set; }
        public string email { get; set; }
        public bool RememberMe { get; set; }
    }
}
