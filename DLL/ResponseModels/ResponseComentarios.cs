using BrotApi0.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.ResponseModels
{
    public class ResponseComentarios
    {
        public comentariosModel comentario { get; set; }
        public userModel usuario { get; set; }
    }
}
