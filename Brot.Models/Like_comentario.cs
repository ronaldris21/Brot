namespace Brot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Like_comentario
    {
        [Key]
        public int id_like_comentario { get; set; }
    
        public int id_user { get; set; }
        public int id_comentario { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    
        public virtual Comentario Comentario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
