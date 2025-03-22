using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTeanentColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrganizationName",
                table: "Tenants",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "OrganizationMobilePhone",
                table: "Tenants",
                newName: "MobilePhone");

            migrationBuilder.RenameColumn(
                name: "OrganizationLandPhone",
                table: "Tenants",
                newName: "LandPhone");

            migrationBuilder.RenameColumn(
                name: "OrganizationEmail",
                table: "Tenants",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "OrganizationDescription",
                table: "Tenants",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "OrganizationAddress",
                table: "Tenants",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Tenants_OrganizationName",
                table: "Tenants",
                newName: "IX_Tenants_Name");

            migrationBuilder.RenameIndex(
                name: "IX_Tenants_OrganizationEmail",
                table: "Tenants",
                newName: "IX_Tenants_Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tenants",
                newName: "OrganizationName");

            migrationBuilder.RenameColumn(
                name: "MobilePhone",
                table: "Tenants",
                newName: "OrganizationMobilePhone");

            migrationBuilder.RenameColumn(
                name: "LandPhone",
                table: "Tenants",
                newName: "OrganizationLandPhone");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Tenants",
                newName: "OrganizationEmail");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tenants",
                newName: "OrganizationDescription");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Tenants",
                newName: "OrganizationAddress");

            migrationBuilder.RenameIndex(
                name: "IX_Tenants_Name",
                table: "Tenants",
                newName: "IX_Tenants_OrganizationName");

            migrationBuilder.RenameIndex(
                name: "IX_Tenants_Email",
                table: "Tenants",
                newName: "IX_Tenants_OrganizationEmail");
        }
    }
}
