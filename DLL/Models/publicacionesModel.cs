//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrotApi0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class publicacionesModel
    {
        [Key]
        public int id_post { get; set; }
        public int id_user { get; set; }
        [StringLength(100)]
        public string img { get; set; }
        public bool? isImg { get; set; }
        [StringLength(300)]
        public string descripcion { get; set; }
        public DateTime? fecha_creacion { get; set; }
        public DateTime? fecha_actualizacion { get; set; }

    }
}
