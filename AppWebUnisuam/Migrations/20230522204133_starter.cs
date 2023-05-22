using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppWebUnisuam.Migrations
{
    /// <inheritdoc />
    public partial class starter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cadastro",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Pais = table.Column<string>(type: "longtext", nullable: false),
                    Cidade = table.Column<string>(type: "longtext", nullable: false),
                    Bairro = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadastro");
        }
    }
}
