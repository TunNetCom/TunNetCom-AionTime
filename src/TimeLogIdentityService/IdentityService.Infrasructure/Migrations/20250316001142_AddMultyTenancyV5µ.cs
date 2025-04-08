using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMultyTenancyV5µ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropIndex(
                name: "IX_Tenants_TenantName",
                table: "Tenants");

            _ = migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tenants");

            _ = migrationBuilder.DropColumn(
                name: "TenantName",
                table: "Tenants");

            _ = migrationBuilder.DropColumn(
                name: "TenantType",
                table: "Tenants");

            _ = migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "Tenants",
                newName: "IsActivated");

            _ = migrationBuilder.AddColumn<string>(
                name: "OrganizationAddress",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            _ = migrationBuilder.AddColumn<string>(
                name: "OrganizationDescription",
                table: "Tenants",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: string.Empty);

            _ = migrationBuilder.AddColumn<string>(
                name: "OrganizationEmail",
                table: "Tenants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: string.Empty);

            _ = migrationBuilder.AddColumn<string>(
                name: "OrganizationLandPhone",
                table: "Tenants",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            _ = migrationBuilder.AddColumn<string>(
                name: "OrganizationMobilePhone",
                table: "Tenants",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            _ = migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "Tenants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: string.Empty);

            _ = migrationBuilder.CreateIndex(
                name: "IX_Tenants_OrganizationEmail",
                table: "Tenants",
                column: "OrganizationEmail",
                unique: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_Tenants_OrganizationName",
                table: "Tenants",
                column: "OrganizationName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropIndex(
                name: "IX_Tenants_OrganizationEmail",
                table: "Tenants");

            _ = migrationBuilder.DropIndex(
                name: "IX_Tenants_OrganizationName",
                table: "Tenants");

            _ = migrationBuilder.DropColumn(
                name: "OrganizationAddress",
                table: "Tenants");

            _ = migrationBuilder.DropColumn(
                name: "OrganizationDescription",
                table: "Tenants");

            _ = migrationBuilder.DropColumn(
                name: "OrganizationEmail",
                table: "Tenants");

            _ = migrationBuilder.DropColumn(
                name: "OrganizationLandPhone",
                table: "Tenants");

            _ = migrationBuilder.DropColumn(
                name: "OrganizationMobilePhone",
                table: "Tenants");

            _ = migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "Tenants");

            _ = migrationBuilder.RenameColumn(
                name: "IsActivated",
                table: "Tenants",
                newName: "IsApproved");

            _ = migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tenants",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            _ = migrationBuilder.AddColumn<string>(
                name: "TenantName",
                table: "Tenants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: string.Empty);

            _ = migrationBuilder.AddColumn<string>(
                name: "TenantType",
                table: "Tenants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: string.Empty);

            _ = migrationBuilder.CreateIndex(
                name: "IX_Tenants_TenantName",
                table: "Tenants",
                column: "TenantName",
                unique: true);
        }
    }
}