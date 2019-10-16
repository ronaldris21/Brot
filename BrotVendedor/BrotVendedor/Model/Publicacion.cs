using System;
using System.Collections.Generic;
using System.Text;

namespace BrotVendedor.Model
{
    public class Publicacion
    {
        public int id_post { get; set; }
        public int id_user { get; set; }
        public string img { get; set; }
        public Nullable<bool> isImg { get; set; }
        public string descripcion { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public Nullable<System.DateTime> fecha_actualizacion { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public virtual Usuario users { get; set; }
    }
}
