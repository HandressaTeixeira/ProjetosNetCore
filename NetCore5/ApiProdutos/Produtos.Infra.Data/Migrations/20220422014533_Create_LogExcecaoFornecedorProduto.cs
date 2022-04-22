using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Produtos.Infra.Data.Migrations
{
    public partial class Create_LogExcecaoFornecedorProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "LogExcecao",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mensagem = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    StackTrace = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogExcecao", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    FornecedorGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Produto_Fornecedor_FornecedorGuid",
                        column: x => x.FornecedorGuid,
                        principalTable: "Fornecedor",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorGuid",
                table: "Produto",
                column: "FornecedorGuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogExcecao");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Fornecedor");
        }
    }
}
