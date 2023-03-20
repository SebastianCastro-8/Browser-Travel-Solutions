using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.DataBase.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "editoriales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sede = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_editoriales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "libros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isbn = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sinopsis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paginas = table.Column<int>(type: "int", nullable: false),
                    IdEditorial = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "autores_has_libros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAutor = table.Column<int>(type: "int", nullable: false),
                    IsbnLibro = table.Column<int>(type: "int", nullable: false),
                    LibroId = table.Column<int>(type: "int", nullable: true),
                    AutorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_autores_has_libros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_autores_has_libros_autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_autores_has_libros_libros_LibroId",
                        column: x => x.LibroId,
                        principalTable: "libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_autores_has_libros_AutorId",
                table: "autores_has_libros",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_autores_has_libros_LibroId",
                table: "autores_has_libros",
                column: "LibroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "autores_has_libros");

            migrationBuilder.DropTable(
                name: "editoriales");

            migrationBuilder.DropTable(
                name: "autores");

            migrationBuilder.DropTable(
                name: "libros");
        }
    }
}
