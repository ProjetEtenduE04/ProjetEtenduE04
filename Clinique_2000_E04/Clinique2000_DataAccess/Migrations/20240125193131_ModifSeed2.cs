using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ModifSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2eb44662-b782-41be-a95c-f3c7c0ca8e7f", "291589e1-601d-4682-83e7-dac1cc3c4c8d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ecdcfe60-6fee-429a-8d1a-bfcff43e0c26", "2ac9835c-db5d-4531-a044-4f9890472e79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "29b12e5a-b3fb-4bd4-a719-98da77eb1e4b", "360ea793-9808-4452-9d04-ab4aac0c08a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a26870e6-47a2-4823-9201-1fda4dee386a", "9553ffc9-e8cc-43aa-8157-10e9257f2fc9" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5244));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5287));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5293));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5296));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 1, new DateTime(2024, 1, 26, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5335) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 2, new DateTime(2024, 1, 26, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5353) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 3, new DateTime(2024, 1, 26, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5366) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 4, new DateTime(2024, 1, 26, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5377) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                columns: new[] { "CliniqueID", "DateEffectivite", "IsOuverte" },
                values: new object[] { 5, new DateTime(2024, 1, 26, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5388), true });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                columns: new[] { "DateEffectivite", "IsOuverte" },
                values: new object[] { new DateTime(2024, 1, 26, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5400), true });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 27, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5421));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 28, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 29, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5443));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 30, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5453));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 31, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5463));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5473));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 27, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5483));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 28, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5493));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 29, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5503));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 30, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5513));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 31, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5524));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5535));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 27, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5545));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 28, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5555));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 29, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5565));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 30, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5575));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 31, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5585));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 3, new DateTime(2024, 1, 26, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7308) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 3, new DateTime(2024, 1, 27, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7326) });

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
                columns: new[] { "CliniqueID", "DateEffectivite", "IsOuverte" },
                values: new object[] { 3, new DateTime(2024, 1, 30, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7358), false });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                columns: new[] { "DateEffectivite", "IsOuverte" },
                values: new object[] { new DateTime(2024, 1, 31, 14, 23, 55, 274, DateTimeKind.Local).AddTicks(7369), false });

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
    }
}
