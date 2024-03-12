using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class MAJCliniqueRefusee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployesClinique_CliniqueRefusees_CliniqueRefuseeCliniqueID",
                table: "EmployesClinique");

            migrationBuilder.DropForeignKey(
                name: "FK_ListeAttentes_CliniqueRefusees_CliniqueRefuseeCliniqueID",
                table: "ListeAttentes");

            migrationBuilder.RenameColumn(
                name: "CliniqueRefuseeCliniqueID",
                table: "ListeAttentes",
                newName: "CliniqueRefuseeID");

            migrationBuilder.RenameIndex(
                name: "IX_ListeAttentes_CliniqueRefuseeCliniqueID",
                table: "ListeAttentes",
                newName: "IX_ListeAttentes_CliniqueRefuseeID");

            migrationBuilder.RenameColumn(
                name: "CliniqueRefuseeCliniqueID",
                table: "EmployesClinique",
                newName: "CliniqueRefuseeID");

            migrationBuilder.RenameIndex(
                name: "IX_EmployesClinique_CliniqueRefuseeCliniqueID",
                table: "EmployesClinique",
                newName: "IX_EmployesClinique_CliniqueRefuseeID");

            migrationBuilder.RenameColumn(
                name: "CliniqueID",
                table: "CliniqueRefusees",
                newName: "CliniqueRefuseeID");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "771e14cb-c981-4c46-bb1f-716090d7ca74", "4026fbef-d9a0-45fd-8d4e-6836be8d0412" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "062dd565-624a-49a6-9055-507a5fceb981", "9feed1f5-7f36-4c18-93eb-c5c4912f3c5c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1fddffb2-28c9-4e40-8ee3-3bbace05a46d", "17cc54dc-f55c-4a36-a215-3f9394feed76" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3fe3f224-5999-46a4-b03b-46189af7096e", "86a7e1c2-973d-4314-9860-49919cfaf1d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "66c5f414-bca8-425b-b701-12d930881c91", "ab1e3416-40c3-4807-8bce-92c11af38ab0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5cd3f52b-50e9-4688-81aa-5778904b9d3e", "5364a888-57a5-4fd2-8e14-9a90cb31d52b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fd435b58-14d7-4b1d-b08f-bc9c474d227b", "03d4d16e-9d9d-4e4b-9b0e-cff67b0e10b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bbb9e96d-950c-45ed-8f47-288f4442d617", "742709b4-6200-4175-a280-1cd31fa047f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8f78ff04-307d-4472-8496-d52736087cbc", "d1fbef11-5211-4f94-996b-16d42070dc5a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "82ea3de5-bf09-4c99-b590-7f6e9281ae88", "2a654c04-2b82-40cf-a52a-da5ebd11bc31" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3dd309cd-aaaf-4d73-bdb4-16f292b3404b", "64007755-7c95-4dc4-acdd-e49dbb62dfd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c2505149-b89e-4565-b22c-76ac5e6b9540", "5acf957e-b6e7-4631-a418-d8f43b616092" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9c9328b8-738b-457c-841a-6fe02ef2cd33", "2bbd1ad8-724e-4278-bd49-2c908ceb1fdc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "03e28c1b-cdd8-449e-9c5f-d2432c7f0ad1", "6f194eb0-07a6-44b4-9466-45bb81af52e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "03cf2c78-0bef-43e1-888a-79240621ef08", "8a15c592-a798-4234-bc14-86b90e09c4eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c3fd3266-5011-4bb8-9e84-83258d1de0a1", "a6b0a2fb-93c4-495c-b5c5-d882499cc9c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e72b5e3c-6aa1-49f5-8cfc-1fefffc38601", "69fd2ca3-24a7-41d0-b83d-a839d8a6cbee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2c0dba98-c7af-47c1-bd4c-f07717398fa8", "5ac1694b-6002-4fd9-a82f-55f511819fdf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a2698b49-c3fa-46bc-888a-6bdcee3a72d8", "77cc026c-bda1-49a8-87a5-f236a48a39c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "444a1583-2c41-4e94-b00a-5b77d7832fa5", "62a27a12-a1fc-40bd-8a40-c042ea90d727" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c7a5ab3b-14f3-405a-9b36-ff4a0d098903", "bedbc402-e234-4882-9f73-db1576119798" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e288c408-4278-46d2-b37f-06bdc5f978ed", "41d8bf1f-e979-4837-be5d-d2bf1a42222c" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 3, 7, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 3, 7, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3591));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 3, 7, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3594));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 3, 7, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3597));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 3, 7, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 3, 7, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3603));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3637));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3657));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3664));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3672));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3680));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 9, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3687));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 9, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3695));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 9, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3702));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 11, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3710));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 12, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3717));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3726));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 10, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3733));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 11, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 10, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 11, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 12, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3761));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3769));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3778));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 9, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 10, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3828));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 11, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3835));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 12, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3842));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 13, 8, 7, 618, DateTimeKind.Local).AddTicks(3850));

            migrationBuilder.AddForeignKey(
                name: "FK_EmployesClinique_CliniqueRefusees_CliniqueRefuseeID",
                table: "EmployesClinique",
                column: "CliniqueRefuseeID",
                principalTable: "CliniqueRefusees",
                principalColumn: "CliniqueRefuseeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ListeAttentes_CliniqueRefusees_CliniqueRefuseeID",
                table: "ListeAttentes",
                column: "CliniqueRefuseeID",
                principalTable: "CliniqueRefusees",
                principalColumn: "CliniqueRefuseeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployesClinique_CliniqueRefusees_CliniqueRefuseeID",
                table: "EmployesClinique");

            migrationBuilder.DropForeignKey(
                name: "FK_ListeAttentes_CliniqueRefusees_CliniqueRefuseeID",
                table: "ListeAttentes");

            migrationBuilder.RenameColumn(
                name: "CliniqueRefuseeID",
                table: "ListeAttentes",
                newName: "CliniqueRefuseeCliniqueID");

            migrationBuilder.RenameIndex(
                name: "IX_ListeAttentes_CliniqueRefuseeID",
                table: "ListeAttentes",
                newName: "IX_ListeAttentes_CliniqueRefuseeCliniqueID");

            migrationBuilder.RenameColumn(
                name: "CliniqueRefuseeID",
                table: "EmployesClinique",
                newName: "CliniqueRefuseeCliniqueID");

            migrationBuilder.RenameIndex(
                name: "IX_EmployesClinique_CliniqueRefuseeID",
                table: "EmployesClinique",
                newName: "IX_EmployesClinique_CliniqueRefuseeCliniqueID");

            migrationBuilder.RenameColumn(
                name: "CliniqueRefuseeID",
                table: "CliniqueRefusees",
                newName: "CliniqueID");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e12379be-7722-48f8-a07a-a0a444fb04fd", "e846a62d-e3fd-4be0-9e81-195a23fdb6ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1df8e2ec-151b-451b-830b-00ea22f95391", "45530c00-07c3-48b6-a8c5-b1e620a219e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "21fdd9c9-9063-412f-a91b-9f283dc0f218", "026a032c-5150-4211-a0e4-a7351426e7b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "00f83155-e759-4274-80b5-976626479220", "5f072788-db37-4867-8a84-473e0578bc1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "980f6962-2d9b-4d7a-81b7-7056912bebbb", "6ff7eead-2506-4fbd-afdd-a5c5c214918a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a975ee70-967c-460f-a6cb-ed42f82ccd7d", "e56fe527-45d2-4889-aed7-540760ad63aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1d66a7fc-5233-4685-8281-3fe758d56db9", "48d70977-0a99-4451-b635-5aed37a1dbc5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "36137c61-d821-4f5a-9804-ca6807ab35bd", "e003638a-0655-4eb4-8b33-422e65655af5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6b22bb90-8b50-4425-98e9-c3d877cf7a72", "8c62ba7b-0318-488b-a590-5552df30d373" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7c146c14-663a-402f-aba1-547ed4bda0a2", "59b0faea-a577-419b-98a9-a8d8dd005888" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "677bf37d-20f6-4ec2-a19b-a482e0ff0421", "3598b926-5a8c-4a7b-b665-67183b05a27f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5be5aac6-451e-465f-95e9-622cc538df77", "1a871aa7-7edf-4239-a731-e2d819fe067d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f5d20775-398c-409d-a40e-2984ef60b8e5", "e41bbafd-73ce-443d-86d8-c6b2227aff7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4d494213-bd26-4b7f-b407-9a3d88967230", "7a829ed6-b90a-4d12-9cd9-82226cef7551" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "89a9fa8c-e46e-4f2f-852e-b7e2c120fb29", "5bdcb16b-7f26-4417-8995-a26aeeed21d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "32852e49-4436-4f77-8328-1954ca5b5ed5", "0a58f8d2-fdc8-4ccb-ab39-976a67e4e976" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9ee0c711-6b81-4044-98c7-646a8414ec39", "979e44c1-3c98-4769-8262-e1b2a5d2bbf3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3c230e84-3f96-412c-86b0-61b3c215c746", "b90032bd-ce65-49f5-a06d-f50c7a5c5d1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "06619bdb-0eb1-4910-bc64-4ce01d7adc7c", "e130c19d-04c2-4650-889c-c150a9e4a012" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "02b4c7d2-5d8d-4c9c-9a25-7a1d481b40b6", "83aa8d7f-e99c-41f5-9c7a-403672a4c511" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "31029dc4-6c77-44b0-8fa5-cf1b700132c2", "e4aa2ef1-c755-44e8-aade-bd6f2f641438" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dfcf19ce-8603-4acc-b4b8-3384d588f212", "8d93cc5e-6cfb-477d-9e68-fd712035a785" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 3, 7, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8179));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 3, 7, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8227));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 3, 7, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8230));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 3, 7, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 3, 7, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8235));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 3, 7, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8237));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8272));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8290));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8304));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8312));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 9, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8318));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 9, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8325));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 9, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8331));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 11, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8339));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 12, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8345));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8352));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 10, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8358));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 11, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8365));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 10, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8401));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 11, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8409));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 12, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8416));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 9, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8435));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 10, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8442));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 11, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8448));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 12, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8464));

            migrationBuilder.AddForeignKey(
                name: "FK_EmployesClinique_CliniqueRefusees_CliniqueRefuseeCliniqueID",
                table: "EmployesClinique",
                column: "CliniqueRefuseeCliniqueID",
                principalTable: "CliniqueRefusees",
                principalColumn: "CliniqueID");

            migrationBuilder.AddForeignKey(
                name: "FK_ListeAttentes_CliniqueRefusees_CliniqueRefuseeCliniqueID",
                table: "ListeAttentes",
                column: "CliniqueRefuseeCliniqueID",
                principalTable: "CliniqueRefusees",
                principalColumn: "CliniqueID");
        }
    }
}
