using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BACK.IL.Repository.EF.Migrations
{
    /// <inheritdoc />
    public partial class Preguntasexamen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamQuestion",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GramaticalExamId = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    Question = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CorrectAnswer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserAnswer = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestion", x => x.QuestionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamQuestion");
        }
    }
}
