using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class modificationPatientModelPourPostAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_UserId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_UserId",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3993b53b-2c4b-4511-82eb-774b4c734b57", "744087fa-82ff-4faf-a215-6511a4bbee2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "de646d9c-5e10-4711-ac9f-e6ad779c6880", "4128ceab-4c46-4d52-890c-a37a822c16e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2ec2bf51-ad97-4422-89ac-c829d8330c03", "073256ba-0fce-4443-9fb7-38dacf8ebe47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "11290103-59da-41cc-8dea-2828c16ba605", "326c5655-58f2-4aab-bfd2-9b33c639f8c9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "286239dd-337a-4091-94d8-8bf0c2334219", "83a7addb-2dc5-4a75-bb5f-1f3bff9392e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e2595160-680d-4590-81fe-58dbfc6ca866", "c3f2785c-8e5a-47b7-9b3b-6b4fdf1ed245" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0d4a36b4-223c-4e6f-b0dc-7a390642eb07", "7b0f3a5e-5536-4f0f-a60a-fc217cb798b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d968b89d-57c8-49a5-b084-9bee18e28f00", "2edbf4a3-b7c9-4505-a707-4ac99d851afb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b9eabb8b-be6b-44e2-be8e-c793a6c0bf81", "8f408e76-dc7e-4dfc-a140-beec4e8fb88f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "74590cdb-9f3e-493b-9b2a-9113b03869c7", "2f11c226-7fda-4555-8bd7-04fb223737f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c45bca42-96f0-4ecf-b133-da84454d3333", "ffca5054-32a1-465e-9674-4825c385fbf7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "925b2dfc-54ff-4ad9-a221-bd8a67ffe461", "23407ea5-94c6-4b6d-90f5-e73a2a2c84fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fa50a01c-029c-49b5-98ab-849608dcb0b8", "27e04d20-d14a-4d8c-bfef-42d4b7cc2edb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d494ebb8-d43e-47ab-acc5-a55d3a63aaf0", "b18e5ed1-7593-47bc-ac08-ca1e6cd294ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "70832e0f-c434-404b-94f9-543470dffa02", "5359f3df-af10-4d42-9957-e380b9e4ddb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8331d285-390d-4c67-afb8-c182c6b0287f", "6b75df37-eed7-4621-91a9-a6699c42b5eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "394f5ed3-53fe-48fd-a7fd-bc8cbe407c2e", "7d6b5dd2-1967-4b58-9085-8e0cddfd069e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ae1f4ded-114f-4815-b141-4be1a44ee7a6", "7af181ab-b114-41bf-ab0c-2fba78a48d17" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a1df754c-d614-4ca4-8384-ee311eb17a92", "352880b2-8c48-4c5a-926e-74dbcd36d731" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ca559aec-4067-4267-8688-28b685bc253a", "8369777b-b8f9-448d-8045-579c1d72e1c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9db95798-e9ae-4ca4-890f-8ba97643d73b", "cb5fbc99-0d34-410f-8af3-6269e4f04bb9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "079e3451-af3d-439b-a792-04125c5c947c", "fd679fa6-ac0d-4607-9fca-95eea9c4159b" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 4, 2, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8410));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 4, 2, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8467));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 4, 2, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 4, 2, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8473));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 4, 2, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8476));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 4, 2, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 3, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8515));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 3, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8567));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 3, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8576));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 3, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8583));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 3, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8590));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 3, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8599));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 4, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8606));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 4, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8613));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 4, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 6, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8627));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 7, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8634));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 8, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 5, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8648));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 6, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8654));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 5, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8662));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 6, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 7, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 8, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8685));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 3, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 4, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8698));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 5, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8705));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 6, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8712));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 7, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8719));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 8, 12, 43, 36, 78, DateTimeKind.Local).AddTicks(8726));

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_UserId",
                table: "Patients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AspNetUsers_UserId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_UserId",
                table: "Patients");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6239d356-651d-4197-bb4c-cc11bd04b98f", "7a84dc46-05a1-4ef0-b7c3-0a29d32f4193" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "27303e47-1a0b-46d2-996a-4ed3db19471f", "ed0c770f-1438-426c-9fc8-84d20f87bd5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b6d6a724-c345-4245-9cb0-8e1551852e84", "bbf079f6-25cd-43d1-bfca-abde7dda8506" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "357ec3b1-2aa5-46fa-b7db-6dd7cb4c0aa5", "3b0777cb-3169-434d-8b9f-eb6c52380550" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ac3630fc-3933-4bfd-ac5c-c95ef0df9530", "84b87319-8018-44c7-8503-d54d2225c2b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0ecaa9ee-7189-4bc9-8d80-e3a1380fecbe", "b70e7626-008d-44b7-b6e2-81803b92752d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "462a275c-3808-432c-bac6-0a856a92d656", "c05d220c-cf6b-4b56-b2d7-a492552fdbe0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7ad31fac-118e-42a7-8913-3421d7e68056", "2991706b-71b1-4689-a8a6-8cdc9c9952a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cf40bedb-172c-478c-8799-0c74a8c8d3e7", "2745e5c2-9a5d-4628-bbcd-c09b7a187d49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "eff32a54-678e-4d40-829c-b0a4ee16ad93", "c4e12c06-4c27-4769-8e74-dfbbbdb7bb77" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6f940e00-96f9-488a-b251-a9b5171bf31e", "d1266a01-4618-4851-b746-79d8969ebfdf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1cb3eda9-76d2-4cc5-94c3-89d9a1340559", "39b48c4d-31f1-4eeb-99af-9f98d9f5835a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8d5ed624-8e58-4e22-af9f-f5fafe0f419c", "6a2b827f-1617-4582-89e6-0be7dc5b8686" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1cd2a07e-19d0-4f3f-a4b6-0978ac4c9525", "9111f3c4-c888-4f1a-9317-245f7e6a2292" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3c4f4d8d-bd2b-473c-bac5-ae8b087d4b65", "5bb3be59-d714-4414-8109-85b272b0c79e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7639b718-0186-4107-8b0a-f0553c5c6b3c", "3890101c-a11b-47bc-9bfc-a57e75132752" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1509edc3-0936-417e-aadb-8f080f6ae981", "27125e66-9a17-4ed4-8824-d4c460141936" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3a1ff8b2-a800-44af-8193-dbf49a9a59a0", "18c5dd23-d83e-422a-842e-0139e306eecd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "44a43624-e58f-442e-b5ca-b0638d069902", "bd91ad84-3c01-4664-9eaf-1d1974c7ad12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2f48c6a4-e9ad-40fc-864e-0f68a9eb670e", "a4b65562-124c-44d0-8db8-9582e8e0d12e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c2e28f82-88a3-4a53-ba1f-96d70b575b00", "c1546e81-10be-4533-8260-776dc8ce138a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6e034769-6580-4a52-a160-67c8bab6f14e", "4dd2fdce-3a57-4417-89a7-8d54d57549b0" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 4, 2, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6134));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 4, 2, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6188));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 4, 2, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6192));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 4, 2, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6194));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 4, 2, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 4, 2, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6200));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 3, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6229));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 3, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6242));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 3, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 3, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6257));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 3, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 3, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6273));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 4, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 4, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 4, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 6, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6333));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 7, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 8, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 5, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6355));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 6, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6362));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 5, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6370));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 6, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6377));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 7, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6384));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 8, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6393));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 3, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 4, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6406));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 5, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6413));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 6, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6420));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 7, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 4, 8, 11, 21, 26, 341, DateTimeKind.Local).AddTicks(6434));

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AspNetUsers_UserId",
                table: "Patients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
