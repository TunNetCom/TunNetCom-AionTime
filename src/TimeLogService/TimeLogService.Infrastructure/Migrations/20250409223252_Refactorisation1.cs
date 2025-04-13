using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeLogService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Refactorisation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Pat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsAionTimeApproved = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PublicAlias = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CoreRevision = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime", nullable: false),
                    Revision = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AionTimeSubscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubsecriptionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AionTimeSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FKOrganizationSubscription",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    AzureProjectId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visibility = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    Url = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FKOrganisationProject",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AionTimeSubscriptionHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionDate = table.Column<DateTime>(type: "date", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AionTimeSubscriptionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FKSubscriptionSubscriptionHistory",
                        column: x => x.SubscriptionId,
                        principalTable: "AionTimeSubscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AzureId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkItemUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItem", x => x.Id);
                    table.ForeignKey(
                        name: "FKProjectTicket",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkItemComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkItemId = table.Column<int>(type: "int", nullable: false),
                    AzureWorkItemId = table.Column<int>(type: "int", nullable: false),
                    AzureCommentId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "varchar(8000)", unicode: false, maxLength: 8000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkItem_WorkItemComment",
                        column: x => x.WorkItemId,
                        principalTable: "WorkItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkItemHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    History = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    WorkItemId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FKTicketHistory",
                        column: x => x.WorkItemId,
                        principalTable: "WorkItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkItemTimeLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Time = table.Column<DateTime>(type: "datetime", nullable: true),
                    WorkItemId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkItemTimeLog", x => x.Id);
                    table.ForeignKey(
                        name: "FKProjectTicketLog",
                        column: x => x.WorkItemId,
                        principalTable: "WorkItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AionTimeSubscription_OrganizationId",
                table: "AionTimeSubscription",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_AionTimeSubscriptionHistory_SubscriptionId",
                table: "AionTimeSubscriptionHistory",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Name_Unique",
                table: "Organization",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_OrganizationId",
                table: "Project",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserId",
                table: "User",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkItem_ProjectId",
                table: "WorkItem",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemComment_WorkItemId",
                table: "WorkItemComment",
                column: "WorkItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemHistory_WorkItemId",
                table: "WorkItemHistory",
                column: "WorkItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkItemTimeLog_WorkItemId",
                table: "WorkItemTimeLog",
                column: "WorkItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AionTimeSubscriptionHistory");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "WorkItemComment");

            migrationBuilder.DropTable(
                name: "WorkItemHistory");

            migrationBuilder.DropTable(
                name: "WorkItemTimeLog");

            migrationBuilder.DropTable(
                name: "AionTimeSubscription");

            migrationBuilder.DropTable(
                name: "WorkItem");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
