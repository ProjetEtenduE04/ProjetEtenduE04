using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class AjoutPauseListeAttente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "HeurePauseDebut",
                table: "ListeAttentes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HeurePauseFin",
                table: "ListeAttentes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "29818c87-5786-4d03-b29d-c4e3edc9ebc6", "8b61f06b-9c68-44b9-b71c-eaa88c50c2eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0bb29709-7297-47c7-9bdd-68ae1b035fc6", "ba5ab82d-6204-4f39-b905-05e7187e0067" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "37af62f4-a25b-4e93-815b-a68a81e29de8", "e460726c-2e28-4826-ae9c-430b4ebb419d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b0d01cc7-ac9f-4652-823b-7ec3292ec23f", "f3212e7a-9a5a-42cb-b987-ac9af1f22f49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a280a589-76dc-44c4-aebb-7b3b19947864", "089cab71-dbad-411c-90f8-76cc4aed5978" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "61cd367f-8f14-4db0-8b89-c6e6797e91df", "820ab88a-2b4c-4708-bee8-877d4afd8d39" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cd8438f2-6414-443e-8371-a44db0017192", "53030e1c-3377-4fd6-8de3-d81de1dbf809" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1792992a-0b93-4e73-a616-37ea2265540b", "821cb811-f0a7-46e3-812c-a406800965fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bd7cf4a0-44f1-48cb-a0d1-ca14e6ce796e", "5f3f10ef-7e73-4ac4-b0cf-70d8712b82e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "79e8e4e9-39d0-4e88-9b19-3e8fd4fdb6b4", "979abe06-b138-4452-8eba-e546cb5ad070" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b72e8f49-4a23-4315-b231-2b79a1b3cc4a", "4ac5937c-8eb5-4037-a3e4-2061dfa9031b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8b33b440-710f-4da1-9e65-f26709c39e90", "ad06a236-5d07-4363-817f-4daf38eb88f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b31aebb8-c2e9-4126-851e-ca03f94a5f57", "38057c1d-ed15-45c4-918a-e22b65941a2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d3445dc3-7b74-4042-9a99-26229ea36317", "1abd5970-67c7-4c96-a404-a7e82ce17985" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "26ce4763-9e0a-4bd4-b362-a97b24dfe1cc", "c851513a-3600-4d14-81ca-5e66b8b0a4e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "19643d45-7cab-4c55-9347-b1a956bf4eaf", "e96083e7-625f-4cf3-a664-0abd094e8d9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "555282dd-7900-46eb-8e0e-8518dadf8463", "580de026-bd18-4638-bd64-1a0b3d4676be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fa8658f0-6b52-4485-a922-4b53fbe10b69", "8e85e769-e01b-47ce-ab59-94a4567d8758" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5fa0b842-66ce-4d3d-a028-8cd6d200bf66", "3ee7f272-7a0c-4589-a1d5-35ceb4312c50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8199a9dc-6e08-4cdd-a644-a4391523e353", "a94c3cfa-1022-4564-9eda-0a9cc68ef40a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2f64bd94-fe13-4210-b242-b4de2760e82d", "1e3ca02d-2684-43ee-bee8-18394b5b1571" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9019a9ad-c4e4-4090-96db-99f16a69f247", "bcd5712a-5842-416b-bf92-821a018a666c" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 13, 39, 1, 185, DateTimeKind.Local).AddTicks(9803));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 13, 39, 1, 185, DateTimeKind.Local).AddTicks(9864));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 13, 39, 1, 185, DateTimeKind.Local).AddTicks(9871));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 13, 39, 1, 185, DateTimeKind.Local).AddTicks(9875));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 13, 39, 1, 185, DateTimeKind.Local).AddTicks(9880));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 13, 39, 1, 185, DateTimeKind.Local).AddTicks(9883));

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
                value: new DateTime(2024, 3, 14, 13, 39, 1, 185, DateTimeKind.Local).AddTicks(9936));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 13, 39, 1, 185, DateTimeKind.Local).AddTicks(9961));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 13, 39, 1, 185, DateTimeKind.Local).AddTicks(9977));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 13, 39, 1, 185, DateTimeKind.Local).AddTicks(9990));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(17));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(29));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(40));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(52));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(66));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 19, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(88));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(100));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(111));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(123));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(135));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(147));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 19, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(160));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(172));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(184));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(234));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(248));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(260));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 19, 13, 39, 1, 186, DateTimeKind.Local).AddTicks(272));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeurePauseDebut",
                table: "ListeAttentes");

            migrationBuilder.DropColumn(
                name: "HeurePauseFin",
                table: "ListeAttentes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e22ce8b1-5e71-49a6-a1c2-9b27bdc874ad", "491c3703-4de2-404c-8c34-22281ea0f6f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d171784c-8285-4857-a1d5-3b155d445137", "ab9242d7-9f06-458e-940f-9a9d8f53c361" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e369ff9f-c3ed-4fc4-bf95-8ba4eeb5f65c", "0e39441a-db33-4d9c-a853-cc6d7ee4f15c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4d1aba84-1b96-4fd5-ad6a-664db92d42ca", "90a7d53e-9696-46f2-90fe-35a119be1f98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7afe4f28-ba1d-4dcc-9f18-acad307b9b11", "144f584a-c35e-4b0c-8042-d0f069abf7ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "958c7280-bf68-4cc3-8efa-6a20b6bff4bd", "acfa8713-29b3-40c7-b64c-a86ef64167c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a1c77ce3-3d88-4a4b-a20a-fa4ca19da161", "e2503c01-b43a-48b1-96e6-d343f5f56164" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0481237f-b76e-423e-93a0-20212cf54512", "a82ba049-d3ec-4014-a7d6-66c075703a69" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3c339b15-63ad-42df-ab71-9e7a72766c95", "1cd79391-ef69-4808-8090-d55ffb607eb5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c215dec1-dcb2-44fe-a232-42de32ce798f", "e242ff91-daa8-4f72-9fc4-ff1900c82845" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "29f6b179-fc85-42e2-aa0a-b0f7b069a292", "73d59b15-7a10-4178-a572-f3cdba5d4924" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "20d7e2d7-4014-4fe0-9a35-ba27d36749e1", "5a420323-de4c-4700-9c27-753892206329" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9dfdf727-2f69-4b36-aff5-6578469a6a4e", "6705555c-9e3f-474c-93a8-e97d60d3959f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1e6ac838-d312-494d-a687-ed6e89c001e9", "68526e8a-e4d6-46de-8f69-5348d42d8680" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f4115313-e7e6-405b-8e82-eec13cddc7b1", "028b3c9d-b1b9-4c13-8b13-b72e3a651431" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "124afc15-60ad-4805-a755-3a75820802ef", "48161b63-05d1-4f85-8061-49f1050b646d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9a00c420-da24-4605-84da-67a2907dea0d", "db26b2f2-cdf4-487e-bd74-2f78196c5913" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "07a995fb-33e6-41cc-87e1-e646b1070d10", "6cc2a241-5fc4-46bc-add9-85309e99d184" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6ce46846-f579-4ae2-9cc9-54595e964265", "56916f95-c2d4-4377-9855-be6e003c3518" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dac81318-2399-43f8-b263-d7229112b0d9", "6aa4b17f-5c06-444c-a264-995619f38252" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "65a2ea64-9c15-474c-acc8-cf3935fd2b45", "975aba3f-457c-4737-b4b5-a99ae7ae6154" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d6f2fa45-9b90-42a3-b99f-b2a61a6609ac", "893b5ebe-a57a-46ad-a8d3-fd6a2cf6a9db" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 3, 12, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3825));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 3, 12, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3872));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 3, 12, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3875));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 3, 12, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3878));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 3, 12, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3883));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 3, 12, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3885));

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 1,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 8, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 2,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 8, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 3,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 9, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 4,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 9, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 5,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 9, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 6,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 9, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 7,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 8,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 9,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 10, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 10,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 10, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 11,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 11, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 12,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 11, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 13,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 11, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 14,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 11, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 15,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 12, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 16,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 12, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 17,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 13, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 18,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 13, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 19,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 13, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 20,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 13, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 21,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 14, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 22,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 13, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 14, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 23,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 15, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 15, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Consultations",
                keyColumn: "ConsultationID",
                keyValue: 24,
                columns: new[] { "HeureDateDebutPrevue", "HeureDateFinPrevue" },
                values: new object[] { new DateTime(2024, 3, 13, 16, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 17, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3931));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3939));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3947));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3955));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3964));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3979));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(4036));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(4043));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(4051));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(4062));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(4072));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(4079));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(4087));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(4094));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(4103));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(4125));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(4133));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(4141));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(4148));

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 1,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 13, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 8, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 2,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 13, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 9, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 3,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 13, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 9, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 4,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 13, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 5,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 13, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 10, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 6,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 13, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 11, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 7,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 13, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 11, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 8,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 13, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 12, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 9,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 13, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 12, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 10,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 13, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 13, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 11,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 13, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 13, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 12,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 13, 17, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 13, 17, 30, 0, 0, DateTimeKind.Local) });
        }
    }
}
