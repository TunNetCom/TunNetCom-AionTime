using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

#nullable disable

namespace IdentityService.Infrastructure.Migrations
{
    /// <inheritdoc />
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:Element should begin with upper-case letter")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1404:Code analysis suppression should have justification")]
    public partial class changeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_AzureKeys_AspNetUsers_IdentityUserId",
                table: "AzureKeys");

            _ = migrationBuilder.DropTable(
                name: "GitHubKeys");

            _ = migrationBuilder.DropPrimaryKey(
                name: "PK_AzureKeys",
                table: "AzureKeys");

            _ = migrationBuilder.RenameTable(
                name: "AzureKeys",
                newName: "AzureInfo");

            _ = migrationBuilder.RenameIndex(
                name: "IX_AzureKeys_IdentityUserId",
                table: "AzureInfo",
                newName: "IX_AzureInfo_IdentityUserId");

            _ = migrationBuilder.AddPrimaryKey(
                name: "PK_AzureInfo",
                table: "AzureInfo",
                column: "Id");

            _ = migrationBuilder.CreateTable(
                name: "GitHubInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "IX_GitHubInfo_IdentityUserId",
                table: "GitHubInfo",
                column: "IdentityUserId");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_AzureInfo_AspNetUsers_IdentityUserId",
                table: "AzureInfo",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_AzureInfo_AspNetUsers_IdentityUserId",
                table: "AzureInfo");

            _ = migrationBuilder.DropTable(
                name: "GitHubInfo");

            _ = migrationBuilder.DropPrimaryKey(
                name: "PK_AzureInfo",
                table: "AzureInfo");

            _ = migrationBuilder.RenameTable(
                name: "AzureInfo",
                newName: "AzureKeys");

            _ = migrationBuilder.RenameIndex(
                name: "IX_AzureInfo_IdentityUserId",
                table: "AzureKeys",
                newName: "IX_AzureKeys_IdentityUserId");

            _ = migrationBuilder.AddPrimaryKey(
                name: "PK_AzureKeys",
                table: "AzureKeys",
                column: "Id");

            _ = migrationBuilder.CreateTable(
                name: "GitHubKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_GitHubKeys", x => x.Id);
                    _ = table.ForeignKey(
                        name: "FK_GitHubKeys_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_GitHubKeys_IdentityUserId",
                table: "GitHubKeys",
                column: "IdentityUserId");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_AzureKeys_AspNetUsers_IdentityUserId",
                table: "AzureKeys",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}