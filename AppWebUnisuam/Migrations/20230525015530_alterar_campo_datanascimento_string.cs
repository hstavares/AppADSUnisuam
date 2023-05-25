using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppWebUnisuam.Migrations
{
    /// <inheritdoc />
    public partial class alterar_campo_datanascimento_string : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataNascimento",
                table: "Cadastro",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataNascimento",
                table: "Cadastro",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");
        }
    }
}
