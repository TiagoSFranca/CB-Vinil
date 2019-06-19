using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CBVinil.Persistence.Migrations
{
    public partial class Segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    IdVenda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ValorTotal = table.Column<decimal>(nullable: false),
                    ValorEfetivo = table.Column<decimal>(nullable: false),
                    ValorCashback = table.Column<decimal>(nullable: false),
                    DataVenda = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.IdVenda);
                });

            migrationBuilder.CreateTable(
                name: "ItemVenda",
                columns: table => new
                {
                    IdItemVenda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdDisco = table.Column<int>(nullable: false),
                    IdVenda = table.Column<int>(nullable: false),
                    PrecoUnitario = table.Column<decimal>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    PercentualCashback = table.Column<decimal>(nullable: false),
                    ValorTotal = table.Column<decimal>(nullable: false),
                    ValorEfetivo = table.Column<decimal>(nullable: false),
                    ValorCashback = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVenda", x => x.IdItemVenda);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Disco_IdDisco",
                        column: x => x.IdDisco,
                        principalTable: "Disco",
                        principalColumn: "IdDisco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemVenda_Venda_IdVenda",
                        column: x => x.IdVenda,
                        principalTable: "Venda",
                        principalColumn: "IdVenda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_IdDisco",
                table: "ItemVenda",
                column: "IdDisco");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVenda_IdVenda",
                table: "ItemVenda",
                column: "IdVenda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemVenda");

            migrationBuilder.DropTable(
                name: "Venda");
        }
    }
}
