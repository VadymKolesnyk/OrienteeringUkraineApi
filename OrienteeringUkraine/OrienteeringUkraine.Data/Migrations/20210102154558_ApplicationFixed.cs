using Microsoft.EntityFrameworkCore.Migrations;

namespace OrienteeringUkraine.Data.Migrations
{
    public partial class ApplicationFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Applications_UserLogin",
                table: "Applications");

            migrationBuilder.AlterColumn<string>(
                name: "UserLogin",
                table: "Applications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Applications_UserLogin_EventGroupId",
                table: "Applications",
                columns: new[] { "UserLogin", "EventGroupId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Applications_UserLogin_EventGroupId",
                table: "Applications");

            migrationBuilder.AlterColumn<string>(
                name: "UserLogin",
                table: "Applications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserLogin",
                table: "Applications",
                column: "UserLogin");
        }
    }
}
