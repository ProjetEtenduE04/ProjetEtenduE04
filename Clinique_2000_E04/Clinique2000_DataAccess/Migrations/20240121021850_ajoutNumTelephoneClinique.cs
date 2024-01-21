using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ajoutNumTelephoneClinique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumTelephone",
                table: "Cliniques",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f04a311c-57fd-44a4-bd31-432aba0faf92", "acff0937-ef93-492e-9283-4efa70e190e6" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                columns: new[] { "DateCreation", "NumTelephone" },
                values: new object[] { new DateTime(2024, 1, 20, 21, 18, 49, 333, DateTimeKind.Local).AddTicks(7547), "(438) 333-5555" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                columns: new[] { "DateCreation", "NumTelephone" },
                values: new object[] { new DateTime(2024, 1, 20, 21, 18, 49, 333, DateTimeKind.Local).AddTicks(7592), "(438) 333-7777" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumTelephone",
                table: "Cliniques");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e9ba5ecc-dbf6-46f0-a246-c891e8ef7404", "7b0dfa67-7306-4d0c-ba37-70d681443184" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 1, 20, 20, 12, 11, 465, DateTimeKind.Local).AddTicks(5929));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 1, 20, 20, 12, 11, 465, DateTimeKind.Local).AddTicks(5981));
        }
    }
}
