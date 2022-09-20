namespace Brot.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Usuario
    {
        public Usuario()
        {
            this.comentarios = new HashSet<Comentario>();
            this.interaccion_post = new HashSet<Interaccion_post>();
            this.like_comentario = new HashSet<Like_comentario>();
            this.like_post = new HashSet<Like_post>();
            this.publicacion_guardada = new HashSet<Publicacion_guardada>();
            this.publicaciones = new HashSet<Publicacion>();
            this.seguidos = new HashSet<Seguido>();
            this.seguidores = new HashSet<Seguido>();
            this.visita_busquedaAmiPerfil = new HashSet<Visita_perfil>();
            this.visita_busquedaQueYoHice = new HashSet<Visita_perfil>();
        }
        [Key]
        public int id_user { get; set; }
        public string username { get; set; }
        public string puesto_name { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string descripcion { get; set; }
        public string pass { get; set; }
        public bool isVendor { get; set; }
        public Nullable<int> puntaje { get; set; }
        public string email { get; set; }
        public Nullable<float> xlat { get; set; }
        public Nullable<float> ylon { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string dui { get; set; }
        public string num_telefono { get; set; }
        public string img { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public string Device_id { get; set; }
        public string Phone_OS { get; set; }
        public Nullable<int> id_categoria { get; set; }
        public Categoria categoria { get; set; }
        public virtual ICollection<Comentario> comentarios { get; set; }
        public virtual ICollection<Interaccion_post> interaccion_post { get; set; }
        public virtual ICollection<Like_comentario> like_comentario { get; set; }
        public virtual ICollection<Like_post> like_post { get; set; }
        public virtual ICollection<Publicacion_guardada> publicacion_guardada { get; set; }
        public virtual ICollection<Publicacion> publicaciones { get; set; }
        [NotMapped]
        public virtual ICollection<Visita_perfil> visita_busquedaAmiPerfil { get; set; }
        [NotMapped]
        public virtual ICollection<Visita_perfil> visita_busquedaQueYoHice { get; set; }
        [NotMapped]
        public virtual ICollection<Seguido> seguidos { get; set; }
        [NotMapped]
        public virtual ICollection<Seguido> seguidores { get; set; }
    }
}
