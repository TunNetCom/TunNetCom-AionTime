using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GitHubInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            _ = migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: string.Empty);

            _ = migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: string.Empty);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropColumn(
                name: "Name",
                table: "GitHubInfo");

            _ = migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            _ = migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }
    }
}