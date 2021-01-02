using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrienteeringUkraine.Data.Migrations
{
    public partial class EventsAndApplicationsConfigurated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_UserLogin",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Regions_RegionId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_UserLogin",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "UserLogin",
                table: "Events",
                newName: "OrganizerLogin");

            migrationBuilder.RenameIndex(
                name: "IX_Events_UserLogin",
                table: "Events",
                newName: "IX_Events_OrganizerLogin");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Events",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InfoLink",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplicationOpen",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Events",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultsLink",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Chip",
                table: "Applications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventGroupId",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(31)", maxLength: 31, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.UniqueConstraint("AK_Groups_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "EventGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGroups", x => x.Id);
                    table.UniqueConstraint("AK_EventGroups_EventId_GroupId", x => new { x.EventId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_EventGroups_Events",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventGroups_Groups",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_Date",
                table: "Events",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_EventGroupId",
                table: "Applications",
                column: "EventGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EventGroups_GroupId",
                table: "EventGroups",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_EventGroups",
                table: "Applications",
                column: "EventGroupId",
                principalTable: "EventGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users",
                table: "Applications",
                column: "UserLogin",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Regions",
                table: "Events",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users",
                table: "Events",
                column: "OrganizerLogin",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_EventGroups",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Regions",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users",
                table: "Events");

            migrationBuilder.DropTable(
                name: "EventGroups");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Events_Date",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Applications_EventGroupId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "InfoLink",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsApplicationOpen",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ResultsLink",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Chip",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "EventGroupId",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "OrganizerLogin",
                table: "Events",
                newName: "UserLogin");

            migrationBuilder.RenameIndex(
                name: "IX_Events_OrganizerLogin",
                table: "Events",
                newName: "IX_Events_UserLogin");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_UserLogin",
                table: "Applications",
                column: "UserLogin",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Regions_RegionId",
                table: "Events",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_UserLogin",
                table: "Events",
                column: "UserLogin",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
