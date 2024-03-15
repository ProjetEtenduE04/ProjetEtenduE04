using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class UpdateCritique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Critiques");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b8eebcc9-9b07-4b95-8616-64674f09f81e", "f4c85d5a-b9f2-4ccd-93b6-579d33c08ac1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "076f4694-2b80-4388-adbc-3681c53df12b", "887555f8-894d-4731-b5b1-fa4142f7ba3e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "35cd32d8-14d4-409b-824c-5f7355b1b289", "83b2935e-48ba-45ce-b6d5-55ac97cb8405" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "457af4c4-6ea9-43b4-9815-afc516d0a939", "bc5cc269-3591-4c77-9644-25fd95a44b8f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9f9524de-1644-432b-b21c-a431969ee56f", "c9e25335-f9c7-4b12-9d6f-d8e3fefa1fc8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "28373810-60c0-4f46-ba2a-62900fdd08ff", "2e1914c6-76c0-4ab4-a45c-3222d14a0b38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3e4d5779-d399-4fe4-9e86-af6cccabb5d6", "412efce1-9c62-4168-b807-aeaba4553f97" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6f5425b1-e1d5-4f49-b901-060e2300af36", "21409c56-345a-44cb-941f-4ad6f9d116d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a259cf9c-c2c3-41b0-9bdf-7ef68a53cdf4", "85a1fccf-d887-4bc6-86af-d40af7129922" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b238a405-ba20-460b-b8a6-abe2b9578d2f", "aafae68f-8b69-4455-be50-a6739ae60e26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2ad47d19-ef74-41e1-9d76-9be582782295", "262f1c99-3dba-4f31-9f8e-321c1a3c5473" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "eb7063d6-9057-44f8-9584-a89b5e7d917e", "15484c74-4624-4648-9323-10758fac3ddb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "94cbdf74-72dc-4f69-9384-06d29ec1771b", "251fc61f-02ba-4a5c-b167-33ab96d5e36e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9b363c95-f347-41e6-97a8-390571469b97", "255a0af4-e76a-4fef-895a-2abc82b5a76c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3ef7c512-ab40-405f-83e6-c1e382edbd06", "0903c3a6-5f3a-4247-96a1-dbc8eb8747fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "46eb7929-9e23-4908-98ed-adc3f05e8bee", "9a7f1c8e-479e-43dd-84e1-7e7e08e7f899" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f8169183-ad6b-42cf-bdf2-42f38f6555ed", "3285aa8c-44f9-4cb1-b26b-ba9af3065544" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e61377af-5914-48d0-a584-0096b2788028", "efa09c56-04c4-4bb9-a566-db19e079974a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f251656d-53e7-468b-9a24-b20094150c74", "3406860a-fd5a-4074-8605-64f9ea4d4e39" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "040838de-5e8d-4d0e-b118-04c043ad0ba9", "65f46085-f97f-45ea-8376-9ad4f4c96346" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "90b28359-d3cd-4d86-ad3c-fbb40164d8ca", "6bae7e68-562a-4e4b-a87a-53458d75758e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b599eabd-1b71-41b6-b365-88a3dc7e3dd3", "e1cdb95a-69bc-417c-b270-5a1903ffa357" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 3, 15, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 3, 15, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(4938));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 3, 15, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(4941));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 3, 15, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(4943));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 3, 15, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(4946));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 3, 15, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 1,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 8, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 2,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 8, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 3,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 9, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 4,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 9, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 5,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 9, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 6,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 9, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 7,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 8,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 9,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 10, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 10,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 10, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 11,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 11, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 12,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 11, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 13,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 11, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 14,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 11, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 15,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 12, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 16,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 12, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 17,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 13, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 18,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 13, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 19,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 13, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 20,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 13, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 21,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 14, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 22,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 14, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 23,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 15, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 24,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 16, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(4982));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5004));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5013));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5021));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5079));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5087));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5095));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 19, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5105));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 20, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5114));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 21, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5122));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5132));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 19, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5140));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5148));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 19, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5156));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 20, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5164));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 21, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5174));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5182));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5198));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 19, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5206));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 20, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5215));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 21, 9, 17, 1, 697, DateTimeKind.Local).AddTicks(5223));

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 1,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 16, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 8, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 2,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 16, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 9, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 3,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 16, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 9, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 4,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 16, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 5,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 16, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 10, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 6,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 16, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 11, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 7,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 16, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 11, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 8,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 16, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 12, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 9,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 16, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 12, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 10,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 16, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 13, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 11,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 16, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 13, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 12,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 16, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 16, 17, 30, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "Critiques",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4f836738-a7b2-4910-8de8-5932757ccce6", "d46f4bd6-d23e-4c21-b90d-94ce4fed23e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "904476cd-0f9b-4016-9d3d-4eea606cdbf0", "a34230f7-917a-48ac-9619-4d58d597e054" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "43ad896f-0942-4aaa-aaaf-13913901c4c6", "9e944bbe-0a6e-4263-b46e-c25490d4ff07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5eef1e2c-14fa-4163-a701-34d314b1dd7d", "bcb3c103-c75b-412e-b681-2f4eba73b616" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "159ca1c1-5b72-4215-a799-402322ce9910", "3fcb6490-08fa-4701-a765-426a75a3658a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "318c24a5-2f7c-45eb-b395-a4cca060be62", "65fafa59-e997-4c63-9e77-7c1c7d6c1873" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "61658bae-b9cc-42b7-8e8b-12f1d6657392", "823adbba-45dd-4209-bb66-69e28356fa4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1cc1dc6a-7305-477c-89fa-3bc5653af564", "504b3206-915c-45a4-980b-49054d4ddfb7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1b5e94b5-c224-464b-b200-8c9cae980e04", "3ea509ab-ae54-4fd8-9065-c58724e590e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a1ea234f-6ec4-47ff-bd6a-24a5171e206d", "7bc4a9a2-449a-4979-9da7-edbdd03d0f26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0fcd14fe-add3-4785-aeac-b39f7e18b4b0", "ac9abb2e-e770-4a47-9855-42e180dffefe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fe47e9a4-c51d-4c84-aa45-9437de115d04", "fb60279a-b659-4f23-b671-9dc4d4b315bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3f4d334b-1ac9-47c7-82dd-ca3b9de878d8", "f50a6d21-8884-4977-9247-1350a28a8df9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d5975847-eb54-4f5f-865b-c6079f366229", "cc7a3073-d7fc-4100-963e-72a19f1be235" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "19b8df1b-9564-44cf-843d-797ad932220b", "af3bacc0-c283-487e-adf6-49d312c92a8a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fc6f5d0b-d8f3-4e7d-bbeb-36400f8a4411", "37a99c14-9aca-4e65-8126-04b72c28dd45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c6f401af-020d-4359-bd24-00b687dc6532", "0bfd32de-9631-4daa-b9d2-2905fd2328d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ec96ed2d-3eb9-4ded-80c4-473db5191aab", "7864a6a2-edf0-46f5-b3d9-257cf860dd1e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aa34436b-8e21-44c6-a5e8-61abc747508b", "fef7452b-e77e-47a4-812c-0d2457f0ca4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c8e9bb38-1c4e-48b3-bd5a-764f72da4fd6", "10cd5735-e73a-4574-8860-bf82e72d0fb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b87a03ef-e197-43e8-be51-0d03fa675911", "8ef3efa9-660f-41c8-9bf8-3835d555587a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f6316819-7324-4f9a-9e17-87ce961af258", "681c3b1a-5ae6-4bdb-9050-85973e48cc18" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2070));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2115));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2122));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2124));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2169));

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 1,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 8, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 2,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 8, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 3,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 9, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 4,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 9, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 5,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 9, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 6,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 9, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 7,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 8,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 9,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 10, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 10,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 10, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 11,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 11, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 12,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 11, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 13,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 11, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 14,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 11, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 15,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 12, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 16,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 12, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 17,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 13, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 18,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 13, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 19,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 13, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 20,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 13, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 21,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 14, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 22,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 14, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 23,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 15, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 24,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 14, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2261));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2303));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2310));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2319));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 19, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2335));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2359));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 19, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2385));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2401));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2409));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2425));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 19, 13, 57, 32, 189, DateTimeKind.Local).AddTicks(2434));

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 1,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 14, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 8, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 2,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 14, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 9, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 3,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 14, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 9, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 4,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 14, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 5,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 14, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 10, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 6,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 14, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 11, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 7,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 14, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 11, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 8,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 14, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 12, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 9,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 14, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 12, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 10,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 14, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 13, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 11,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 14, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 13, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 12,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 14, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 14, 17, 30, 0, 0, DateTimeKind.Local) });
        }
    }
}
