using Brot.Models;
using Microsoft.EntityFrameworkCore;

namespace Brot.DataContext
{
    public class DataContext : DbContext
    {
        public DbSet<Categoria>? Categoria { get; set; }
        public DbSet<Comentario>? Comentarios { get; set; }
        public DbSet<Interaccion_post>? Interaccion_post { get; set; }
        public DbSet<Like_comentario>? Like_comentario { get; set; }
        public DbSet<Like_post>? Like_post { get; set; }
        public DbSet<Publicacion_guardada>? Publicacion_guardada { get; set; }
        public DbSet<Publicacion>? Publicaciones { get; set; }
        public DbSet<Seguido>? Seguidores { get; set; }
        public DbSet<Usuario>? Users { get; set; }
        public DbSet<Visita_perfil>? Visita_busqueda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1,1433; Database=BrotDevelopment; User=SA; Password=Password12*;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Comentario>(comentario =>
            //{
            //    comentario
            //        .HasOne(c => c.Publicacion)
            //        .WithMany(publicacion => publicacion.Comentarios)
            //        .HasForeignKey(comentario => comentario.id_post)
            //        .OnDelete(DeleteBehavior.Restrict);
            //    comentario
            //        .HasOne(c => c.Usuario)
            //        .WithMany(Usuario => Usuario.comentarios)
            //        .HasForeignKey(comentario => comentario.id_user)
            //        .OnDelete(DeleteBehavior.Restrict);
            //});

            //modelBuilder.Entity<Interaccion_post>(interaccion =>
            //{
            //    interaccion
            //        .HasOne(interaccion => interaccion.Publicacion)
            //        .WithMany(publicacion => publicacion.interaccion_post)
            //        .HasForeignKey(interaccion => interaccion.id_post)
            //        .OnDelete(DeleteBehavior.Restrict);
            //    interaccion
            //        .HasOne(interaccion => interaccion.UsuarioInteraccion)
            //        .WithMany(UsuarioInteraccion => UsuarioInteraccion.interaccion_post)
            //        .HasForeignKey(interaccion => interaccion.id_user)
            //        .OnDelete(DeleteBehavior.Restrict);
            //});

            //modelBuilder.Entity<Like_comentario>(Like_comentario =>
            //{
            //    Like_comentario
            //        .HasOne(Like_comentario => Like_comentario.Comentario)
            //        .WithMany(Comentario => Comentario.like_comentario)
            //        .HasForeignKey(Like_comentario => Like_comentario.id_comentario)
            //        .OnDelete(DeleteBehavior.Restrict);

            //    Like_comentario
            //        .HasOne(Like_comentario => Like_comentario.Usuario)
            //        .WithMany(Usuario => Usuario.like_comentario)
            //        .HasForeignKey(Like_comentario => Like_comentario.id_user)
            //        .OnDelete(DeleteBehavior.Restrict);

            //});

            //modelBuilder.Entity<Like_post>(Like_post =>
            //{
            //    Like_post
            //        .HasOne(Like_post => Like_post.Publicacion)
            //        .WithMany(Publicacion => Publicacion.Likes_post)
            //        .HasForeignKey(Like_post => Like_post.id_post)
            //        .OnDelete(DeleteBehavior.Restrict);

            //    Like_post
            //        .HasOne(Like_post => Like_post.Usuario)
            //        .WithMany(Usuario => Usuario.like_post)
            //        .HasForeignKey(Like_post => Like_post.id_user)
            //        .OnDelete(DeleteBehavior.Restrict);

            //});

            //modelBuilder.Entity<Publicacion>(Publicacion =>
            //{
            //    Publicacion
            //        .HasOne(Publicacion => Publicacion.Usuario)
            //        .WithMany(Usuario => Usuario.publicaciones)
            //        .HasForeignKey(Publicacion => Publicacion.id_user)
            //        .OnDelete(DeleteBehavior.Restrict);
            //});

            //modelBuilder.Entity<Publicacion_guardada>(publicacionGuardada =>
            //{
            //    publicacionGuardada
            //        .HasOne(publicacionGuardada => publicacionGuardada.Usuario)
            //        .WithMany(Usuario => Usuario.publicacion_guardada)
            //        .HasForeignKey(publicacionGuardada => publicacionGuardada.id_user)
            //        .OnDelete(DeleteBehavior.Restrict);

            //    publicacionGuardada
            //        .HasOne(publicacionGuardada => publicacionGuardada.Publicacion)
            //        .WithMany(Publicacion => Publicacion.Publicacion_Guardadas)
            //        .HasForeignKey(publicacionGuardada => publicacionGuardada.id_publicacion_guardada)
            //        .OnDelete(DeleteBehavior.Restrict);
            //});




            /////TODO: Medium - ForeignKey usando EF no han sido creadas para Visitas ni Seguidores


            ////modelBuilder.Entity<Visita_perfil>(visitaBusqueda =>
            ////{
            ////    visitaBusqueda
            ////        .HasOne(visita => visita.UsuarioVisitado)
            ////        .WithMany(usuario => usuario.visita_busquedaQueYoHice)
            ////        .HasForeignKey(visita => visita.id_userVisitado);

            ////    visitaBusqueda
            ////        .HasOne(visita => visita.UsuarioQueEntro)
            ////        .WithMany(usuario => usuario.visita_busquedaAmiPerfil)
            ////        .HasForeignKey(visita => visita.id_userQueEntro);
            ////});

            //modelBuilder.Entity<Usuario>(user =>
            //{
            //    user
            //        .HasOne(user => user.categoria)
            //        .WithMany(cate => cate.Usuarios)
            //        .HasForeignKey(user => user.id_categoria)
            //        .OnDelete(DeleteBehavior.Restrict);
            //    //user
            //    //    .HasMany(user => user.seguidores)
            //    //    .WithOne(seguidor => seguidor.UsuarioSeguido)
            //    //    .HasForeignKey(x => x.Id_PersonaQueSigue);
            //    //user
            //    //    .HasMany(user => user.seguidos)
            //    //    .WithOne(seguidor => seguidor.UsuarioQueSigue)
            //    //    .HasForeignKey(x => x.Id_PersonaSeguida);

            //});

            ////modelBuilder.Entity<Seguido>(seguidor =>
            ////{
            ////    seguidor
            ////        .HasOne(seguidor => seguidor.UsuarioQueSigue)
            ////        .WithMany(Usuario => Usuario.seguidos)
            ////        .HasForeignKey(seguidor => seguidor.Id_PersonaQueSigue)
            ////        .OnDelete(DeleteBehavior.Restrict);

            ////    seguidor
            ////        .HasOne(seguidor => seguidor.UsuarioSeguido)
            ////        .WithMany(Usuario => Usuario.seguidores)
            ////        .HasForeignKey(seguidor => seguidor.Id_PersonaSeguida)
            ////        .OnDelete(DeleteBehavior.Restrict);
            ////});


        }

    }
}