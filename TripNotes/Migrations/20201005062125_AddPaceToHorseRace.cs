using Microsoft.EntityFrameworkCore.Migrations;

namespace TripNotes.Migrations
{
    public partial class AddPaceToHorseRace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AP",
                table: "HorseRace",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EP",
                table: "HorseRace",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FX",
                table: "HorseRace",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FirstFR",
                table: "HorseRace",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PercentEarly",
                table: "HorseRace",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SP",
                table: "HorseRace",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondFR",
                table: "HorseRace",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThirdFR",
                table: "HorseRace",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AP",
                table: "HorseRace");

            migrationBuilder.DropColumn(
                name: "EP",
                table: "HorseRace");

            migrationBuilder.DropColumn(
                name: "FX",
                table: "HorseRace");

            migrationBuilder.DropColumn(
                name: "FirstFR",
                table: "HorseRace");

            migrationBuilder.DropColumn(
                name: "PercentEarly",
                table: "HorseRace");

            migrationBuilder.DropColumn(
                name: "SP",
                table: "HorseRace");

            migrationBuilder.DropColumn(
                name: "SecondFR",
                table: "HorseRace");

            migrationBuilder.DropColumn(
                name: "ThirdFR",
                table: "HorseRace");
        }
    }
}
