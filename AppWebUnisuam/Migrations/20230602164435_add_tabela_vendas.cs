using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppWebUnisuam.Migrations
{
    /// <inheritdoc />
    public partial class add_tabela_vendas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    DataDaVenda = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Produto = table.Column<string>(type: "longtext", nullable: false),
                    Cliente = table.Column<string>(type: "longtext", nullable: false),
                    Quantidade = table.Column<string>(type: "longtext", nullable: false),
                    PrecoUnitario = table.Column<string>(type: "longtext", nullable: false),
                    ValorDaVenda = table.Column<string>(type: "longtext", nullable: false),
                    Desconto = table.Column<string>(type: "longtext", nullable: true),
                    Funcionario = table.Column<string>(type: "longtext", nullable: false),
                    FormaDePagamento = table.Column<string>(type: "longtext", nullable: false),
                    Observacoes = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");
        }
    }
}
