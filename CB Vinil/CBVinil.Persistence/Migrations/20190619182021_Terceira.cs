using Microsoft.EntityFrameworkCore.Migrations;

namespace CBVinil.Persistence.Migrations
{
    public partial class Terceira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Artistas",
                table: "Disco",
                maxLength: 512,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodSpotify",
                table: "Disco",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artistas",
                table: "Disco");

            migrationBuilder.DropColumn(
                name: "CodSpotify",
                table: "Disco");
        }
    }
}
