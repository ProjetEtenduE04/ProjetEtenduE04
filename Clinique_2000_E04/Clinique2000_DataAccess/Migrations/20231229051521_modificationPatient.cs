using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class modificationPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreNom",
                table: "Personne",
                newName: "Prenom");

            migrationBuilder.RenameColumn(
                name: "DateDeNassance",
                table: "Patient",
                newName: "DateDeNaissance");

            migrationBuilder.AlterColumn<string>(
                name: "Prenom",
                table: "Personne",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(225)",
                oldMaxLength: 225);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Personne",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(225)",
                oldMaxLength: 225);

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Personne",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(225)",
                oldMaxLength: 225);

            migrationBuilder.AlterColumn<string>(
                name: "Courriel",
                table: "Personne",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(225)",
                oldMaxLength: 225);

            migrationBuilder.AlterColumn<string>(
                name: "NAM",
                table: "PatientACharge",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(225)",
                oldMaxLength: 225);

            migrationBuilder.AlterColumn<string>(
                name: "NAM",
                table: "Patient",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(225)",
                oldMaxLength: 225);

            migrationBuilder.AlterColumn<string>(
                name: "CodePostal",
                table: "Patient",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(225)",
                oldMaxLength: 225);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Prenom",
                table: "Personne",
                newName: "PreNom");

            migrationBuilder.RenameColumn(
                name: "DateDeNaissance",
                table: "Patient",
                newName: "DateDeNassance");

            migrationBuilder.AlterColumn<string>(
                name: "PreNom",
                table: "Personne",
                type: "nvarchar(225)",
                maxLength: 225,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Personne",
                type: "nvarchar(225)",
                maxLength: 225,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Personne",
                type: "nvarchar(225)",
                maxLength: 225,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Courriel",
                table: "Personne",
                type: "nvarchar(225)",
                maxLength: 225,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NAM",
                table: "PatientACharge",
                type: "nvarchar(225)",
                maxLength: 225,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "NAM",
                table: "Patient",
                type: "nvarchar(225)",
                maxLength: 225,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "CodePostal",
                table: "Patient",
                type: "nvarchar(225)",
                maxLength: 225,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);
        }
    }
}
