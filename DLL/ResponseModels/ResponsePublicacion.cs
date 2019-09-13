

namespace DLL.ResponseModels
{
    using BrotApi0.Models;
    using System.Collections.Generic;
    public class ResponsePublicacion
    {
        public bool IsLiked { get; set; }
        public publicacionesModel publicacion { get; set; }
        public List<ResponseComentarios> comentarios { get; set; }//15
        public userModel userCreator { get; set; }
    }
}
