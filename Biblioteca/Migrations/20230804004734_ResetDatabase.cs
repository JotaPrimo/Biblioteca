using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class ResetDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FormacaoAcademicas",
                table: "FormacaoAcademicas");

            migrationBuilder.RenameTable(
                name: "FormacaoAcademicas",
                newName: "formacao_academicas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_formacao_academicas",
                table: "formacao_academicas",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_formacao_academicas",
                table: "formacao_academicas");

            migrationBuilder.RenameTable(
                name: "formacao_academicas",
                newName: "FormacaoAcademicas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormacaoAcademicas",
                table: "FormacaoAcademicas",
                column: "Id");
        }
    }
}
