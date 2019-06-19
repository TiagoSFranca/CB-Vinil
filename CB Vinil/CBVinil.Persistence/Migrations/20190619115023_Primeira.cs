using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBVinil.Persistence.Migrations
{
    public partial class Primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaSemana",
                columns: table => new
                {
                    IdDiaSemana = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 32, nullable: false),
                    DiaDaSemana = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaSemana", x => x.IdDiaSemana);
                });

            migrationBuilder.CreateTable(
                name: "GeneroMusical",
                columns: table => new
                {
                    IdGeneroMusical = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 32, nullable: false),
                    Descricao = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroMusical", x => x.IdGeneroMusical);
                });

            migrationBuilder.CreateTable(
                name: "CashbackParametro",
                columns: table => new
                {
                    IdCaskbackParametro = table.Column<int>(nullable: false),
                    IdGeneroMusical = table.Column<int>(nullable: false),
                    IdDiaSemana = table.Column<int>(nullable: false),
                    Percentual = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashbackParametro", x => x.IdCaskbackParametro);
                    table.ForeignKey(
                        name: "FK_CashbackParametro_DiaSemana_IdDiaSemana",
                        column: x => x.IdDiaSemana,
                        principalTable: "DiaSemana",
                        principalColumn: "IdDiaSemana",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashbackParametro_GeneroMusical_IdGeneroMusical",
                        column: x => x.IdGeneroMusical,
                        principalTable: "GeneroMusical",
                        principalColumn: "IdGeneroMusical",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disco",
                columns: table => new
                {
                    IdDisco = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdGeneroMusical = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 128, nullable: false),
                    Preco = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disco", x => x.IdDisco);
                    table.ForeignKey(
                        name: "FK_Disco_GeneroMusical_IdGeneroMusical",
                        column: x => x.IdGeneroMusical,
                        principalTable: "GeneroMusical",
                        principalColumn: "IdGeneroMusical",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashbackParametro_IdDiaSemana",
                table: "CashbackParametro",
                column: "IdDiaSemana");

            migrationBuilder.CreateIndex(
                name: "IX_CashbackParametro_IdGeneroMusical",
                table: "CashbackParametro",
                column: "IdGeneroMusical");

            migrationBuilder.CreateIndex(
                name: "IX_Disco_IdGeneroMusical",
                table: "Disco",
                column: "IdGeneroMusical");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashbackParametro");

            migrationBuilder.DropTable(
                name: "Disco");

            migrationBuilder.DropTable(
                name: "DiaSemana");

            migrationBuilder.DropTable(
                name: "GeneroMusical");
        }
    }
}
