using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ModifSeedPatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0b3e40cf-51a7-4fb1-878d-0f898a587f22", "3563323d-1b28-4504-8c26-b1fc1058706c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9238c912-c4cc-4e37-9f45-e2664a798768", "6c7190b5-68ba-4646-ac93-ef6f39253e61" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d7dc2110-9041-4f50-a674-fe57dc22417b", "3751e48b-1458-4818-995c-867bd4e5f5d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "123293d6-09ad-40db-8f22-56a8724ee307", "6c25c028-b9ae-4b88-b67d-a3ce814d60bb" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(654));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(695));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(703));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(706));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 1, 25, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(709));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(735));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(752));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(766));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(777));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(788));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(800));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 1, new DateTime(2024, 1, 27, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(810) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 2, new DateTime(2024, 1, 27, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(821) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 3, new DateTime(2024, 1, 27, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(830) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 29, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(842));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 30, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(852));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 31, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(862));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 28, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 6, new DateTime(2024, 1, 29, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(883) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 1, new DateTime(2024, 1, 28, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(892) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 29, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(902));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 30, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(994));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 31, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(1009));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 27, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(1030));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 28, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(1041));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 29, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(1051));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 30, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(1061));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 31, 15, 15, 34, 687, DateTimeKind.Local).AddTicks(1072));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                columns: new[] { "CodePostal", "Genre", "NAM", "Nom", "Prenom" },
                values: new object[] { "J4J 1Z4", "Masculin", "EASC 2342 4332", "Eastwood", "Clint" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                columns: new[] { "CodePostal", "Genre", "NAM", "Nom", "Prenom" },
                values: new object[] { "J4J 1V2", "Féminine", "BLUE 4232 4332", "Blunt", "Emily" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3,
                columns: new[] { "CodePostal", "Genre", "NAM", "Nom", "Prenom" },
                values: new object[] { "J4J 1G4", "Masculin", "MARB 3244 2233", "Brando", "Marlon" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 4,
                columns: new[] { "CodePostal", "Genre", "NAM", "Nom", "Prenom" },
                values: new object[] { "J4J 1H6", "Féminine", "PORT 3443 3433", "Portman", "Natalie" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5335));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5353));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5366));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5377));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5388));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 1, 26, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 4, new DateTime(2024, 1, 26, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5411) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 4, new DateTime(2024, 1, 27, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5421) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 4, new DateTime(2024, 1, 28, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5431) });

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
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 5, new DateTime(2024, 1, 27, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5483) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                columns: new[] { "CliniqueID", "DateEffectivite" },
                values: new object[] { 5, new DateTime(2024, 1, 28, 14, 31, 29, 992, DateTimeKind.Local).AddTicks(5493) });

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

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                columns: new[] { "CodePostal", "Genre", "NAM", "Nom", "Prenom" },
                values: new object[] { "A1A 1A1", "Genre1", "NAM1", "Patient1Nom", "Patient1Prenom" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                columns: new[] { "CodePostal", "Genre", "NAM", "Nom", "Prenom" },
                values: new object[] { "B2B 2B2", "Genre2", "NAM2", "Patient2Nom", "Patient2Prenom" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 3,
                columns: new[] { "CodePostal", "Genre", "NAM", "Nom", "Prenom" },
                values: new object[] { "C3C 3C3", "Genre3", "NAM3", "Patient3Nom", "Patient3Prenom" });

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 4,
                columns: new[] { "CodePostal", "Genre", "NAM", "Nom", "Prenom" },
                values: new object[] { "D4D 4D4", "Genre4", "NAM4", "Patient4Nom", "Patient4Prenom" });
        }
    }
}
