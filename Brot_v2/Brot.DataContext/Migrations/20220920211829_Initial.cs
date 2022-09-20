using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Brot.DataContext.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.id_categoria);
                });

            migrationBuilder.CreateTable(
                name: "Seguidores",
                columns: table => new
                {
                    Id_seguidor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accepted = table.Column<bool>(type: "bit", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Id_PersonaQueSigue = table.Column<int>(type: "int", nullable: false),
                    Id_PersonaSeguida = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguidores", x => x.Id_seguidor);
                });

            migrationBuilder.CreateTable(
                name: "Visita_busqueda",
                columns: table => new
                {
                    id_visita_perfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_userQueEntro = table.Column<int>(type: "int", nullable: false),
                    id_userVisitado = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visita_busqueda", x => x.id_visita_perfil);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    puesto_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isVendor = table.Column<bool>(type: "bit", nullable: false),
                    puntaje = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    xlat = table.Column<float>(type: "real", nullable: true),
                    ylon = table.Column<float>(type: "real", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    dui = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    num_telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Device_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_OS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_categoria = table.Column<int>(type: "int", nullable: true),
                    categoriaid_categoria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id_user);
                    table.ForeignKey(
                        name: "FK_Users_Categoria_categoriaid_categoria",
                        column: x => x.categoriaid_categoria,
                        principalTable: "Categoria",
                        principalColumn: "id_categoria");
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    id_post = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isImg = table.Column<bool>(type: "bit", nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fecha_actualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CantVisitasPublicacion = table.Column<int>(type: "int", nullable: false),
                    Usuarioid_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.id_post);
                    table.ForeignKey(
                        name: "FK_Publicaciones_Users_Usuarioid_user",
                        column: x => x.Usuarioid_user,
                        principalTable: "Users",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    id_comentario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_post = table.Column<int>(type: "int", nullable: false),
                    contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    Publicacionid_post = table.Column<int>(type: "int", nullable: true),
                    Usuarioid_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.id_comentario);
                    table.ForeignKey(
                        name: "FK_Comentarios_Publicaciones_Publicacionid_post",
                        column: x => x.Publicacionid_post,
                        principalTable: "Publicaciones",
                        principalColumn: "id_post");
                    table.ForeignKey(
                        name: "FK_Comentarios_Users_Usuarioid_user",
                        column: x => x.Usuarioid_user,
                        principalTable: "Users",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "Interaccion_post",
                columns: table => new
                {
                    id_interaccion_post = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_post = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Publicacionid_post = table.Column<int>(type: "int", nullable: true),
                    UsuarioInteraccionid_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interaccion_post", x => x.id_interaccion_post);
                    table.ForeignKey(
                        name: "FK_Interaccion_post_Publicaciones_Publicacionid_post",
                        column: x => x.Publicacionid_post,
                        principalTable: "Publicaciones",
                        principalColumn: "id_post");
                    table.ForeignKey(
                        name: "FK_Interaccion_post_Users_UsuarioInteraccionid_user",
                        column: x => x.UsuarioInteraccionid_user,
                        principalTable: "Users",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "Like_post",
                columns: table => new
                {
                    id_like_post = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_post = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Publicacionid_post = table.Column<int>(type: "int", nullable: true),
                    Usuarioid_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like_post", x => x.id_like_post);
                    table.ForeignKey(
                        name: "FK_Like_post_Publicaciones_Publicacionid_post",
                        column: x => x.Publicacionid_post,
                        principalTable: "Publicaciones",
                        principalColumn: "id_post");
                    table.ForeignKey(
                        name: "FK_Like_post_Users_Usuarioid_user",
                        column: x => x.Usuarioid_user,
                        principalTable: "Users",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "Publicacion_guardada",
                columns: table => new
                {
                    id_publicacion_guardada = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_post = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Publicacionid_post = table.Column<int>(type: "int", nullable: true),
                    Usuarioid_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicacion_guardada", x => x.id_publicacion_guardada);
                    table.ForeignKey(
                        name: "FK_Publicacion_guardada_Publicaciones_Publicacionid_post",
                        column: x => x.Publicacionid_post,
                        principalTable: "Publicaciones",
                        principalColumn: "id_post");
                    table.ForeignKey(
                        name: "FK_Publicacion_guardada_Users_Usuarioid_user",
                        column: x => x.Usuarioid_user,
                        principalTable: "Users",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "Like_comentario",
                columns: table => new
                {
                    id_like_comentario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_comentario = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comentarioid_comentario = table.Column<int>(type: "int", nullable: true),
                    Usuarioid_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like_comentario", x => x.id_like_comentario);
                    table.ForeignKey(
                        name: "FK_Like_comentario_Comentarios_Comentarioid_comentario",
                        column: x => x.Comentarioid_comentario,
                        principalTable: "Comentarios",
                        principalColumn: "id_comentario");
                    table.ForeignKey(
                        name: "FK_Like_comentario_Users_Usuarioid_user",
                        column: x => x.Usuarioid_user,
                        principalTable: "Users",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_Publicacionid_post",
                table: "Comentarios",
                column: "Publicacionid_post");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_Usuarioid_user",
                table: "Comentarios",
                column: "Usuarioid_user");

            migrationBuilder.CreateIndex(
                name: "IX_Interaccion_post_Publicacionid_post",
                table: "Interaccion_post",
                column: "Publicacionid_post");

            migrationBuilder.CreateIndex(
                name: "IX_Interaccion_post_UsuarioInteraccionid_user",
                table: "Interaccion_post",
                column: "UsuarioInteraccionid_user");

            migrationBuilder.CreateIndex(
                name: "IX_Like_comentario_Comentarioid_comentario",
                table: "Like_comentario",
                column: "Comentarioid_comentario");

            migrationBuilder.CreateIndex(
                name: "IX_Like_comentario_Usuarioid_user",
                table: "Like_comentario",
                column: "Usuarioid_user");

            migrationBuilder.CreateIndex(
                name: "IX_Like_post_Publicacionid_post",
                table: "Like_post",
                column: "Publicacionid_post");

            migrationBuilder.CreateIndex(
                name: "IX_Like_post_Usuarioid_user",
                table: "Like_post",
                column: "Usuarioid_user");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_guardada_Publicacionid_post",
                table: "Publicacion_guardada",
                column: "Publicacionid_post");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_guardada_Usuarioid_user",
                table: "Publicacion_guardada",
                column: "Usuarioid_user");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_Usuarioid_user",
                table: "Publicaciones",
                column: "Usuarioid_user");

            migrationBuilder.CreateIndex(
                name: "IX_Users_categoriaid_categoria",
                table: "Users",
                column: "categoriaid_categoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interaccion_post");

            migrationBuilder.DropTable(
                name: "Like_comentario");

            migrationBuilder.DropTable(
                name: "Like_post");

            migrationBuilder.DropTable(
                name: "Publicacion_guardada");

            migrationBuilder.DropTable(
                name: "Seguidores");

            migrationBuilder.DropTable(
                name: "Visita_busqueda");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
