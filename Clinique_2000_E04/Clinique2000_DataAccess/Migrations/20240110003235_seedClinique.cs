using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class seedClinique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dureeConsultationMinutes",
                table: "ListeAttentes",
                newName: "DureeConsultationMinutes");

            migrationBuilder.InsertData(
                table: "Cliniques",
                columns: new[] { "CliniqueID", "TempsMoyenConsultation" },
                values: new object[] {1, 30 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "DureeConsultationMinutes",
                table: "ListeAttentes",
                newName: "dureeConsultationMinutes");
        }
    }
}
