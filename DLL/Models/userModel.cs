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

    public partial class userModel
    {
        [Key]
        public int id_user { get; set; }
        [Required]
        [StringLength(20)]
        public string username { get; set; }
        [StringLength(50)]
        public string nombre { get; set; }
        [StringLength(50)]
        public string apellido { get; set; }
        [StringLength(200)]
        public string descripcion { get; set; }
        [StringLength(20)]
        public string pass { get; set; }
        public bool? isVendor { get; set; }
        public int? puntaje { get; set; }
        [StringLength(100)]
        public string email { get; set; }
        public float? xlat { get; set; }
        public float? ylon { get; set; }
        public short? isActive { get; set; }
        [StringLength(15)]
        public string dui { get; set; }
        [StringLength(15)]
        public string num_telefono { get; set; }

    }
}