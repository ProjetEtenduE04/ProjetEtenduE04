using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class SeedClinique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cliniques",
                columns: new[] { "CliniqueID", "TempsMoyenConsultation" },
                values: new object[] { 1, 30 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1);
        }
    }
}
