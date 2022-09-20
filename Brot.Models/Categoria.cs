namespace Brot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Categoria
    {
        public Categoria()
        {
            this.Usuarios = new HashSet<Usuario>();
        }
        [Key]
        public int id_categoria { get; set; }
        public string nombre { get; set; }
        public string img { get; set; }


        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
