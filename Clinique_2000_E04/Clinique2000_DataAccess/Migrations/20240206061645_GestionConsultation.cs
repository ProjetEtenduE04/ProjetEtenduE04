using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class GestionConsultation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_PlagesHoraires_PlageHoraireID",
                table: "Consultations");

            migrationBuilder.AlterColumn<int>(
                name: "PlageHoraireID",
                table: "Consultations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedecinEmployeCliniqueID",
                table: "Consultations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedecinId",
                table: "Consultations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0ee467ec-7b5c-47fb-a95d-c038ead3d6d9", "43bf3958-57b0-4841-8930-62f6326ac354" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a7ec4da0-0bec-4aa0-9ff1-477c77a8c760", "2db9b496-f095-41ef-afc5-06fd1bc360fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6c3d6cc8-dab5-43e1-bc3d-e5e42f698f2e", "00a8cbcc-9444-4ba0-9213-41859d485151" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fdf4434e-7359-4539-882f-9b4e4ecba350", "fe8567ad-56d8-477f-8e82-ce8f9b5d26de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cb7a4fed-2753-4b16-97af-91fdf29dc484", "31a06f24-d6c0-45c8-bbb8-3448f0428013" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2245b057-3395-4ff8-8e7b-8b969fe0603b", "266a7106-f837-42de-86dd-aa505e2322dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "100aeb50-5007-425c-bb14-eb98f7c7d4e8", "83a9d913-ba94-4cd4-810a-f0c2bba26459" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0557baa1-7b2c-4d56-be6c-a9be1a499e06", "b59eb9cb-982c-47ce-a035-2e4aaec5820f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1cb14667-5d80-462c-97ca-7aac6d008b55", "f8bee35d-04a1-4d23-8a23-a2a45cf0b80c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7525da6e-9900-43d5-9b5a-6212b9657691", "980b71e3-7e4f-4094-aafa-ef6b14fac84b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e2a003d0-24bb-4483-95c8-54abdb7b5dc7", "253ebaae-cc63-40df-8d8a-37b60267f94c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "112625dc-905f-4568-936d-2cf2b5c370f4", "3b9624e5-4d5d-4b19-b4f0-27eb27315f23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c03ad9ce-182d-4a83-be15-0d38ebd66a09", "963bc441-923b-465f-bae5-4c8c876d98f2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "658baa83-7791-4b2b-b8cc-b1b6d78f56ba", "cfae255a-7050-47f4-8d47-bcf122f42452" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "34e39512-43aa-4258-be26-258da8040359", "f26957d3-1c28-4b48-8e40-aa9e90572664" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ce8fccba-24e4-4d07-8b7f-de18981696a4", "f6f95ee3-d168-41f3-9f24-6e0d9d9fab09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f84ef667-37f2-465d-a189-468a6d7ac957", "e9b64930-4151-457c-a89e-6e0944c7e41b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8cfb344c-ed3b-4a9e-b1a9-aeeffd142e89", "5ccd798e-f098-4d47-bab6-d8c9a482b13e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "73b89820-57c5-4f32-976a-ec2f661d7492", "bc3b7587-f3b0-45d9-89cd-34e1822bd4c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9eadd0e0-df26-4cf6-b875-b12308fa2593", "6ebc3cb3-d0e7-4787-a775-9fa4ba0516ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "491ee396-52ce-4be2-9362-6c2f975e9ef5", "95a27541-882f-4476-be5e-03b570974ba6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "60287a83-b21b-488c-bfd5-d6c9eeeb635c", "26d7406f-b997-4aa3-bf09-7ad65fd961c0" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 2, 6, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4144));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 2, 6, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4176));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 2, 6, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4179));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 2, 6, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4183));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 2, 6, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 2, 6, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4189));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 7, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4204));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 7, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4214));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 7, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 7, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4226));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 7, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4235));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 7, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4241));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 8, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4247));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 8, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4252));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 8, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 10, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4266));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 11, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4272));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 12, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4277));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 9, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4283));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 10, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4288));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 9, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4297));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 10, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4304));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 11, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 12, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 7, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 8, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4331));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 9, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 10, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 11, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4377));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 12, 1, 16, 44, 761, DateTimeKind.Local).AddTicks(4383));

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 1,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 7, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 7, 8, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 2,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 7, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 7, 9, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 3,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 7, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 7, 9, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 4,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 7, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 7, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 5,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 7, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 7, 10, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 6,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 7, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 7, 11, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 7,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 7, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 7, 11, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 8,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 7, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 7, 12, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 9,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 7, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 7, 12, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 10,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 7, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 7, 13, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 11,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 7, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 7, 13, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_MedecinEmployeCliniqueID",
                table: "Consultations",
                column: "MedecinEmployeCliniqueID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_EmployesClinique_MedecinEmployeCliniqueID",
                table: "Consultations",
                column: "MedecinEmployeCliniqueID",
                principalTable: "EmployesClinique",
                principalColumn: "EmployeCliniqueID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_PlagesHoraires_PlageHoraireID",
                table: "Consultations",
                column: "PlageHoraireID",
                principalTable: "PlagesHoraires",
                principalColumn: "PlageHoraireID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_EmployesClinique_MedecinEmployeCliniqueID",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_PlagesHoraires_PlageHoraireID",
                table: "Consultations");

            migrationBuilder.DropIndex(
                name: "IX_Consultations_MedecinEmployeCliniqueID",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "MedecinEmployeCliniqueID",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "MedecinId",
                table: "Consultations");

            migrationBuilder.AlterColumn<int>(
                name: "PlageHoraireID",
                table: "Consultations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "93fd2bd2-114c-41fb-a476-48d745701d3d", "808f5212-6c6c-4de4-9a9a-fc4f4033a37a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "23b94f1e-1e90-4c08-bb93-46fb17dafa63", "cf35f9f9-72e0-440a-b2be-3c9c46c92bec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "77e61ed9-5495-4af6-9cfa-af353fc66ca7", "2e95c902-9694-4b1c-853e-028af6a14648" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4ac40735-d2df-4022-93f9-f9299cdd8782", "059dc0bf-7a3b-40a7-86f0-c4371fd658d8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8fe6c3f3-2f73-4e29-9430-abc1978a5dcb", "52d0049b-906d-45e6-90c0-2dc86093a419" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3fa4fc09-fcd3-400d-ab4e-89fe558474cc", "1fed69a0-1bb4-418d-9ab3-9214777d76b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e2b05dcf-9f81-4b86-a816-151fff4ed03d", "f8a17410-e0c1-470c-8956-4e8ba3dc1b78" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0d0d9ac4-ab82-4985-ace3-c10e9dc2448c", "3b189541-fbb8-4384-8955-63f6801fd724" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "70f3d77c-8cb2-4a9c-88ab-5f7ebb90e1f5", "e751c494-b0ae-4332-8d6f-be41cd1b987a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "603b726f-43ea-4255-a688-3dee2e3decf8", "69a1a452-52f2-4b0c-9000-f6bebab9f3af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5ed65810-ddf7-45b2-89d4-eb23df479714", "2274492b-db58-426b-ac74-a28af06ad758" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4167729f-6c50-4ba8-9a46-ed47dddf638c", "5f2c5b12-861c-4f05-bcfd-e2506a1fe2dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "79c1454a-0aa4-45d0-8ab7-3cf6a105da65", "0291ec7b-3405-4a87-94c0-2be18a4d3de8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6e51709c-072c-4fbb-b566-afbe8fa369a0", "5b3aa932-ba45-4e9f-a380-fe57bf0b4cd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e443852c-0043-46a9-94af-fcadeb4e30b7", "cbb3b143-07f8-40a0-9e34-40faa2067537" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "95140f41-a0ed-4e7d-b09e-7f5e8200d6dd", "41aed776-b338-4c57-b0fb-6c64b4e7b34f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "99fd733a-c377-47fc-a138-70590a104efc", "e66ee2e5-f732-43eb-b02f-31814ab45aa8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4f880311-970a-453d-9bb3-950b399c8ec9", "261252a7-802c-402c-985f-8b31688d8c51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4997b95e-4473-49e4-9103-178e661778d9", "b7598590-e27c-4444-8cf7-cacd9f046059" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "54870e36-b344-4542-9e55-689b3f657602", "162d45ef-2a2b-4a55-9d92-dd53718e3ddd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8cabfdeb-d2d5-4c4e-a5ef-6d1f10fc0a58", "0bf47217-c6a5-432a-b3a6-2541affe351d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ff0bed5a-30c5-49cb-8592-cb11bd674d2f", "49c04fc4-8c16-4dbb-9d1d-5833cf153d19" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 2, 2, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 2, 2, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9587));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 2, 2, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9590));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 2, 2, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9592));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 2, 2, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9595));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 2, 2, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9597));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 3, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9619));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 3, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9627));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 3, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9633));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 3, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9670));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 3, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9676));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 3, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9682));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 4, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9688));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 4, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9696));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 4, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9702));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 6, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9708));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 7, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 8, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9719));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 5, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 6, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9729));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 5, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9734));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 6, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 7, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9746));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 8, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9753));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 3, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9758));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 4, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9763));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 5, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9769));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 6, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9774));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 7, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9779));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 8, 0, 48, 9, 782, DateTimeKind.Local).AddTicks(9785));

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 1,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 3, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 3, 8, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 2,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 3, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 3, 9, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 3,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 3, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 3, 9, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 4,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 3, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 3, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 5,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 3, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 3, 10, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 6,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 3, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 3, 11, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 7,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 3, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 3, 11, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 8,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 3, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 3, 12, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 9,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 3, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 3, 12, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 10,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 3, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 3, 13, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 11,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 3, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 3, 13, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_PlagesHoraires_PlageHoraireID",
                table: "Consultations",
                column: "PlageHoraireID",
                principalTable: "PlagesHoraires",
                principalColumn: "PlageHoraireID");
        }
    }
}
