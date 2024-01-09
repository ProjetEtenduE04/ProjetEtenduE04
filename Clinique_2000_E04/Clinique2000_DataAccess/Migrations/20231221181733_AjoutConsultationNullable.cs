using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class AjoutConsultationNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_ListeAttentes_ListeAttenteID",
                table: "Consultations");

            migrationBuilder.RenameColumn(
                name: "ListeAttenteID",
                table: "Consultations",
                newName: "PlageHoraireID");

            migrationBuilder.RenameIndex(
                name: "IX_Consultations_ListeAttenteID",
                table: "Consultations",
                newName: "IX_Consultations_PlageHoraireID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HeureDateFinReele",
                table: "Consultations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HeureDateDebutReele",
                table: "Consultations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_PlagesHoraires_PlageHoraireID",
                table: "Consultations",
                column: "PlageHoraireID",
                principalTable: "PlagesHoraires",
                principalColumn: "PlageHoraireID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_PlagesHoraires_PlageHoraireID",
                table: "Consultations");

            migrationBuilder.RenameColumn(
                name: "PlageHoraireID",
                table: "Consultations",
                newName: "ListeAttenteID");

            migrationBuilder.RenameIndex(
                name: "IX_Consultations_PlageHoraireID",
                table: "Consultations",
                newName: "IX_Consultations_ListeAttenteID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HeureDateFinReele",
                table: "Consultations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HeureDateDebutReele",
                table: "Consultations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_ListeAttentes_ListeAttenteID",
                table: "Consultations",
                column: "ListeAttenteID",
                principalTable: "ListeAttentes",
                principalColumn: "ListeAttenteID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
