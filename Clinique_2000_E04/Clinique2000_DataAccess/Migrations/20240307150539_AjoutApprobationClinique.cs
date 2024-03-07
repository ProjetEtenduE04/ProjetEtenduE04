using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class AjoutApprobationClinique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstApprouvee",
                table: "Cliniques",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                column: "DateCreation",
                value: new DateTime(2024, 3, 7, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7063));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 3, 7, 10, 5, 38, 123, DateTimeKind.Local).AddTicks(7109));

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

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 1,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 8, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 8, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 2,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 8, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 9, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 3,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 8, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 9, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 4,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 8, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 5,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 8, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 10, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 6,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 8, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 11, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 7,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 8, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 11, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 8,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 8, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 12, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 9,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 8, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 12, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 10,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 8, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 13, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 11,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 3, 8, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 3, 8, 13, 30, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstApprouvee",
                table: "Cliniques");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df211",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "32df58c3-bcf4-47b1-997f-eccf4bdc2f2e", "a30af241-63ef-49bf-8f6e-03db20afe5f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df216",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "92ed53a3-cf64-4558-a078-bce72bd23a52", "ef8e39c2-8103-401d-8c10-16ae1d081849" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "044265b1-837f-4c3d-87fd-175432902041", "3cf2427b-36d0-49a6-9d0d-4ee7da4226f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df226",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "34683b6d-d6c5-48d9-b1f7-fd0c930f2509", "4677180c-b6ec-422e-8298-76b8e93d18e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d212",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ef8c1db2-52f9-405e-b526-dcc91de7015a", "18d4548c-9966-4665-9a13-aec829fd7444" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d217",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ea2c8afd-09c1-4fb9-a36b-ae8de62520e4", "bb95afac-c99b-4863-a463-bc9553fa257e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bf5c7c46-8ce1-4a8d-bcbb-6fd6f3c66e0a", "b68b5163-9c5c-42b2-9b50-f3eb0abfca18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2b8f367-6c94-4a3e-b5a6-45dabec4d2e7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ba7a0a11-0bc6-4435-9d92-3a2fb04b93f4", "05a499bb-075d-46e0-933d-a710b48ecea7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f313",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "49eadb73-5abb-4e72-8a6d-086d10c147cc", "0bffd24d-95e8-48d0-bee5-d089b081fa3d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f318",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4029d6c7-d3cf-46b8-9a95-eb3c0caa268f", "fdfa69d9-2348-4dc3-9b7d-2b8a87512ddf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4ddce69e-6d7b-4980-9320-27c631716a38", "9a073faa-9658-42e2-8de1-fbf16ea9ea6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c9e478-8d81-4aaf-aa77-56e1d3f5f3f38",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ad054f80-c44a-4327-a3db-1b32d9ed8358", "989c2cb5-cf7f-4f84-abcd-dba529deebdd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g22",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aff01b10-7da5-4cdb-a630-7cf7faefe59e", "11345860-c4f1-432e-bfe4-300571521f4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g410",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b2bcb455-03d5-47b4-98f3-82f7c636eec8", "e7c3acf7-eed4-443b-9ca8-c38c73b14337" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g414",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f6065080-060e-42f8-ae5d-2aa8df6f6b48", "fcfd031f-8de8-4960-ab83-19388d536ffd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g415",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b10bfb90-8b62-47fd-826f-b573ecde90bd", "8dd5f19c-a4c6-4c83-a428-89c521d64337" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g419",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d5a912c2-7d0c-45b7-9218-90299a22ed7d", "4ae51b6f-402d-40a0-8658-f6442dcbdda0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g420",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ebeed9ae-0d04-4a68-ae6f-54dfa7660f23", "bd9ff53c-c4ee-45d8-813c-3d4226a32bf0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g421",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "89136fe9-5fa3-4798-8b92-0c8ca319719e", "16088b28-a301-483b-ac1a-5b5d0103508d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2bf0c518-da78-4c95-942b-e4a86a4397d1", "cd4c31bb-e5c8-4fba-b6de-7f0c27f895ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ecec8298-2eff-4ea8-a2b2-2b53e8eb59d7", "fb68ed8b-df24-48be-9507-8761c2663d73" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "g4d0a589-2b02-4d36-9a85-39c028a4g4g9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "36ab9c31-2966-4f1e-b1d8-7de798b5649a", "c5e6c4df-954a-4618-9b95-a26002314703" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 2, 8, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(8936));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 2, 8, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(8983));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 3,
                columns: new[] { "DateCreation", "EstActive" },
                values: new object[] { new DateTime(2024, 2, 8, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(8985), true });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 4,
                columns: new[] { "DateCreation", "EstActive" },
                values: new object[] { new DateTime(2024, 2, 8, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(8988), true });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 5,
                column: "DateCreation",
                value: new DateTime(2024, 2, 8, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(8991));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 6,
                columns: new[] { "DateCreation", "EstActive" },
                values: new object[] { new DateTime(2024, 2, 8, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(8993), true });

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 1,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 9, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9023));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 2,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 9, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9034));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 3,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 9, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 4,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 9, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 5,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 9, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 6,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 9, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9067));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 7,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 10, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9079));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 8,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 10, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9086));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 9,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 10, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9094));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 10,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 12, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9103));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 11,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 13, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9151));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 12,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 14, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 13,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 11, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 14,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 12, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 15,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 11, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9183));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 16,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 12, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 17,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 13, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9199));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 18,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 14, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9208));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 19,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 9, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 20,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 10, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9223));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 21,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 11, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 22,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 12, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9237));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 23,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 13, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "ListeAttentes",
                keyColumn: "ListeAttenteID",
                keyValue: 24,
                column: "DateEffectivite",
                value: new DateTime(2024, 2, 14, 22, 6, 57, 550, DateTimeKind.Local).AddTicks(9252));

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 1,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 9, 8, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 9, 8, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 2,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 9, 8, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 9, 9, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 3,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 9, 9, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 9, 9, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 4,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 9, 9, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 9, 10, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 5,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 9, 10, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 9, 10, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 6,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 9, 10, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 9, 11, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 7,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 9, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 9, 11, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 8,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 9, 11, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 9, 12, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 9,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 9, 12, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 9, 12, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 10,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 9, 12, 30, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 9, 13, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "PlagesHoraires",
                keyColumn: "PlageHoraireID",
                keyValue: 11,
                columns: new[] { "HeureDebut", "HeureFin" },
                values: new object[] { new DateTime(2024, 2, 9, 13, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 2, 9, 13, 30, 0, 0, DateTimeKind.Local) });
        }
    }
}
