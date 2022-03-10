using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Havbruksloggen_Coding_Challenge.Migrations
{
    public partial class DbCrewFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "CrewMembers",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "CrewMembers");
        }
    }
}
