using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class modiifierSeedClinique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9ee17560-2cd0-487d-9d58-9e7f06489ec1", "9588f4b6-2176-4f98-b01b-34d8c148d773" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 1, 21, 2, 38, 51, 9, DateTimeKind.Local).AddTicks(3128));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 1, 21, 2, 38, 51, 9, DateTimeKind.Local).AddTicks(3175));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                column: "DateCreation",
                value: new DateTime(2024, 1, 20, 21, 18, 49, 333, DateTimeKind.Local).AddTicks(7547));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 1, 20, 21, 18, 49, 333, DateTimeKind.Local).AddTicks(7592));
        }
    }
}
