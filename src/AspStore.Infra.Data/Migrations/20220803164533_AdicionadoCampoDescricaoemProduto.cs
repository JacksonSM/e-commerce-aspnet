using Microsoft.EntityFrameworkCore.Migrations;

namespace AspStore.Infra.Data.Migrations
{
    public partial class AdicionadoCampoDescricaoemProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Produto");
        }
    }
}
