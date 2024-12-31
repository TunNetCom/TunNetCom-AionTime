using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Onetoone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GitHubInfo_IdentityUserId",
                table: "GitHubInfo");

            migrationBuilder.DropIndex(
                name: "IX_AzureInfo_IdentityUserId",
                table: "AzureInfo");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "GitHubInfo",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "AzureInfo",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_GitHubInfo_IdentityUserId",
                table: "GitHubInfo",
                column: "IdentityUserId",
                unique: true,
                filter: "[IdentityUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AzureInfo_IdentityUserId",
                table: "AzureInfo",
                column: "IdentityUserId",
                unique: true,
                filter: "[IdentityUserId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GitHubInfo_IdentityUserId",
                table: "GitHubInfo");

            migrationBuilder.DropIndex(
                name: "IX_AzureInfo_IdentityUserId",
                table: "AzureInfo");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "GitHubInfo",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "AzureInfo",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GitHubInfo_IdentityUserId",
                table: "GitHubInfo",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AzureInfo_IdentityUserId",
                table: "AzureInfo",
                column: "IdentityUserId");
        }
    }
}