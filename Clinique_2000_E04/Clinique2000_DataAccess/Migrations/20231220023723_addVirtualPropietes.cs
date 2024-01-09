using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class addVirtualPropietes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDisponible",
                table: "ListeAttentes",
                newName: "IsOuverte");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HeureOuverture",
                table: "ListeAttentes",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "HeureFermeture",
                table: "ListeAttentes",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "CliniqueID",
                table: "ListeAttentes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "dureeConsultationMinutes",
                table: "ListeAttentes",
                type: "int",
                nullable: true);

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

           

           

           

            migrationBuilder.CreateIndex(
                name: "IX_ListeAttentes_CliniqueID",
                table: "ListeAttentes",
                column: "CliniqueID");

            migrationBuilder.CreateIndex(
                name: "IX_PlagesHoraires_ListeAttenteID",
                table: "PlagesHoraires",
                column: "ListeAttenteID");

            migrationBuilder.AddForeignKey(
                name: "FK_ListeAttentes_Cliniques_CliniqueID",
                table: "ListeAttentes",
                column: "CliniqueID",
                principalTable: "Cliniques",
                principalColumn: "CliniqueID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListeAttentes_Cliniques_CliniqueID",
                table: "ListeAttentes");

            migrationBuilder.DropTable(
                name: "Cliniques");

           
           
            migrationBuilder.DropTable(
                name: "PlagesHoraires");

           

           

            migrationBuilder.DropIndex(
                name: "IX_ListeAttentes_CliniqueID",
                table: "ListeAttentes");

            migrationBuilder.DropColumn(
                name: "CliniqueID",
                table: "ListeAttentes");

            migrationBuilder.DropColumn(
                name: "dureeConsultationMinutes",
                table: "ListeAttentes");

            migrationBuilder.RenameColumn(
                name: "IsOuverte",
                table: "ListeAttentes",
                newName: "IsDisponible");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HeureOuverture",
                table: "ListeAttentes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HeureFermeture",
                table: "ListeAttentes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }
    }
}
