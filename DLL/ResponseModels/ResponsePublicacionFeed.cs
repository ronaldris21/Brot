

namespace DLL.ResponseModels
{
    using BrotApi0.Models;
    using System;
    using System.Collections.Generic;
    public class ResponsePublicacionFeed
    {
        public int id_post { get; set; }
        public Nullable<int> id_user { get; set; }
        public string img { get; set; }
        public bool? isimg { get;set; }
        public string descripcion { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public Nullable<System.DateTime> fecha_actualizacion { get; set; }

        public userModel UsuarioCreator { get; set; }
        public int cantComentarios { get; set; }
        public int cantLikes { get; set; }
    }
}
