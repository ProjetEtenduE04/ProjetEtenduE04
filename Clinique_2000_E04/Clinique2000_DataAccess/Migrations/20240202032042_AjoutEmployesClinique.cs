using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class AjoutEmployesClinique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployesClinique",
                columns: table => new
                {
                    EmployeCliniqueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeCliniqueNom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeCliniquePrenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeCliniqueCourriel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeCliniquePosition = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CliniqueID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployesClinique", x => x.EmployeCliniqueID);
                    table.ForeignKey(
                        name: "FK_EmployesClinique_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployesClinique_Cliniques_CliniqueID",
                        column: x => x.CliniqueID,
                        principalTable: "Cliniques",
                        principalColumn: "CliniqueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bbf00ca2-2c4f-42e0-bc9a-2dd30aa4f52c", "1cdc4b08-079e-4447-831d-3ddc694a70e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cb0e8246-4ac4-47bf-a1dd-81e7cfb8cd58", "c3283910-bce1-4537-9fec-4c846bb2ca67" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e0182c17-fe46-454b-a9d9-833dbfb62ff7", "fe050aa2-a3c7-4612-b9ba-2b641b1c1c68" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dbaf5dfd-2d03-4efc-9f3f-010e7a8fd8d5", "095514eb-b61c-4f79-9c20-a6a6c7a71bd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "edb55187-2e6e-431c-a853-e39502ac122a", "38958a56-494c-4ba0-b990-dd80be60fd50" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "34d59365-cc97-45ca-9910-17cc75cbc95d", "1f8a8f89-6a87-4bbf-9311-84257d6f38bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6f33b11c-91da-4276-9714-11ae44d41056", "b10ba17b-688b-4b7b-8f45-784a00ce9985" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ad3966a6-29af-4b9a-85ae-156cc17ffd65", "074dd499-e094-4c6b-b9c3-c13108187900" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3b1a070e-17c3-4355-b7e2-49b452b92c09", "1f540287-2184-4232-b194-d2338c25b273" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "73db3c23-4ae3-45fa-9df1-05d5f73fd682", "f788d3d9-ba08-45fd-b852-17d74ce7fa4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "611b57cc-cc7f-4426-9785-4ace31bfcb47", "c520242c-96ff-4285-bfa2-0312278bf1a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d52301bd-b82b-4514-9213-c191e02ba777", "0f2103f5-77a0-4956-bcd8-5edb6504aed5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "759e65db-d87d-4137-bf70-5e8c0bbd3896", "0accfb9a-6c4b-4a61-aa02-756a4811bf79" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "975184b6-692d-4973-a9a4-adf20581af8c", "f9a4f1a6-4068-440e-9364-408139f2882a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3b256b15-05c6-4edf-8d73-6952aeca13fd", "5353e6a6-85fa-495f-8ddf-e7894adc2040" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1e31295a-27c5-4961-a9ed-8b2b82c5671a", "486e98ec-6b6b-4a95-98fb-974265bfafa7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c1b2fec2-f839-439a-b108-dd3df2c31fc5", "a1a9b24f-d0b5-48d7-8f39-fc9191ebbb44" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a5312347-6094-4fe1-9531-5c81525b743c", "2d1eb984-50a2-4bfa-b425-0840b5a6d985" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e2317cf4-c628-40f0-a3b8-b839eda38673", "94a476a8-bcf2-45e1-8379-74bee6deb959" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ec53d75c-e942-49c5-9ca5-f20d43bb3bec", "ce224963-d999-4ae6-9383-b101cedf985f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "57dbdef6-646b-4f87-b7b7-d895978b09d2", "6466fe2e-4546-4ba3-bafe-c0f2681a0f7e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d746a70f-5ac2-43c0-9dff-619551b40ca9", "89191434-cab7-4a61-befa-29b567ebfa13" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 2, 1, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 2, 1, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1412));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 2, 1, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1415));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 2, 1, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1416));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 2, 1, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1418));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 2, 1, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1420));

            migrationBuilder.InsertData(
                table: "EmployesClinique",
                columns: new[] { "EmployeCliniqueID", "CliniqueID", "EmployeCliniqueCourriel", "EmployeCliniqueNom", "EmployeCliniquePosition", "EmployeCliniquePrenom", "UserID" },
                values: new object[] { 1, 1, "marktremblay123456@gmail.com", "Tremblay", 0, "Mark", null });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 2, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1451));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 2, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1466));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 2, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1474));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 2, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1481));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 2, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1489));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 2, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1497));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 3, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1504));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 3, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1538));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 3, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1547));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 5, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1555));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 6, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1562));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 7, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1569));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 4, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1576));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 5, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1586));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 4, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1593));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 5, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1600));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 6, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1607));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 7, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1615));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 2, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1622));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 3, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 4, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1636));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 5, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1643));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 6, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1651));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 7, 22, 20, 41, 163, DateTimeKind.Local).AddTicks(1658));

            migrationBuilder.CreateIndex(
                name: "IX_EmployesClinique_CliniqueID",
                table: "EmployesClinique",
                column: "CliniqueID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployesClinique_UserID",
                table: "EmployesClinique",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployesClinique");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "141fa336-d492-44c7-8df9-5910c707b17b", "27531edf-3aba-4d69-bc43-7264d55a5bd4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d7d9225f-a5c8-489c-b998-71437d1d31e6", "85942765-3d1e-4261-8ec8-facab3a6f9f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "410858c1-074c-441d-a7f7-9cc13208749b", "38a8cc24-38e1-41d7-8f5d-aa7878759a38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3a3e83c8-bc30-4d1a-b151-e750d03c4218", "2b221ff3-9926-4b84-a4a6-ac5929dc8e6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f149574f-4bc0-4169-9389-429dcea8f19f", "69b268ae-fc11-4e2f-a319-cc1a61297b32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "920b5341-1070-4084-9662-8b8c278f0758", "dedbbbb2-4884-40df-81e5-e5ed59974c7e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "93e38384-2707-456b-a472-935080ece040", "30035cb4-65d4-4249-a86d-e084fb3dfee9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "70e753d6-d31e-40c4-90f0-51740505b542", "01e57581-b8a2-4206-b610-8e9f86de4f97" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "523b7b5a-d4c9-4cb7-9940-b2130f431b79", "8e874c0d-313f-4dd4-9a8c-c5c93a5286ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7663213a-059c-4d01-874d-e2f8bc679d88", "38499661-8bdf-4d12-a10f-22144f36133e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "79e2762f-4f25-4e46-aaee-8f523b892d1c", "e401c8b9-1d9f-481c-a383-eaf650b22e3c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4d587ebf-0bca-478d-9b92-a1d11c8f7139", "b2ae1ece-0583-4477-9d4a-9697f209db28" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "44c26daf-72b7-44d0-8218-bcf148b6c69c", "f4cd0058-3bfe-44da-b40a-051ca1c5e50a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2d463221-6698-44c0-8037-377eda4038b5", "29411d22-245b-4f5f-b51b-0d9558700dc5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e7a99b9c-464d-4e05-acd3-b8daf7559e42", "b432d9fd-7692-4aa8-a919-e495524d5203" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "62ba9bd5-7c23-4557-8bca-fad35647b50b", "c6a20b6f-9600-463f-a1fc-600a10017539" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f1b08c1c-75b2-4cd5-940a-fa955c8348f7", "52653b09-b508-41df-bd61-378aae694c1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0386350b-95b3-464f-beb2-303fa1c4d5df", "6994d4f4-0855-4f91-9eb2-01f5981780ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "08c75809-2963-4473-b906-d1ec1578a7eb", "7cf2a5c9-00b9-4f7c-a43c-f9b1f393b0b0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "47f4c3bf-8e05-4bfc-b011-795699e3dad8", "aee3292d-817c-43a0-9184-be5024c36656" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6731a190-3d45-4db2-a4ab-966e159f3c69", "3204c0f2-d745-4b6c-9a58-1a62b1a47318" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a09dd499-dd25-4607-b0a0-a40b8d641618", "e5584c64-6d37-412b-9822-d543a5a5cd00" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 2, 1, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4396));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 2, 1, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 2, 1, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4446));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 2, 1, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 2, 1, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4452));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 2, 1, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 2, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4487));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 2, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 2, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4510));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 2, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 2, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 2, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4533));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 3, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4541));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 3, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 3, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4555));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 5, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4564));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 6, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 7, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4616));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 4, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 5, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4631));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 4, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4638));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 5, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 6, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4653));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 7, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4661));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 2, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 3, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4676));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 4, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4684));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 5, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4691));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 6, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4698));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 7, 20, 46, 14, 271, DateTimeKind.Local).AddTicks(4706));
        }
    }
}
