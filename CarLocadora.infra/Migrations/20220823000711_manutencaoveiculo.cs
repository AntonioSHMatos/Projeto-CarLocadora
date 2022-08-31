using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarLocadora.infra.Migrations
{
    public partial class manutencaoveiculo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManutencaoVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DataServico = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Garantia = table.Column<int>(type: "int", nullable: false),
                    ValorServico = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VeiculoPlaca = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManutencaoVeiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManutencaoVeiculos_Veiculo_VeiculoPlaca",
                        column: x => x.VeiculoPlaca,
                        principalTable: "Veiculo",
                        principalColumn: "Placa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManutencaoVeiculos_VeiculoPlaca",
                table: "ManutencaoVeiculos",
                column: "VeiculoPlaca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManutencaoVeiculos");
        }
    }
}
