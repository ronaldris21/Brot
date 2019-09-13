using BrotApi0.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.ResponseModels
{
    class ResponsePerfil
    {
        public userModel usuario { get; set; }
        public List<ResponsePublicacionFeed> publicacionesPropias { get; set; }
        public List<ResponsePublicacionFeed> publicacionesGuardadas { get; set; }
        public int cantSeguidores { get; set; }
        public int cantSeguidos { get; set; }

    }
}
