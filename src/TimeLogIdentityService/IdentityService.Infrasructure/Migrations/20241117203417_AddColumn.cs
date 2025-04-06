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
            _ = migrationBuilder.RenameColumn(
                name: "Key",
                table: "AzureKeys",
                newName: "UserId");

            _ = migrationBuilder.RenameColumn(
                name: "ExpirationDate",
                table: "AzureKeys",
                newName: "TimeStamp");

            _ = migrationBuilder.AddColumn<int>(
                name: "CoreRevision",
                table: "AzureKeys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            _ = migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "AzureKeys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            _ = migrationBuilder.AddColumn<string>(
                name: "PublicAlias",
                table: "AzureKeys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            _ = migrationBuilder.AddColumn<string>(
                name: "PublicKey",
                table: "AzureKeys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty);

            _ = migrationBuilder.AddColumn<DateTime>(
                name: "PublicKeyExpirationDate",
                table: "AzureKeys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            _ = migrationBuilder.AddColumn<int>(
                name: "Revision",
                table: "AzureKeys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            _ = migrationBuilder.AddColumn<bool>(
                name: "IsPrincipalAccount",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            _ = migrationBuilder.AddColumn<string>(
                name: "ParentId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropColumn(
                name: "CoreRevision",
                table: "AzureKeys");

            _ = migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "AzureKeys");

            _ = migrationBuilder.DropColumn(
                name: "PublicAlias",
                table: "AzureKeys");

            _ = migrationBuilder.DropColumn(
                name: "PublicKey",
                table: "AzureKeys");

            _ = migrationBuilder.DropColumn(
                name: "PublicKeyExpirationDate",
                table: "AzureKeys");

            _ = migrationBuilder.DropColumn(
                name: "Revision",
                table: "AzureKeys");

            _ = migrationBuilder.DropColumn(
                name: "IsPrincipalAccount",
                table: "AspNetUsers");

            _ = migrationBuilder.DropColumn(
                name: "ParentId",
                table: "AspNetUsers");

            _ = migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AzureKeys",
                newName: "Key");

            _ = migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "AzureKeys",
                newName: "ExpirationDate");
        }
    }
}