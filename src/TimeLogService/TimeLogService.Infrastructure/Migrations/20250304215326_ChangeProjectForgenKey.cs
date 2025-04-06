using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeLogService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProjectForgenKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FKOrganisationProject",
                table: "Project");

            _ = migrationBuilder.DropIndex(
                name: "IX_Project_OrganizationId",
                table: "Project");

            _ = migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Project");

            _ = migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Project",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: string.Empty);

            _ = migrationBuilder.AddUniqueConstraint(
                name: "AK_Organization_AccountId",
                table: "Organization",
                column: "AccountId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Project_AccountId",
                table: "Project",
                column: "AccountId");

            _ = migrationBuilder.AddForeignKey(
                name: "FKOrganisationProject",
                table: "Project",
                column: "AccountId",
                principalTable: "Organization",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FKOrganisationProject",
                table: "Project");

            _ = migrationBuilder.DropIndex(
                name: "IX_Project_AccountId",
                table: "Project");

            _ = migrationBuilder.DropUniqueConstraint(
                name: "AK_Organization_AccountId",
                table: "Organization");

            _ = migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Project");

            _ = migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            _ = migrationBuilder.CreateIndex(
                name: "IX_Project_OrganizationId",
                table: "Project",
                column: "OrganizationId");

            _ = migrationBuilder.AddForeignKey(
                name: "FKOrganisationProject",
                table: "Project",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}