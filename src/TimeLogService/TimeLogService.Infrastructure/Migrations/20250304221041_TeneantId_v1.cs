using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeLogService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TeneantId_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "WorkItemTimeLog",
                type: "nvarchar(max)",
                nullable: true);

            _ = migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "WorkItemHistory",
                type: "nvarchar(max)",
                nullable: true);

            _ = migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "WorkItem",
                type: "nvarchar(max)",
                nullable: true);

            _ = migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            _ = migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            _ = migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "Organization",
                type: "nvarchar(max)",
                nullable: true);

            _ = migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "AionTimeSubscriptionHistory",
                type: "nvarchar(max)",
                nullable: true);

            _ = migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "AionTimeSubscription",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropColumn(
                name: "TenantId",
                table: "WorkItemTimeLog");

            _ = migrationBuilder.DropColumn(
                name: "TenantId",
                table: "WorkItemHistory");

            _ = migrationBuilder.DropColumn(
                name: "TenantId",
                table: "WorkItem");

            _ = migrationBuilder.DropColumn(
                name: "TenantId",
                table: "User");

            _ = migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Project");

            _ = migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Organization");

            _ = migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AionTimeSubscriptionHistory");

            _ = migrationBuilder.DropColumn(
                name: "TenantId",
                table: "AionTimeSubscription");
        }
    }
}