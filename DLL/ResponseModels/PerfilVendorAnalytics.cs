using System;
using System.Collections.Generic;
using System.Text;

namespace DLL.ResponseModels
{
    public class PerfilVendorAnalytics
    {
		//No usar Aanalytics aun
        public int cantVistas { get; set; }
        public int cantLikes { get; set; }
        public int CantBusquedasPerfil { get; set; }
        public int CantSeguidoresNuevos7Dias { get; set; }
        //Lista de las analitycis por post!!

        public int cantComentario { get; set; }

    }
}
