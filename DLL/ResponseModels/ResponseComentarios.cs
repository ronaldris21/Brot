using BrotApi0.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.ResponseModels
{
    public class ResponseComentarios
    {
        public int id_comentario { get; set; }
        public bool IsLiked { get; set; }
        public string contenido { get; set; }
        public DateTime? fecha_creacion { get; set; }
        public string img { get; set; }
        public string username { get; set; }
        public bool? isVendor { get; set; }

    }
}
