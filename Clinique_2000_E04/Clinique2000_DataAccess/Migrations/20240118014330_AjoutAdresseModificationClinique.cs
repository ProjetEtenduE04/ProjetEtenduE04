using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class AjoutAdresseModificationClinique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdresseID",
                table: "Cliniques",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Courriel",
                table: "Cliniques",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "EstActive",
                table: "Cliniques",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HeureFermeture",
                table: "Cliniques",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HeureOuverture",
                table: "Cliniques",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "NomClinique",
                table: "Cliniques",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    AdresseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rue = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Pays = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.AdresseID);
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "AdresseID", "CodePostal", "Pays", "Province", "Rue", "Ville" },
                values: new object[] { 1, "H1H 1H1", "Canada", "Québec", "123 rue de la clinique", "Montréal" });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "AdresseID", "CodePostal", "Pays", "Province", "Rue", "Ville" },
                values: new object[] { 2, "A1A 1A1", "Canada", "Québec", "777 rue de la Cegep", "Longueuil" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                columns: new[] { "AdresseID", "Courriel", "EstActive", "HeureFermeture", "HeureOuverture", "NomClinique" },
                values: new object[] { 1, "test@clinique2000.com", true, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "CliniqueA" });

            migrationBuilder.InsertData(
                table: "Cliniques",
                columns: new[] { "CliniqueID", "AdresseID", "Courriel", "EstActive", "HeureFermeture", "HeureOuverture", "NomClinique", "TempsMoyenConsultation" },
                values: new object[] { 2, 2, "Test2@test.com", true, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), "CliniqueB", 30 });

            migrationBuilder.CreateIndex(
                name: "IX_Cliniques_AdresseID",
                table: "Cliniques",
                column: "AdresseID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliniques_Adresses_AdresseID",
                table: "Cliniques",
                column: "AdresseID",
                principalTable: "Adresses",
                principalColumn: "AdresseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliniques_Adresses_AdresseID",
                table: "Cliniques");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Cliniques_AdresseID",
                table: "Cliniques");

            migrationBuilder.DeleteData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "AdresseID",
                table: "Cliniques");

            migrationBuilder.DropColumn(
                name: "Courriel",
                table: "Cliniques");

            migrationBuilder.DropColumn(
                name: "EstActive",
                table: "Cliniques");

            migrationBuilder.DropColumn(
                name: "HeureFermeture",
                table: "Cliniques");

            migrationBuilder.DropColumn(
                name: "HeureOuverture",
                table: "Cliniques");

            migrationBuilder.DropColumn(
                name: "NomClinique",
                table: "Cliniques");
        }
    }
}
