using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarLocadora.infra.Migrations
{
    public partial class Categoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Veiculo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_CategoriaId",
                table: "Veiculo",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_Categoria_CategoriaId",
                table: "Veiculo",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Categoria_CategoriaId",
                table: "Veiculo");

            migrationBuilder.DropIndex(
                name: "IX_Veiculo_CategoriaId",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Veiculo");
        }
    }
}
