using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarLocadora.infra.Migrations
{
    public partial class ajustetabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocacaoVeiculos_Veiculo_VeiculoPlaca",
                table: "LocacaoVeiculos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Usuario",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "VeiculoPlaca",
                table: "LocacaoVeiculos",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AddForeignKey(
                name: "FK_LocacaoVeiculos_Veiculo_VeiculoPlaca",
                table: "LocacaoVeiculos",
                column: "VeiculoPlaca",
                principalTable: "Veiculo",
                principalColumn: "Placa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocacaoVeiculos_Veiculo_VeiculoPlaca",
                table: "LocacaoVeiculos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAlteracao",
                table: "Usuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VeiculoPlaca",
                table: "LocacaoVeiculos",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LocacaoVeiculos_Veiculo_VeiculoPlaca",
                table: "LocacaoVeiculos",
                column: "VeiculoPlaca",
                principalTable: "Veiculo",
                principalColumn: "Placa",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
