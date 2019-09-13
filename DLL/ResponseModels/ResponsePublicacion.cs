

namespace DLL.ResponseModels
{
    using BrotApi0.Models;
    using System.Collections.Generic;
    public class ResponsePublicacion
    {
        public ResponsePublicacionFeed publicacion { get; set; }
        public List<ResponseComentarios> comentarios { get; set; }
        public List<userModel> likes { get; set; }
    }
}
