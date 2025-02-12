using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api_Antivirus.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instituciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Ubicacion = table.Column<string>(type: "text", nullable: false),
                    UrlGeneralidades = table.Column<string>(type: "text", nullable: false),
                    UrlOfertaAcademica = table.Column<string>(type: "text", nullable: false),
                    UrlBienestar = table.Column<string>(type: "text", nullable: false),
                    UrlAdmision = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tematicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tematicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    Contrasena = table.Column<string>(type: "text", nullable: false),
                    Rol = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bootcamps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Informacion = table.Column<string>(type: "text", nullable: false),
                    Costos = table.Column<string>(type: "text", nullable: false),
                    InstitucionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bootcamps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bootcamps_Instituciones_InstitucionId",
                        column: x => x.InstitucionId,
                        principalTable: "Instituciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Oportunidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Observaciones = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Requisitos = table.Column<string>(type: "text", nullable: false),
                    Guia = table.Column<string>(type: "text", nullable: false),
                    DatosAdicionales = table.Column<string>(type: "text", nullable: false),
                    CanalesAtencion = table.Column<string>(type: "text", nullable: false),
                    Encargado = table.Column<string>(type: "text", nullable: false),
                    Modalidad = table.Column<string>(type: "text", nullable: false),
                    CategoriaId = table.Column<int>(type: "integer", nullable: true),
                    InstitucionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oportunidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oportunidades_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Oportunidades_Instituciones_InstitucionId",
                        column: x => x.InstitucionId,
                        principalTable: "Instituciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BootcampTematicas",
                columns: table => new
                {
                    IdBootcamp = table.Column<int>(type: "integer", nullable: false),
                    IdTematica = table.Column<int>(type: "integer", nullable: false),
                    BootcampId = table.Column<int>(type: "integer", nullable: false),
                    TematicaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BootcampTematicas", x => new { x.IdBootcamp, x.IdTematica });
                    table.ForeignKey(
                        name: "FK_BootcampTematicas_Bootcamps_BootcampId",
                        column: x => x.BootcampId,
                        principalTable: "Bootcamps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BootcampTematicas_Tematicas_TematicaId",
                        column: x => x.TematicaId,
                        principalTable: "Tematicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstitucionBootcamps",
                columns: table => new
                {
                    IdInstitucion = table.Column<int>(type: "integer", nullable: false),
                    IdBootcamp = table.Column<int>(type: "integer", nullable: false),
                    InstitucionId = table.Column<int>(type: "integer", nullable: false),
                    BootcampId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitucionBootcamps", x => new { x.IdInstitucion, x.IdBootcamp });
                    table.ForeignKey(
                        name: "FK_InstitucionBootcamps_Bootcamps_BootcampId",
                        column: x => x.BootcampId,
                        principalTable: "Bootcamps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstitucionBootcamps_Instituciones_InstitucionId",
                        column: x => x.InstitucionId,
                        principalTable: "Instituciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OportunidadInstitucion",
                columns: table => new
                {
                    IdOportunidad = table.Column<int>(type: "integer", nullable: false),
                    IdInstitucion = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    OportunidadId = table.Column<int>(type: "integer", nullable: false),
                    InstitucionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OportunidadInstitucion", x => new { x.IdOportunidad, x.IdInstitucion });
                    table.ForeignKey(
                        name: "FK_OportunidadInstitucion_Instituciones_InstitucionId",
                        column: x => x.InstitucionId,
                        principalTable: "Instituciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OportunidadInstitucion_Oportunidades_OportunidadId",
                        column: x => x.OportunidadId,
                        principalTable: "Oportunidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioOportunidades",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "integer", nullable: false),
                    IdOportunidad = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    OportunidadId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioOportunidades", x => new { x.IdUsuario, x.IdOportunidad });
                    table.ForeignKey(
                        name: "FK_UsuarioOportunidades_Oportunidades_OportunidadId",
                        column: x => x.OportunidadId,
                        principalTable: "Oportunidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioOportunidades_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bootcamps_InstitucionId",
                table: "Bootcamps",
                column: "InstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_BootcampTematicas_BootcampId",
                table: "BootcampTematicas",
                column: "BootcampId");

            migrationBuilder.CreateIndex(
                name: "IX_BootcampTematicas_TematicaId",
                table: "BootcampTematicas",
                column: "TematicaId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitucionBootcamps_BootcampId",
                table: "InstitucionBootcamps",
                column: "BootcampId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitucionBootcamps_InstitucionId",
                table: "InstitucionBootcamps",
                column: "InstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_Oportunidades_CategoriaId",
                table: "Oportunidades",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Oportunidades_InstitucionId",
                table: "Oportunidades",
                column: "InstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_OportunidadInstitucion_InstitucionId",
                table: "OportunidadInstitucion",
                column: "InstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_OportunidadInstitucion_OportunidadId",
                table: "OportunidadInstitucion",
                column: "OportunidadId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioOportunidades_OportunidadId",
                table: "UsuarioOportunidades",
                column: "OportunidadId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioOportunidades_UsuarioId",
                table: "UsuarioOportunidades",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BootcampTematicas");

            migrationBuilder.DropTable(
                name: "InstitucionBootcamps");

            migrationBuilder.DropTable(
                name: "OportunidadInstitucion");

            migrationBuilder.DropTable(
                name: "UsuarioOportunidades");

            migrationBuilder.DropTable(
                name: "Tematicas");

            migrationBuilder.DropTable(
                name: "Bootcamps");

            migrationBuilder.DropTable(
                name: "Oportunidades");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Instituciones");
        }
    }
}
