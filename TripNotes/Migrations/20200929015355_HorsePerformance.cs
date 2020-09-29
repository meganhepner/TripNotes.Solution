using Microsoft.EntityFrameworkCore.Migrations;

namespace TripNotes.Migrations
{
    public partial class HorsePerformance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HorsePerformance",
                table: "HorseRace",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorsePerformance",
                table: "HorseRace");
        }
    }
}
