using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class modifierEstActiveTruePourClinique1PourTester : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "EstActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "EstActive",
                value: false);
        }
    }
}
