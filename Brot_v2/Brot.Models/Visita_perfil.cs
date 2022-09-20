namespace Brot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //TODO: low - Que no cuenten las visitas a si mismo
    public partial class Visita_perfil
    {
        [Key]
        public int id_visita_perfil { get; set; }
        public int id_userQueEntro { get; set; }
        public int id_userVisitado { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        [NotMapped]
        public virtual Usuario UsuarioQueEntro { get; set; }
        [NotMapped]
        public virtual Usuario UsuarioVisitado { get; set; }
    }
}
