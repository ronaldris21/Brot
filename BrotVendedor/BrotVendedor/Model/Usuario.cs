using System;
using System.Collections.Generic;
using System.Text;

namespace BrotVendedor.Model
{
    public class Usuario
    {
        public int id_user { get; set; }
        public string username { get; set; }
        public string puesto_name { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string descripcion { get; set; }
        public string pass { get; set; }
        public bool isVendor { get; set; }
        public int puntaje { get; set; }
        public string email { get; set; }
        public double xlat { get; set; }
        public double ylon { get; set; }
        public bool isActive { get; set; }
        public string dui { get; set; }
        public string num_telefono { get; set; }
        public string img { get; set; }
        public bool isDeleted { get; set; }
        public bool RememberMe { get; set; }
    }
}
