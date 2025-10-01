using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaTabelaJogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Jogo");

            migrationBuilder.CreateTable(
                name: "Jogo",
                schema: "Jogo",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Desenvolvedor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "date", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(2000)", nullable: false),
                    ClassificacaoIndicativa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CriadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModificadoPor = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    Status = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogo", x => x.Guid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogo",
                schema: "Jogo");
        }
    }
}
