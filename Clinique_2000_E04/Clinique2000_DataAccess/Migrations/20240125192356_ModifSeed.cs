using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ModifSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "276bee69-feed-4df0-91f0-492b9f1ac1bf", "36205529-4996-46ff-bbe7-3dfcd7b993ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "607cd3b8-6ff7-445d-875c-2d4916c2e68e", "993ff5e4-a72a-4c5b-9189-fc07213dc9a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e06782ff-b9c5-4174-9a0e-c9b6eb317c15", "393b67f0-492d-4865-adb6-738a567ae533" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "43ad512d-4db0-431b-a55a-54e73b4f07b7", "cfa002b8-4e2d-4386-b712-15382f3929f8" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7212));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7272));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7275));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7278));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7308));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 27, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7326));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 4, new DateTime(2024, 1, 28, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7337) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 5, new DateTime(2024, 1, 29, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7347) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 30, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7358));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 6, new DateTime(2024, 1, 31, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7369) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 27, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7391));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 28, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7402));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 29, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 30, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7424));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 31, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7435));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 27, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7454));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 28, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7465));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 29, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7475));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 30, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 31, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7497));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7507));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 27, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7517));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 28, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7605));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 29, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7618));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 30, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7629));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 31, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7641));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e803d876-9481-4259-84e4-463cfc0a9253", "23b954f2-0445-4f44-82b0-dc4fa562b5ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ff574944-21a2-490e-a583-8407a5e84f65", "b13a8832-f66a-42a4-b4cc-b28830e145cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "eab43ba2-7880-4472-b367-b5cccffd9b5a", "c52ba277-05cc-4e2e-9c32-659a74a0184f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d68666d2-cb3b-4fab-a297-527226b2b54a", "d847c8b7-802e-4310-a4d8-47c189632e67" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5569));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5611));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5617));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5621));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5654));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 27, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5673));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 3, new DateTime(2024, 1, 28, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5683) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 3, new DateTime(2024, 1, 29, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5694) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 30, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5704));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 3, new DateTime(2024, 1, 31, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5715) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5725));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 27, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5735));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 28, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5757));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 29, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5769));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 30, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 31, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5789));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5799));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 27, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5809));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 28, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5819));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 29, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5829));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 30, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5840));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 31, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5852));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5862));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 27, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 28, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 29, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5893));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 30, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5903));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 31, 14, 16, 1, 634, DateTimeKind.Local).AddTicks(5913));
        }
    }
}
