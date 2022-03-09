using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Havbruksloggen_Coding_Challenge.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boats",
                columns: table => new
                {
                    boat_id = table.Column<Guid>(type: "UUID", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    producer = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    build_number = table.Column<int>(type: "int", nullable: false),
                    maximum_length = table.Column<int>(type: "int", nullable: false),
                    maximum_width = table.Column<int>(type: "int", nullable: false),
                    pictures_path = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatId", x => x.boat_id);
                });

            migrationBuilder.CreateTable(
                name: "CrewMembers",
                columns: table => new
                {
                    crew_member_id = table.Column<Guid>(type: "UUID", nullable: false),
                    boat_id = table.Column<Guid>(type: "UUID", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    pictures_path = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    crew_role = table.Column<int>(type: "int", nullable: false),
                    certified_until = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewMemberId", x => x.crew_member_id);
                    table.ForeignKey(
                        name: "FK_CrewMembers_Boats_boat_id",
                        column: x => x.boat_id,
                        principalTable: "Boats",
                        principalColumn: "boat_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrewMembers_boat_id",
                table: "CrewMembers",
                column: "boat_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrewMembers");

            migrationBuilder.DropTable(
                name: "Boats");
        }
    }
}
