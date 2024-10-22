using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BACK.IL.Repository.EF.Migrations
{
    /// <inheritdoc />
    public partial class MigrationSpeakingWritingListeningReadingUseOfEnglishQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListeningQuestions",
                columns: table => new
                {
                    ListeningQuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AudioUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Question = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Options = table.Column<string[]>(type: "text[]", maxLength: 200, nullable: false),
                    UserAnswer = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    CorrectAnswer = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListeningQuestions", x => x.ListeningQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "ReadingQuestions",
                columns: table => new
                {
                    ReadingQuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Question = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Options = table.Column<string[]>(type: "text[]", maxLength: 200, nullable: false),
                    CorrectAnswer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserAnswer = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadingQuestions", x => x.ReadingQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "SpeakingQuestions",
                columns: table => new
                {
                    SpeakingQuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Question = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    TextAnswer = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AudioAnswer = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Feedback = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeakingQuestions", x => x.SpeakingQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "UseOfEnglishQuestions",
                columns: table => new
                {
                    UseOfEnglishQuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TextWithSpaces = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Options = table.Column<string[]>(type: "text[]", maxLength: 200, nullable: false),
                    CorrectAnswer = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserAnswer = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UseOfEnglishQuestions", x => x.UseOfEnglishQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "WritingQuestions",
                columns: table => new
                {
                    WritingQuestionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Question = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    UserAnswer = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Feedback = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WritingQuestions", x => x.WritingQuestionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListeningQuestions");

            migrationBuilder.DropTable(
                name: "ReadingQuestions");

            migrationBuilder.DropTable(
                name: "SpeakingQuestions");

            migrationBuilder.DropTable(
                name: "UseOfEnglishQuestions");

            migrationBuilder.DropTable(
                name: "WritingQuestions");
        }
    }
}
