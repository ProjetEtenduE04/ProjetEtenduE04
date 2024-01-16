using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class migrationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliniques",
                columns: table => new
                {
                    CliniqueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TempsMoyenConsultation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliniques", x => x.CliniqueID);
                });

            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    PersonneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Courriel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.PersonneId);
                });

            migrationBuilder.CreateTable(
                name: "ListeAttentes",
                columns: table => new
                {
                    ListeAttenteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsOuverte = table.Column<bool>(type: "bit", nullable: false),
                    DateEffectivite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureOuverture = table.Column<TimeSpan>(type: "time", nullable: false),
                    HeureFermeture = table.Column<TimeSpan>(type: "time", nullable: false),
                    NbMedecinsDispo = table.Column<int>(type: "int", nullable: false),
                    DureeConsultationMinutes = table.Column<int>(type: "int", nullable: true),
                    CliniqueID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListeAttentes", x => x.ListeAttenteID);
                    table.ForeignKey(
                        name: "FK_ListeAttentes_Cliniques_CliniqueID",
                        column: x => x.CliniqueID,
                        principalTable: "Cliniques",
                        principalColumn: "CliniqueID",
                        onDelete: ReferentialAction.Cascade);
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
                    DateDeNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ConsultationId = table.Column<int>(type: "int", nullable: false)
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
                name: "PlagesHoraires",
                columns: table => new
                {
                    PlageHoraireID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeureDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListeAttenteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlagesHoraires", x => x.PlageHoraireID);
                    table.ForeignKey(
                        name: "FK_PlagesHoraires_ListeAttentes_ListeAttenteID",
                        column: x => x.ListeAttenteID,
                        principalTable: "ListeAttentes",
                        principalColumn: "ListeAttenteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientACharge",
                columns: table => new
                {
                    PersonneId = table.Column<int>(type: "int", nullable: false),
                    PatientAChargeId = table.Column<int>(type: "int", nullable: false),
                    NAM = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    ConsultationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeureDateDebutPrevue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureDateFinPrevue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureDateDebutReele = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HeureDateFinReele = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatutConsultation = table.Column<int>(type: "int", nullable: false),
                    PlageHoraireID = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.ConsultationID);
                    table.ForeignKey(
                        name: "FK_Consultations_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PersonneId");
                    table.ForeignKey(
                        name: "FK_Consultations_PlagesHoraires_PlageHoraireID",
                        column: x => x.PlageHoraireID,
                        principalTable: "PlagesHoraires",
                        principalColumn: "PlageHoraireID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_PatientID",
                table: "Consultations",
                column: "PatientID",
                unique: true,
                filter: "[PatientID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_PlageHoraireID",
                table: "Consultations",
                column: "PlageHoraireID");

            migrationBuilder.CreateIndex(
                name: "IX_ListeAttentes_CliniqueID",
                table: "ListeAttentes",
                column: "CliniqueID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientACharge_PatientPersonneId",
                table: "PatientACharge",
                column: "PatientPersonneId");

            migrationBuilder.CreateIndex(
                name: "IX_PlagesHoraires_ListeAttenteID",
                table: "PlagesHoraires",
                column: "ListeAttenteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "PatientACharge");

            migrationBuilder.DropTable(
                name: "PlagesHoraires");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "ListeAttentes");

            migrationBuilder.DropTable(
                name: "Personne");

            migrationBuilder.DropTable(
                name: "Cliniques");
        }
    }
}
