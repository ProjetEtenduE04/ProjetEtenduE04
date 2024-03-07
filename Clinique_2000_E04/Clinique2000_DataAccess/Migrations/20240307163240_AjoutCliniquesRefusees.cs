using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class AjoutCliniquesRefusees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CliniqueRefuseeCliniqueID",
                table: "ListeAttentes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CliniqueRefuseeCliniqueID",
                table: "EmployesClinique",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EstApprouvee",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CliniqueRefusees",
                columns: table => new
                {
                    CliniqueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomClinique = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Courriel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HeureOuverture = table.Column<TimeSpan>(type: "time", nullable: false),
                    HeureFermeture = table.Column<TimeSpan>(type: "time", nullable: false),
                    TempsMoyenConsultation = table.Column<int>(type: "int", nullable: false),
                    NumTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModification = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdresseID = table.Column<int>(type: "int", nullable: false),
                    CreateurID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstApprouvee = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CliniqueRefusees", x => x.CliniqueID);
                    table.ForeignKey(
                        name: "FK_CliniqueRefusees_Adresses_AdresseID",
                        column: x => x.AdresseID,
                        principalTable: "Adresses",
                        principalColumn: "AdresseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CliniqueRefusees_AspNetUsers_CreateurID",
                        column: x => x.CreateurID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "DateCreation", "EstApprouvee" },
                values: new object[] { new DateTime(2024, 3, 7, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8179), true });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                columns: new[] { "DateCreation", "EstApprouvee" },
                values: new object[] { new DateTime(2024, 3, 7, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8227), true });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                columns: new[] { "DateCreation", "EstActive" },
                values: new object[] { new DateTime(2024, 3, 7, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8230), true });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                columns: new[] { "DateCreation", "EstActive" },
                values: new object[] { new DateTime(2024, 3, 7, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8233), true });

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
                columns: new[] { "DateCreation", "EstActive" },
                values: new object[] { new DateTime(2024, 3, 7, 11, 32, 39, 616, DateTimeKind.Local).AddTicks(8237), true });

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

            migrationBuilder.CreateIndex(
                name: "IX_ListeAttentes_CliniqueRefuseeCliniqueID",
                table: "ListeAttentes",
                column: "CliniqueRefuseeCliniqueID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployesClinique_CliniqueRefuseeCliniqueID",
                table: "EmployesClinique",
                column: "CliniqueRefuseeCliniqueID");

            migrationBuilder.CreateIndex(
                name: "IX_CliniqueRefusees_AdresseID",
                table: "CliniqueRefusees",
                column: "AdresseID");

            migrationBuilder.CreateIndex(
                name: "IX_CliniqueRefusees_CreateurID",
                table: "CliniqueRefusees",
                column: "CreateurID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployesClinique_CliniqueRefusees_CliniqueRefuseeCliniqueID",
                table: "EmployesClinique");

            migrationBuilder.DropForeignKey(
                name: "FK_ListeAttentes_CliniqueRefusees_CliniqueRefuseeCliniqueID",
                table: "ListeAttentes");

            migrationBuilder.DropTable(
                name: "CliniqueRefusees");

            migrationBuilder.DropIndex(
                name: "IX_ListeAttentes_CliniqueRefuseeCliniqueID",
                table: "ListeAttentes");

            migrationBuilder.DropIndex(
                name: "IX_EmployesClinique_CliniqueRefuseeCliniqueID",
                table: "EmployesClinique");

            migrationBuilder.DropColumn(
                name: "CliniqueRefuseeCliniqueID",
                table: "ListeAttentes");

            migrationBuilder.DropColumn(
                name: "CliniqueRefuseeCliniqueID",
                table: "EmployesClinique");

            migrationBuilder.DropColumn(
                name: "EstApprouvee",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5df716f9-e033-4cb1-af89-e25b4c51d175", "b5543db3-9b51-4bc7-ac6b-0e1979d89093" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "47970f16-2ea0-4d7a-a2fa-1b06c71775a0", "9ec65c68-60ec-40f9-b2d9-593d929cdfd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fcd02b64-28c4-4347-9713-9b83f52dc2ed", "fff42606-67a5-40a0-81b2-970067d59631" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c572d4f8-5c50-41f4-9a5d-6a4b865f602f", "4a3eb90d-1d7e-4241-91e2-813d2aadc1b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3695c575-4f22-4e5a-9996-5a5548e70c52", "4ffec854-1579-4317-b639-f1f495ab320f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fea8f250-c8a1-49c5-91cd-f052b1bf2115", "22023240-7039-4725-9aa5-355504e05a09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "57ae0136-7d6e-4ad0-bb07-4628e6868e44", "d86193dd-87dc-428a-97ed-ecd8675b105f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8fcc003f-c202-4a4a-b756-6ffa266f0073", "0a2df8db-2c4f-4a82-84f8-1d52ab2ad249" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8d8d59fd-4375-4621-8f54-39e65e661c49", "b2e4ff8c-bc07-4098-8a7b-df33889b92c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b67cd3e6-6bde-4eaf-b701-4174720330e7", "6068ba58-a2fe-4c61-9161-19e3c397c773" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "92aa89e3-6343-4510-a8e8-697ad6a50623", "5afdcb5f-aba7-4edb-90b5-88326a26a46b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "22dd2ba4-f88a-4f1f-806a-5499d5c7cde2", "5e2c4540-41c7-4d5f-92bb-c15cc5ed1e53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "938ec782-ffb2-4abb-b6a1-ff1722ee59d1", "bbded59f-1ab7-41b6-9ddc-93a8f3c38f14" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1a6af29e-c863-4877-83c8-7128edfc9363", "43fcff76-b1fc-4745-90ba-068b08293499" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ad0a7be8-1dae-4d65-aaae-8d7ed708d157", "2f55459b-11a4-459a-a62c-fe7771362033" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "90ed242f-cd64-4222-a54c-ab4009fafb61", "c3415698-adfe-452a-879a-022d7b864056" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d6f9dde7-28b6-4f3c-a204-3cba9d384b47", "5da3eac8-7e9a-428e-b790-a7829f7a6dfe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d8fd5db8-2025-4711-862c-578b2269ef2f", "4260ead1-5c17-4fe2-9bc6-ea0ed4fdfa6e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d651042a-f7c4-4232-8ecb-4fc2dabfa69b", "d0dd0ac2-e155-49f6-92a6-8cc22799ac35" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "12e2dd65-cc98-4c49-8915-84cbc4bd810c", "6d869dc7-6a01-4ca5-baea-eca8c98388fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1cb591d5-a731-4961-a858-a5d44d7ada9c", "0fec69c2-d653-4046-bec8-af3bd20fcc07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "541e964b-bb11-417b-b619-e78f9b1e10fb", "e119da11-8152-4930-9bb5-94704a607826" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                columns: new[] { "DateCreation", "EstApprouvee" },
                values: new object[] { new DateTime(2024, 3, 7, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7063), false });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                columns: new[] { "DateCreation", "EstApprouvee" },
                values: new object[] { new DateTime(2024, 3, 7, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7109), false });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                columns: new[] { "DateCreation", "EstActive" },
                values: new object[] { new DateTime(2024, 3, 7, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7113), false });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                columns: new[] { "DateCreation", "EstActive" },
                values: new object[] { new DateTime(2024, 3, 7, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7115), false });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 3, 7, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7117));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                columns: new[] { "DateCreation", "EstActive" },
                values: new object[] { new DateTime(2024, 3, 7, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7119), false });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7167));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7177));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7201));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 9, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7209));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 9, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 9, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7224));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 11, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7232));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 12, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7248));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 10, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7256));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 11, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7263));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 10, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7271));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 11, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7278));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 12, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7286));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7346));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 8, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7354));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 9, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7362));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 10, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 11, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7381));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 12, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 3, 13, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7396));
        }
    }
}
