using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeLogService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FKUserOrganization",
                table: "Organization");

            _ = migrationBuilder.DropUniqueConstraint(
                name: "AK_User_UserId",
                table: "User");

            _ = migrationBuilder.DropIndex(
                name: "IX_Organization_UserId",
                table: "Organization");

            _ = migrationBuilder.DropColumn(
                name: "UserId",
                table: "Organization");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Organization",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: string.Empty);

            _ = migrationBuilder.AddUniqueConstraint(
                name: "AK_User_UserId",
                table: "User",
                column: "UserId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Organization_UserId",
                table: "Organization",
                column: "UserId");

            _ = migrationBuilder.AddForeignKey(
                name: "FKUserOrganization",
                table: "Organization",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}