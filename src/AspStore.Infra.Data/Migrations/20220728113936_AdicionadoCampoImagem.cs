using Microsoft.EntityFrameworkCore.Migrations;

namespace AspStore.Infra.Data.Migrations
{
    public partial class AdicionadoCampoImagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Caminho = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
        
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imagem_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imagem_ProdutoId",
                table: "Imagem",
                column: "ProdutoId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagem");
        }
    }
}
