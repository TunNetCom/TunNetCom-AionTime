using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace IdentityService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMultyTenancyV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_Tenants_AzureKeyInfo_AzureKeyInfoId",
                table: "Tenants");

            _ = migrationBuilder.DropTable(
                name: "ApplicationUserTenant");

            _ = migrationBuilder.DropTable(
                name: "AzureKeyInfo");

            _ = migrationBuilder.DropIndex(
                name: "IX_Tenants_AzureKeyInfoId",
                table: "Tenants");

            _ = migrationBuilder.DropIndex(
                name: "IX_Tenants_TenantName",
                table: "Tenants");

            _ = migrationBuilder.DropColumn(
                name: "AzureKeyInfoId",
                table: "Tenants");

            _ = migrationBuilder.AlterColumn<string>(
                name: "TenantType",
                table: "Tenants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            _ = migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tenants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 3, 15, 20, 35, 16, 222, DateTimeKind.Utc).AddTicks(6414));

            _ = migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Tenants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            _ = migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            _ = migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TenantId",
                table: "AspNetUsers",
                column: "TenantId");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tenants_TenantId",
                table: "AspNetUsers",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tenants_TenantId",
                table: "AspNetUsers");

            _ = migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TenantId",
                table: "AspNetUsers");

            _ = migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tenants");

            _ = migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Tenants");

            _ = migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AspNetUsers");

            _ = migrationBuilder.AlterColumn<string>(
                name: "TenantType",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            _ = migrationBuilder.AddColumn<int>(
                name: "AzureKeyInfoId",
                table: "Tenants",
                type: "int",
                nullable: true);

            _ = migrationBuilder.CreateTable(
                name: "ApplicationUserTenant",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_ApplicationUserTenant", x => new { x.ApplicationUserId, x.TenantId });
                    _ = table.ForeignKey(
                        name: "FK_ApplicationUserTenant_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    _ = table.ForeignKey(
                        name: "FK_ApplicationUserTenant_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "AzureKeyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoreRevision = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PublicAlias = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PublicKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicKeyExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revision = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AzureKeyInfo", x => x.Id);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_Tenants_AzureKeyInfoId",
                table: "Tenants",
                column: "AzureKeyInfoId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Tenants_TenantName",
                table: "Tenants",
                column: "TenantName",
                unique: true);

            _ = migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserTenant_TenantId",
                table: "ApplicationUserTenant",
                column: "TenantId");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_Tenants_AzureKeyInfo_AzureKeyInfoId",
                table: "Tenants",
                column: "AzureKeyInfoId",
                principalTable: "AzureKeyInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}