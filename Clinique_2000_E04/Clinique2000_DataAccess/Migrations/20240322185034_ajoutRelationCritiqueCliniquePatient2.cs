using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ajoutRelationCritiqueCliniquePatient2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Critiques",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5d55e6b9-81c3-4257-9566-f56e3432aac4", "3d99600f-6090-4319-a748-7a16ec517b50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e31a12c6-9362-414a-ad1b-c6083f6d9346", "7c77adb9-1aed-4ae6-add4-d98c39394f98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "40f9daf3-91a2-4e89-b627-79fc61f9c310", "1fae3bf8-b6e1-42a3-a2db-266bb5328deb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c02e9e0d-6557-4ecb-84a7-f6a55b34964a", "e0140375-29ef-4347-91ea-33b54cd88f96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c85a03f1-9de2-4f23-9ff1-7b18a9e8ea5d", "0d65757f-4ab2-4fdb-b837-16cc8787fda7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "617ae052-dd8e-4d39-abf2-49496955ecb3", "e2eefd8c-fb76-47b1-979b-934784bf28b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "deb07e68-3cd6-4ac6-bfe8-24382f2536a1", "5ce25426-9253-492e-8224-1b2f0047adba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "66fb013c-8304-496c-8edd-2f8478ba579b", "e09e030f-e037-4f35-80be-b55bfbd3cce5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "acf731c7-1e2f-4c79-9b36-accc82dce984", "a0a3b8f6-30ae-4ff8-b296-04a9ace3ce9b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4d58f90d-cf3c-44c1-a66d-7685e5d8c22f", "3112a1d7-cfda-407d-958e-84e119927ec1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7e1b1a02-1f40-40ef-b510-2608a4a50070", "132a5567-9369-4b16-b731-f61292513051" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "28d6a20f-1393-448f-977f-04fce33c2a61", "29317505-4cd4-45fb-93b9-8f8ce47e6bb3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f4813c48-2954-4510-90f9-d2a34c9dd2b0", "4d50f06d-f3f4-4530-b7bb-2e1493bae59d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "eaa2069f-bfe8-454f-912e-a2e9a2afa50f", "489fff8e-45f8-4564-bb0e-f2bc7da8555d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d8339a02-2843-48d0-ab42-9e1283a92177", "a62e503b-842b-406d-a092-ce1b9b96470a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a764ace3-e566-4527-8ea1-4154c72d36e8", "48709fc2-ce52-4048-a81e-d8dc0deac08c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e02eebe6-bcf4-421e-996e-1c40a8752a9f", "61afca2f-7a28-4cfa-826c-2fb48fd30793" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aadeda37-b23b-464d-966d-24624bca50bb", "ecf81115-1515-4796-9127-43bbfff74b28" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8db3aba9-c4d5-4e64-aba9-f8478d284a4c", "9714a5e1-7239-4abd-b18e-353672265944" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3faf051e-ff9c-4807-abb9-168b3a716288", "dfc25863-02b5-4f3a-96d4-8e1268658ed6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fae5f79b-66f0-467e-8d10-c0864d2945f7", "bd73fde9-009f-48ec-a176-c1501e98e0c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0803e421-5a42-4cfb-83da-ed849b09a36c", "034063cf-cabb-4d4f-94d6-e5257ae13da9" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 3, 22, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 3, 22, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 3, 22, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8056));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 3, 22, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8145));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 3, 22, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8149));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 3, 22, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 23, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8211));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 23, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 23, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8246));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 23, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8258));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 23, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8269));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 23, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8283));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 24, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8295));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 24, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8306));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 24, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8318));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 26, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8330));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 27, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8342));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 28, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8355));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 25, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8368));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 26, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8380));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 25, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8395));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 26, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8409));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 27, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8421));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 28, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8434));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 23, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8446));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 24, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 25, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8470));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 26, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8487));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 27, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8500));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 28, 14, 50, 33, 662, DateTimeKind.Local).AddTicks(8585));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Critiques");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "688bccdd-5f22-460c-93b2-94f11eca480f", "19932d37-de26-4d44-a11f-e3b3d3863592" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d16f3e67-0697-4b26-a75d-10fa2418fb64", "f672bda1-ebb4-45fb-98e4-cf6877d8eb83" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b8b22bcb-0363-4ccb-af9f-5b94b79f4f11", "31415fca-f309-4fca-b552-da0e4413e8db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "488cf2ad-3686-4230-86f3-e73b16db3ada", "31f9ad9d-61fb-4052-97f8-2e9ad6a583b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3a41abac-882b-4e33-b418-585ef0b2b442", "155712c5-5a35-4f20-92e0-3f1174ca9ff7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5913c12b-f290-4b1a-8781-34e7b7728a89", "0f60ce61-6a6d-44c0-9643-26c4b2acf570" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e80346bc-d9a5-4db1-b795-a77fbf95d908", "d566f723-8c35-4889-8b4d-fed4e515fbfb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "76f75bac-7998-4468-b56a-ee7f1a4e2dd0", "7071c836-339f-4a5e-b569-7a290e32aaf6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "26f4f2ac-59f0-4218-a138-e6beb4f64a4c", "e01f936b-f476-4e7b-be4d-12b8d0e1e77b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ad5e9f66-e7ab-4fdd-a197-228df98b4969", "3d060152-e1b8-4987-8a7f-0ac9aaa7f0e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "767497da-fe40-42d0-92fd-83b230304051", "09d403f1-6b12-4b26-adcd-aa3eae937a1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "309bcdbf-e006-4e15-83eb-573601706bb6", "a42bb704-041e-4417-895b-ed554ecd7549" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9cb6ae4e-b3aa-4125-92c5-05c63d674c8e", "71b4b153-e377-451f-85fd-4910679e0521" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "236c34a0-4cfb-49b1-b36f-30e3b40dc8e1", "a421b83f-a4bb-49af-bcb5-ba8becc2c621" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9979539d-c2fb-45f5-a628-d3e76664b7cb", "472b4df4-89cd-4e05-8be1-837469c8d071" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f2442eb2-8442-4dcb-81ba-ad22e01c9d5f", "734c55d0-1408-4cf2-9f5a-08b8e1addcef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d9afbdf8-9b1a-49a8-8911-22ffd4cd1061", "6b9d2047-b6ed-4af6-ba7a-67ac6188c0fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "368d7d37-7609-432f-8e29-adf0f06f4ab4", "94ac434a-05ad-4dd4-96f1-638288b9d6c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cd0c4a3f-7c02-4866-9514-bfd30563234d", "147f91d9-f7e6-4970-8424-fc428b05541b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f3c5f509-873a-42d2-ae35-312767e15ed7", "d4cf7781-be0b-4c10-991c-cf8714bca227" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "78a9f600-e514-4f4d-9c33-7ee9c96cc505", "7638ea94-6f83-4471-b142-f9b1739f7401" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bbb196fd-2ef8-4677-82eb-0120e47c584b", "b2c9301b-d260-4226-a700-d85f31801261" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 3, 22, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 3, 22, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(8925));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 3, 22, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(8928));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 3, 22, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(8934));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 3, 22, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(8937));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 3, 22, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(8942));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 23, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 23, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9048));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 23, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9057));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 23, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 23, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9075));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 23, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9084));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 24, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9092));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 24, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9100));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 24, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9109));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 26, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 27, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9127));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 28, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9134));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 25, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 26, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 25, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9156));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 26, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9164));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 27, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9171));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 28, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 23, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9187));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 24, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9195));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 25, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 26, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9209));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 27, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9217));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 28, 14, 48, 6, 53, DateTimeKind.Local).AddTicks(9224));
        }
    }
}
