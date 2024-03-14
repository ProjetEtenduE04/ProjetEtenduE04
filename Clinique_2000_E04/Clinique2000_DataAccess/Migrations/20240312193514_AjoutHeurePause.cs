using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class AjoutHeurePause : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "HeurePauseDebut",
                table: "Cliniques",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HeurePauseFin",
                table: "Cliniques",
                type: "time",
                nullable: true);

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
                columns: new[] { "DateCreation", "HeurePauseDebut", "HeurePauseFin" },
                values: new object[] { new DateTime(2024, 3, 12, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3825), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                columns: new[] { "DateCreation", "HeurePauseDebut", "HeurePauseFin" },
                values: new object[] { new DateTime(2024, 3, 12, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3872), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                columns: new[] { "DateCreation", "HeurePauseDebut", "HeurePauseFin" },
                values: new object[] { new DateTime(2024, 3, 12, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3875), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                columns: new[] { "DateCreation", "HeurePauseDebut", "HeurePauseFin" },
                values: new object[] { new DateTime(2024, 3, 12, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3878), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                columns: new[] { "DateCreation", "HeurePauseDebut", "HeurePauseFin" },
                values: new object[] { new DateTime(2024, 3, 12, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3883), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                columns: new[] { "DateCreation", "HeurePauseDebut", "HeurePauseFin" },
                values: new object[] { new DateTime(2024, 3, 12, 15, 35, 12, 674, DateTimeKind.Local).AddTicks(3885), new TimeSpan(0, 12, 0, 0, 0), new TimeSpan(0, 13, 0, 0, 0) });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeurePauseDebut",
                table: "Cliniques");

            migrationBuilder.DropColumn(
                name: "HeurePauseFin",
                table: "Cliniques");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "21fad8e5-fe53-4407-bd79-a865bd0012d1", "e813e92b-1b83-4d51-9688-edbc7ed1170f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "05efc830-2a65-4620-9449-8639bc5e0b9d", "677f94f7-6e05-4b65-b385-91e4ed05b0b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d982b3e6-2853-4f84-8c25-1a8801fc9e4f", "5f1c4734-d912-4d91-ad30-f76e002f1319" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ba768fd9-3c41-4cbb-9fbb-8b0750a0c877", "e90c8150-fdbb-4e81-a2ce-70b1407d04a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "68aba7f6-52c5-418c-8241-6f82fc3b79eb", "2f0eebe1-94da-4e37-bd44-02378ebc4548" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ee0f120e-2a80-4caa-b236-8874f7f1db61", "2280dca6-f6a4-411e-8bdb-d84c40f17766" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0fb2a2ef-a7e4-4bbb-aced-a9ed8d2a1b31", "9292c5f5-0f0d-4cb3-af7d-c7fc5946df1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "433907ba-0f8b-4334-b777-42d9ae803917", "77d2aff1-824f-4f23-ba96-7da234d46f50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0a242937-d4fa-4c4f-a951-96a61960cb13", "fd92f2b0-3a62-4a8f-b2b2-c7802add9394" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f5664c72-bf71-4801-a987-2d5bd6678889", "e659e4e1-213a-499a-8160-e829c7a709f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b2e20615-abe9-46e5-a96c-3d3fba2f101e", "dd0d0fe3-4d46-4637-95f3-d47dd30c05fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b51e1691-21a3-4840-b7a5-af1cba92f478", "928515bc-9bb8-41f9-aa19-8cd789289efd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7b987d0f-4594-4ac9-b5c2-84ef27cb708b", "8b38ee9a-c21e-45e2-8fa5-f12c4d094e06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9ac00ed0-34fe-4b7e-be06-384200bbc88d", "aa80afa6-d808-4689-963a-5dce0ef03745" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4e864186-9a37-4f93-bfeb-fe665788595f", "7b592f68-adfd-4272-bd7d-8bf4ff3575c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8f988f14-f0f4-491d-8cfd-a4435c956c78", "843ca4f7-c242-45ac-9f18-f574adfda2d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6b845c22-47cb-46a8-b4b9-995efbaa3686", "2ee7a588-bba2-400a-b5f2-2d052ff1e490" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fa68b42b-4ca7-4152-a6fa-b85bffd81214", "b55a793e-ab89-43f7-b611-d1ee32d60c68" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0d695eed-416c-4892-ad9a-1e820c531c94", "1f3d8fdc-0cc8-40d4-8cb5-dbb839177634" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cd863d6b-badd-46fe-aebe-db1d1c6f0789", "93b6b8b2-8bf5-4210-b584-84ad67622183" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c896c2d6-0f22-42b1-beb9-ef1b77993494", "f91164fc-cf52-4c0c-be59-02a02c058dff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d4b084f1-7054-4702-9510-c4f5d6c7160c", "9b03dbe8-2784-4ba7-bb28-a78d591d4688" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 3, 12, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1188));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 3, 12, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1235));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 3, 12, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1239));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 3, 12, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1243));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 3, 12, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1245));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 3, 12, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1250));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1286));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1300));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1307));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1315));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1321));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1329));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1336));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1343));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1351));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1359));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1366));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1373));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1387));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1394));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1401));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1408));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1424));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1437));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 14, 46, 0, 731, DateTimeKind.Local).AddTicks(1488));
        }
    }
}
