using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.DataBase.Migrations
{
    public partial class segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sinopsis",
                table: "libros",
                newName: "Sinopsis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sinopsis",
                table: "libros",
                newName: "sinopsis");
        }
    }
}
