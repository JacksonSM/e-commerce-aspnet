using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspStore.Infra.Data.Migrations
{
    public partial class AdicionadoAColunaCPFEmCarrinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Carrinho");

            migrationBuilder.AddColumn<string>(
                name: "CPF_NumeroCPF",
                table: "Carrinho",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF_NumeroCPF",
                table: "Carrinho");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Carrinho",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
