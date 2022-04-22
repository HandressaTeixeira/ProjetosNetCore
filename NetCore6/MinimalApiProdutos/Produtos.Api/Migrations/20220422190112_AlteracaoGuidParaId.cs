using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produtos.Api.Migrations
{
    public partial class AlteracaoGuidParaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorGuid",
                table: "Produto");

            migrationBuilder.RenameColumn(
                name: "FornecedorGuid",
                table: "Produto",
                newName: "FornecedorId");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Produto",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_FornecedorGuid",
                table: "Produto",
                newName: "IX_Produto_FornecedorId");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Fornecedor",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorId",
                table: "Produto",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorId",
                table: "Produto");

            migrationBuilder.RenameColumn(
                name: "FornecedorId",
                table: "Produto",
                newName: "FornecedorGuid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Produto",
                newName: "Guid");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_FornecedorId",
                table: "Produto",
                newName: "IX_Produto_FornecedorGuid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Fornecedor",
                newName: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Fornecedor_FornecedorGuid",
                table: "Produto",
                column: "FornecedorGuid",
                principalTable: "Fornecedor",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
