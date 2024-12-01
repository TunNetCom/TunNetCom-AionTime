using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace IdentityService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Key",
                table: "AzureKeys",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                table: "AzureKeys",
                newName: "TimeStamp");

            migrationBuilder.AddColumn<int>(
                name: "CoreRevision",
                table: "AzureKeys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "AzureKeys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "PublicAlias",
                table: "AzureKeys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<string>(
                name: "PublicKey",
                table: "AzureKeys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicKeyExpirationDate",
                table: "AzureKeys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Revision",
                table: "AzureKeys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrincipalAccount",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ParentId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoreRevision",
                table: "AzureKeys");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "AzureKeys");

            migrationBuilder.DropColumn(
                name: "PublicAlias",
                table: "AzureKeys");

            migrationBuilder.DropColumn(
                name: "PublicKey",
                table: "AzureKeys");

            migrationBuilder.DropColumn(
                name: "PublicKeyExpirationDate",
                table: "AzureKeys");

            migrationBuilder.DropColumn(
                name: "Revision",
                table: "AzureKeys");

            migrationBuilder.DropColumn(
                name: "IsPrincipalAccount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AzureKeys",
                newName: "Key");

            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "AzureKeys",
                newName: "ExpirationDate");
        }
    }
}