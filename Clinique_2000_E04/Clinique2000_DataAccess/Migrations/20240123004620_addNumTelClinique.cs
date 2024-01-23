using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class addNumTelClinique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Cliniques",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "Cliniques",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumTelephone",
                table: "Cliniques",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                columns: new[] { "DateCreation", "NumTelephone" },
                values: new object[] { new DateTime(2024, 1, 22, 19, 46, 20, 152, DateTimeKind.Local).AddTicks(8882), "(438) 333-7777" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                columns: new[] { "DateCreation", "NumTelephone" },
                values: new object[] { new DateTime(2024, 1, 22, 19, 46, 20, 152, DateTimeKind.Local).AddTicks(8929), "(438) 333-555" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "Cliniques");

            migrationBuilder.DropColumn(
                name: "DateModification",
                table: "Cliniques");

            migrationBuilder.DropColumn(
                name: "NumTelephone",
                table: "Cliniques");
        }
    }
}
