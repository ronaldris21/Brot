namespace Brot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Comentario
    {
        public Comentario()
        {
            this.like_comentario = new HashSet<Like_comentario>();
        }
        [Key]
        public int id_comentario { get; set; }
        public int id_user { get; set; }
        public int id_post { get; set; }
        public string contenido { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
        public Nullable<bool> isDeleted { get; set; }
    


        public virtual Publicacion Publicacion { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Like_comentario> like_comentario { get; set; }
    }
}
