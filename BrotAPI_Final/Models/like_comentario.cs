//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrotAPI_Final.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class like_comentario
    {
        public int id_like_comentario { get; set; }
        public int id_user { get; set; }
        public int id_comentario { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
    
        public virtual comentarios comentarios { get; set; }
        public virtual users users { get; set; }
    }
}
