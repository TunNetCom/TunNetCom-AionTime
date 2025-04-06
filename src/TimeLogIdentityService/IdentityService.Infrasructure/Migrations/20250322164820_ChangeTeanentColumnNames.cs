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
            _ = migrationBuilder.RenameColumn(
                name: "OrganizationName",
                table: "Tenants",
                newName: "Name");

            _ = migrationBuilder.RenameColumn(
                name: "OrganizationMobilePhone",
                table: "Tenants",
                newName: "MobilePhone");

            _ = migrationBuilder.RenameColumn(
                name: "OrganizationLandPhone",
                table: "Tenants",
                newName: "LandPhone");

            _ = migrationBuilder.RenameColumn(
                name: "OrganizationEmail",
                table: "Tenants",
                newName: "Email");

            _ = migrationBuilder.RenameColumn(
                name: "OrganizationDescription",
                table: "Tenants",
                newName: "Description");

            _ = migrationBuilder.RenameColumn(
                name: "OrganizationAddress",
                table: "Tenants",
                newName: "Address");

            _ = migrationBuilder.RenameIndex(
                name: "IX_Tenants_OrganizationName",
                table: "Tenants",
                newName: "IX_Tenants_Name");

            _ = migrationBuilder.RenameIndex(
                name: "IX_Tenants_OrganizationEmail",
                table: "Tenants",
                newName: "IX_Tenants_Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tenants",
                newName: "OrganizationName");

            _ = migrationBuilder.RenameColumn(
                name: "MobilePhone",
                table: "Tenants",
                newName: "OrganizationMobilePhone");

            _ = migrationBuilder.RenameColumn(
                name: "LandPhone",
                table: "Tenants",
                newName: "OrganizationLandPhone");

            _ = migrationBuilder.RenameColumn(
                name: "Email",
                table: "Tenants",
                newName: "OrganizationEmail");

            _ = migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tenants",
                newName: "OrganizationDescription");

            _ = migrationBuilder.RenameColumn(
                name: "Address",
                table: "Tenants",
                newName: "OrganizationAddress");

            _ = migrationBuilder.RenameIndex(
                name: "IX_Tenants_Name",
                table: "Tenants",
                newName: "IX_Tenants_OrganizationName");

            _ = migrationBuilder.RenameIndex(
                name: "IX_Tenants_Email",
                table: "Tenants",
                newName: "IX_Tenants_OrganizationEmail");
        }
    }
}