using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace TimeLogService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateProjectEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: string.Empty,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            _ = migrationBuilder.AlterColumn<Guid>(
                name: "ProjectId",
                table: "Project",
                type: "uniqueidentifier",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Project",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            _ = migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "Project",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 100);
        }
    }
}