using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizProject.Data.Migrations
{
    public partial class IcollectionDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Answers_AnswerId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_AnswerId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Question");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Question",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Question_AnswerId",
                table: "Question",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Answers_AnswerId",
                table: "Question",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");
        }
    }
}
