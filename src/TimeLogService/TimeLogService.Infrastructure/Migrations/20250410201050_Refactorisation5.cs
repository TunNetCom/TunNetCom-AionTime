using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeLogService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Refactorisation5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedByUser",
                table: "WorkItemComment",
                newName: "CreatedByUserEmail");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "WorkItemComment",
                newName: "CommentText");

            migrationBuilder.AddColumn<string>(
                name: "CommentFormat",
                table: "WorkItemComment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CommentUrl",
                table: "WorkItemComment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUserDisplayName",
                table: "WorkItemComment",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentFormat",
                table: "WorkItemComment");

            migrationBuilder.DropColumn(
                name: "CommentUrl",
                table: "WorkItemComment");

            migrationBuilder.DropColumn(
                name: "CreatedByUserDisplayName",
                table: "WorkItemComment");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserEmail",
                table: "WorkItemComment",
                newName: "CreatedByUser");

            migrationBuilder.RenameColumn(
                name: "CommentText",
                table: "WorkItemComment",
                newName: "Comment");
        }
    }
}
