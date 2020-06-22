using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_Users_CommentId",
                table: "CommentLikes");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_UserId",
                table: "CommentLikes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_Users_UserId",
                table: "CommentLikes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentLikes_Users_UserId",
                table: "CommentLikes");

            migrationBuilder.DropIndex(
                name: "IX_CommentLikes_UserId",
                table: "CommentLikes");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLikes_Users_CommentId",
                table: "CommentLikes",
                column: "CommentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
