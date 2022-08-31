using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarLocadora.infra.Migrations
{
    public partial class Ajustes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocacaoVeiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteCPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    FormaPagamentoId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    DataHoraReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraRetiradaPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataHoraDevolucaoPrevista = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VeiculoPlaca = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocacaoVeiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocacaoVeiculos_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocacaoVeiculos_Cliente_ClienteCPF",
                        column: x => x.ClienteCPF,
                        principalTable: "Cliente",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocacaoVeiculos_FormaPagamento_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormaPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocacaoVeiculos_Veiculo_VeiculoPlaca",
                        column: x => x.VeiculoPlaca,
                        principalTable: "Veiculo",
                        principalColumn: "Placa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vistoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocacaoId = table.Column<int>(type: "int", nullable: false),
                    KmSaida = table.Column<long>(type: "bigint", nullable: false),
                    CombustivelSaida = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ObservacaoSaida = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DataHoraRetiradaPatio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KmEntrada = table.Column<long>(type: "bigint", nullable: true),
                    CombustivelEntrada = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ObservacaoEntrada = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DataHoraDevolucaoPatio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vistoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vistoria_LocacaoVeiculos_LocacaoId",
                        column: x => x.LocacaoId,
                        principalTable: "LocacaoVeiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoVeiculos_CategoriaId",
                table: "LocacaoVeiculos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoVeiculos_ClienteCPF",
                table: "LocacaoVeiculos",
                column: "ClienteCPF");

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoVeiculos_FormaPagamentoId",
                table: "LocacaoVeiculos",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoVeiculos_VeiculoPlaca",
                table: "LocacaoVeiculos",
                column: "VeiculoPlaca");

            migrationBuilder.CreateIndex(
                name: "IX_Vistoria_LocacaoId",
                table: "Vistoria",
                column: "LocacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vistoria");

            migrationBuilder.DropTable(
                name: "LocacaoVeiculos");
        }
    }
}
