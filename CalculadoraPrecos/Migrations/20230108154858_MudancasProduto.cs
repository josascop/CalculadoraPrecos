using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalculadoraPrecos.Migrations
{
    /// <inheritdoc />
    public partial class MudancasProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "EmEstoque",
                table: "Produto");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Produto",
                newName: "Unidade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Unidade",
                table: "Produto",
                newName: "Tipo");

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "Produto",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<uint>(
                name: "EmEstoque",
                table: "Produto",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0u);
        }
    }
}
