using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppWebUnisuam.Migrations
{
    /// <inheritdoc />
    public partial class add_tabela_produtos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Descrição = table.Column<string>(type: "longtext", nullable: true),
                    Preco = table.Column<string>(type: "longtext", nullable: false),
                    Categoria = table.Column<string>(type: "longtext", nullable: true),
                    Marca = table.Column<string>(type: "longtext", nullable: true),
                    Imagem = table.Column<string>(type: "longtext", nullable: true),
                    Disponibilidade = table.Column<string>(type: "longtext", nullable: true),
                    Estoque = table.Column<string>(type: "longtext", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
