using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ajutSeedCLiniqueData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "AdresseID", "CodePostal", "Pays", "Province", "Rue", "Ville" },
                values: new object[] { 2, "J3Y 1Y5", "Canada", "Quebec", "Rue ABC", "Brossard" });

            migrationBuilder.InsertData(
                table: "Cliniques",
                columns: new[] { "CliniqueID", "AdresseID", "Courriel", "EstActive", "HeureFermeture", "HeureOuverture", "NomClinique", "TempsMoyenConsultation" },
                values: new object[] { 2, 2, "nguyenhonganh.hn29@gmail.com", false, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0), "Apple CLinique", 45 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Adresses",
                keyColumn: "AdresseID",
                keyValue: 2);
        }
    }
}
