using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspStore.Infra.Data.Migrations
{
    public partial class AdicaoColunaCodigoInternoEmProdutoCarrinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodigoInterno",
                table: "ProdutoCarrinho",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoInterno",
                table: "ProdutoCarrinho");
        }
    }
}
