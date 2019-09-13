using BrotApi0.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.ResponseModels
{
    public class ResponseUserProfile
    {
        public userModel user { get; set; }
        public int cantSeguidores { get; set; }
        public ResponsePublicacionFeed publicacionesUser {get;set;}

    }
}
