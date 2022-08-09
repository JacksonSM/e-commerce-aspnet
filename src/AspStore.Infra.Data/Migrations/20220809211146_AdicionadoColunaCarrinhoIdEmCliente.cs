using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspStore.Infra.Data.Migrations
{
    public partial class AdicionadoColunaCarrinhoIdEmCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrinho_Cliente_ClienteId",
                table: "Carrinho");

            migrationBuilder.DropIndex(
                name: "IX_Carrinho_ClienteId",
                table: "Carrinho");

            migrationBuilder.AddColumn<int>(
                name: "CarrinhoId",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CarrinhoId",
                table: "Cliente",
                column: "CarrinhoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Carrinho_CarrinhoId",
                table: "Cliente",
                column: "CarrinhoId",
                principalTable: "Carrinho",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Carrinho_CarrinhoId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_CarrinhoId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Carrinho_ClienteId",
                table: "Carrinho",
                column: "ClienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinho_Cliente_ClienteId",
                table: "Carrinho",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id");
        }
    }
}
