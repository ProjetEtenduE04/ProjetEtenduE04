using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ajoutPatientPatientACharge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    PersonneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    PreNom = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    Courriel = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.PersonneId);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PersonneId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    NAM = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    MotDePasse = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    MotDePasseConfirmation = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    DateDeNassance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PersonneId);
                    table.ForeignKey(
                        name: "FK_Patient_Personne_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personne",
                        principalColumn: "PersonneId");
                });

            migrationBuilder.CreateTable(
                name: "PatientACharge",
                columns: table => new
                {
                    PersonneId = table.Column<int>(type: "int", nullable: false),
                    PatientAChargeId = table.Column<int>(type: "int", nullable: false),
                    NAM = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    DateDeNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PatientPersonneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientACharge", x => x.PersonneId);
                    table.ForeignKey(
                        name: "FK_PatientACharge_Patient_PatientPersonneId",
                        column: x => x.PatientPersonneId,
                        principalTable: "Patient",
                        principalColumn: "PersonneId");
                    table.ForeignKey(
                        name: "FK_PatientACharge_Personne_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personne",
                        principalColumn: "PersonneId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientACharge_PatientPersonneId",
                table: "PatientACharge",
                column: "PatientPersonneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientACharge");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Personne");
        }
    }
}
