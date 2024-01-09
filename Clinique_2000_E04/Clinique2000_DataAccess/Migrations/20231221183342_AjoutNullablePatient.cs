using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class AjoutNullablePatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Patient_PatientID",
                table: "Consultations");

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "Consultations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Patient_PatientID",
                table: "Consultations",
                column: "PatientID",
                principalTable: "Patient",
                principalColumn: "PersonneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Patient_PatientID",
                table: "Consultations");

            migrationBuilder.AlterColumn<int>(
                name: "PatientID",
                table: "Consultations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Patient_PatientID",
                table: "Consultations",
                column: "PatientID",
                principalTable: "Patient",
                principalColumn: "PersonneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
