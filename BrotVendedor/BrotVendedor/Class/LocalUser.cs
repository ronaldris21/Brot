using BrotApi0.Models;
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
        public bool? isVendor { get; set; }
        public int? puntaje { get; set; }
        public string email { get; set; }
        public float? xlat { get; set; }
        public float? ylon { get; set; }
        public short? isActive { get; set; }
        public string dui { get; set; }
        public string num_telefono { get; set; }
        public bool RememberMe { get; set; }
    }
}
