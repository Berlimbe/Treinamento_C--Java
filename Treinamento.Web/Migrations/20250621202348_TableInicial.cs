using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Treinamento.Web.Migrations
{
    /// <inheritdoc />
    public partial class TableInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Linguagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linguagens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Informacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Conteudo = table.Column<string>(type: "TEXT", nullable: false),
                    LinguagemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Informacoes_Linguagens_LinguagemId",
                        column: x => x.LinguagemId,
                        principalTable: "Linguagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Linguagens",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Java" },
                    { 2, "C#" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Informacoes_LinguagemId",
                table: "Informacoes",
                column: "LinguagemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Informacoes");

            migrationBuilder.DropTable(
                name: "Linguagens");
        }
    }
}
