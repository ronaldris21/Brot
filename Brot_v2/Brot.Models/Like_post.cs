namespace Brot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Like_post
    {
        [Key]
        public int id_like_post { get; set; }
        public int id_user { get; set; }
        public int id_post { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
    
        public virtual Publicacion Publicacion { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
