using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class modifierPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Patient");

            migrationBuilder.AddColumn<string>(
                name: "GoogleNameIdentifier",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleNameIdentifier",
                table: "Patient");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
