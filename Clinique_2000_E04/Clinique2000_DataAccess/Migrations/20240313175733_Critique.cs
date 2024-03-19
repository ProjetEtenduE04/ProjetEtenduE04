using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class Critique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Critiques",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Texte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CliniqueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Critiques", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Critiques_Cliniques_CliniqueId",
                        column: x => x.CliniqueId,
                        principalTable: "Cliniques",
                        principalColumn: "CliniqueID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Critiques_CliniqueId",
                table: "Critiques",
                column: "CliniqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Critiques");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "19d98a40-0be8-4caa-a72a-8b82357fe45e", "8facc9e0-ec14-4697-af1c-fb8c7e22fed5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3f4021e2-8943-4818-971f-39a791022783", "eb8f77fa-cf5e-4059-93ec-743f6edd1cf2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "68130ca8-c4c7-4328-be69-a31fcd597890", "81ed61cf-ba03-4c12-99a2-3c1f813a7810" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ad553803-0bfd-4584-acd3-fadf87177e7c", "6b1eb41e-fa2a-457a-bc13-0f49cffde259" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "59e2da6f-8e74-4da3-9fe3-5ea45e36dc4b", "99b8180e-2626-4346-92b2-f16b6e2d7718" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f92d6e6c-6bce-4c10-acd4-b96ea5349708", "a32d0feb-275d-44eb-a155-ba4187435949" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "702176a6-3f2a-43f9-b488-48bf58af0b1b", "bd8126c6-7ceb-49d1-be39-db0d6cb8e3ed" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "530f0ed2-c61c-4862-b9ef-fd29defea02a", "a23c1df5-9700-47a5-ab3a-d7e0bf2cdb56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fe56007e-2e52-4722-a4ac-cd20d67825a6", "8e1ea9d9-46e3-41bb-badf-393b2327d820" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "27333c03-df1a-4a5c-935b-37c4d90f6a63", "c8118b50-e29e-4165-8887-4901b2beb5f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c28aaf01-33e9-424c-ae58-72fd670f1d20", "9b13f48a-9ef2-4e5d-9dc6-45ec5ab6ac73" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0fc72fc3-5f80-49ff-9cef-f22de259161b", "c80aded8-cef6-4bce-bb5e-3dc81c1fb0a9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4a0ef285-265b-4586-9150-5edd8665ce41", "3629e203-46ba-4721-80ee-995c27292d62" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "895559df-f659-4204-92b5-e7d9b1d84f2d", "3b04ba2b-0c50-4891-a3a8-9e073ca7e124" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f4572164-6219-4d0c-b2c9-cf7e48dbbb60", "8635f178-dde0-4434-8d3a-6d6281b3902c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "88cd22fe-fb58-43ca-af82-c5fd15bfb59a", "eec49080-3986-459a-bae5-89ced30997c3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f4182666-d4c0-4626-8a2d-5ed802b94714", "819dffbc-f5bf-4a6c-96ac-3eaa9715a0f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "719c9660-8806-49d8-9c27-93e3cfef378e", "351bc436-1fea-46d7-a492-907eec9ec275" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ac40478f-aa1e-49dd-af4b-24c7bdb4f322", "c59ce2c7-9e85-42e8-afd6-45d39aab5813" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c4622124-95b6-4c94-93c1-1151ba206b58", "b91dd815-ccba-4436-87d2-b0bc6c30bc89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dc280aaa-0bae-4ed3-8c32-03b1b39966f8", "1dfc43e7-3686-42e5-97d4-be172118b80f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bc744b3c-d915-4bc8-b253-cb32930a0451", "eab59628-d4a1-46f6-8f94-b50f2d657760" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(4934));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(4981));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(4986));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(4989));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                column: "DateCreation",
                value: new DateTime(2024, 3, 13, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(4991));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5023));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5037));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5045));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5054));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5062));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5071));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5078));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5086));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5110));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 19, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5118));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5126));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5134));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5142));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5149));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5189));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 19, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5199));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 14, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5206));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 15, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5214));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 16, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5221));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 17, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5231));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 18, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5239));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 19, 9, 50, 40, 527, DateTimeKind.Local).AddTicks(5246));
        }
    }
}
