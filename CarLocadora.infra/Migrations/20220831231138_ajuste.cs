using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarLocadora.infra.Migrations
{
    public partial class ajuste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocacaoVeiculos_Categoria_CategoriaId",
                table: "LocacaoVeiculos");

            migrationBuilder.DropIndex(
                name: "IX_LocacaoVeiculos_CategoriaId",
                table: "LocacaoVeiculos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "LocacaoVeiculos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "LocacaoVeiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoVeiculos_CategoriaId",
                table: "LocacaoVeiculos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_LocacaoVeiculos_Categoria_CategoriaId",
                table: "LocacaoVeiculos",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
