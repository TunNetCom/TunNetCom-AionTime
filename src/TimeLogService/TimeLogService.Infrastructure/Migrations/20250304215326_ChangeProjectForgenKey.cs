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
            migrationBuilder.DropForeignKey(
                name: "FKOrganisationProject",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_OrganizationId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Project",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Organization_AccountId",
                table: "Organization",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_AccountId",
                table: "Project",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
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
            migrationBuilder.DropForeignKey(
                name: "FKOrganisationProject",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_AccountId",
                table: "Project");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Organization_AccountId",
                table: "Organization");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Project");

            migrationBuilder.AddColumn<int>(
                name: "OrganizationId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Project_OrganizationId",
                table: "Project",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FKOrganisationProject",
                table: "Project",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
