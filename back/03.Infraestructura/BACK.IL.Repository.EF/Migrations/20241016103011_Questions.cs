using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BACK.IL.Repository.EF.Migrations
{
    /// <inheritdoc />
    public partial class Questions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdExam = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    TextQuestion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CorrectAnswer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserAnswer = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", maxLength: 20, nullable: true),
                    Feedback = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Score = table.Column<double>(type: "double precision", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
