using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripNotes.Migrations
{
    public partial class RaceDateToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RaceDate",
                table: "Races",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RaceDate",
                table: "Races",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
