namespace Brot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Publicacion_guardada
    {
        [Key]
        public int id_publicacion_guardada { get; set; }
        public int id_user { get; set; }
        public int id_post { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
    
        public virtual Publicacion Publicacion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
