using Microsoft.EntityFrameworkCore.Migrations;

namespace CBVinil.Persistence.Migrations
{
    public partial class Quarta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "GeneroMusical");

            migrationBuilder.AddColumn<string>(
                name: "ArgSpotify",
                table: "GeneroMusical",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArgSpotify",
                table: "GeneroMusical");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "GeneroMusical",
                maxLength: 32,
                nullable: true);
        }
    }
}
