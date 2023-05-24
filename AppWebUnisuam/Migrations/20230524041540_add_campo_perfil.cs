using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppWebUnisuam.Migrations
{
    /// <inheritdoc />
    public partial class add_campo_perfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Perfil",
                table: "Cadastro",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "Cadastro");
        }
    }
}
