namespace Brot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Seguido
    {
        [Key]
        public int Id_seguidor { get; set; }
        public Nullable<bool> accepted { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }

        public int Id_PersonaQueSigue{ get; set; }
        public int Id_PersonaSeguida { get; set; }
        [NotMapped]
        public virtual Usuario UsuarioQueSigue { get; set; }
        [NotMapped]
        public virtual Usuario UsuarioSeguido { get; set; }
    }
}
