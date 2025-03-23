using System;
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
            migrationBuilder.DropIndex(
                name: "IX_Tenants_TenantName",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "TenantName",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "TenantType",
                table: "Tenants");

            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "Tenants",
                newName: "IsActivated");

            migrationBuilder.AddColumn<string>(
                name: "OrganizationAddress",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrganizationDescription",
                table: "Tenants",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrganizationEmail",
                table: "Tenants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OrganizationLandPhone",
                table: "Tenants",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationMobilePhone",
                table: "Tenants",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "Tenants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_OrganizationEmail",
                table: "Tenants",
                column: "OrganizationEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_OrganizationName",
                table: "Tenants",
                column: "OrganizationName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tenants_OrganizationEmail",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_OrganizationName",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "OrganizationAddress",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "OrganizationDescription",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "OrganizationEmail",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "OrganizationLandPhone",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "OrganizationMobilePhone",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "Tenants");

            migrationBuilder.RenameColumn(
                name: "IsActivated",
                table: "Tenants",
                newName: "IsApproved");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tenants",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<string>(
                name: "TenantName",
                table: "Tenants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenantType",
                table: "Tenants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_TenantName",
                table: "Tenants",
                column: "TenantName",
                unique: true);
        }
    }
}
