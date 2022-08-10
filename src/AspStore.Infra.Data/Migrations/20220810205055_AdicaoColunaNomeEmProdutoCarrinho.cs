using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspStore.Infra.Data.Migrations
{
    public partial class AdicaoColunaNomeEmProdutoCarrinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "ProdutoCarrinho",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ProdutoCarrinho");
        }
    }
}
