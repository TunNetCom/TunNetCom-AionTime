using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMultyTenancy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "AzureInfo");

            _ = migrationBuilder.DropTable(
                name: "GitHubInfo");

            _ = migrationBuilder.DropColumn(
                name: "IsPrincipalAccount",
                table: "AspNetUsers");

            _ = migrationBuilder.DropColumn(
                name: "ParentId",
                table: "AspNetUsers");

            _ = migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            _ = migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            _ = migrationBuilder.CreateTable(
                name: "AzureKeyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PublicAlias = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CoreRevision = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revision = table.Column<int>(type: "int", nullable: false),
                    PublicKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicKeyExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AzureKeyInfo", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    TenantName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenantType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AzureKeyInfoId = table.Column<int>(type: "int", nullable: true),
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_Tenants", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_Tenants_AzureKeyInfo_AzureKeyInfoId",
                        column: x => x.AzureKeyInfoId,
                        principalTable: "AzureKeyInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            _ = migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserTenant_TenantId",
                table: "ApplicationUserTenant",
                column: "TenantId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Tenants_AzureKeyInfoId",
                table: "Tenants",
                column: "AzureKeyInfoId");

            _ = migrationBuilder.CreateIndex(
                name: "IX_Tenants_TenantName",
                table: "Tenants",
                column: "TenantName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "ApplicationUserTenant");

            _ = migrationBuilder.DropTable(
                name: "Tenants");

            _ = migrationBuilder.DropTable(
                name: "AzureKeyInfo");

            _ = migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            _ = migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            _ = migrationBuilder.AddColumn<bool>(
                name: "IsPrincipalAccount",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            _ = migrationBuilder.AddColumn<string>(
                name: "ParentId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            _ = migrationBuilder.CreateTable(
                name: "AzureInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CoreRevision = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PublicAlias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicKeyExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revision = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_AzureInfo", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_AzureInfo_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateTable(
                name: "GitHubInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_GitHubInfo", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_GitHubInfo_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_AzureInfo_IdentityUserId",
                table: "AzureInfo",
                column: "IdentityUserId",
                unique: true,
                filter: "[IdentityUserId] IS NOT NULL");

            _ = migrationBuilder.CreateIndex(
                name: "IX_GitHubInfo_IdentityUserId",
                table: "GitHubInfo",
                column: "IdentityUserId",
                unique: true,
                filter: "[IdentityUserId] IS NOT NULL");
        }
    }
}