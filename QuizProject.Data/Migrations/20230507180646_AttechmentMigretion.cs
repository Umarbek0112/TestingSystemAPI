using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizProject.Data.Migrations
{
    public partial class AttechmentMigretion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Question_AttachmentId",
                table: "Question",
                column: "AttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Attachments_AttachmentId",
                table: "Question",
                column: "AttachmentId",
                principalTable: "Attachments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Attachments_AttachmentId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_AttachmentId",
                table: "Question");
        }
    }
}
