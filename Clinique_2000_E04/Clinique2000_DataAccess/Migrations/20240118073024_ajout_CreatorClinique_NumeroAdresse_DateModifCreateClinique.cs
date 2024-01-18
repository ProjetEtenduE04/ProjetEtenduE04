using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ajout_CreatorClinique_NumeroAdresse_DateModifCreateClinique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateurID",
                table: "Cliniques",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Cliniques",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModification",
                table: "Cliniques",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Adresses",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Adresses",
                keyColumn: "AdresseID",
                keyValue: 1,
                columns: new[] { "Numero", "Rue" },
                values: new object[] { "7-756", "rue de la Clinique" });

            migrationBuilder.UpdateData(
                table: "Adresses",
                keyColumn: "AdresseID",
                keyValue: 2,
                columns: new[] { "Numero", "Rue" },
                values: new object[] { "2-66", "rue de la Cegep" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7cc96785-8933-4eac-8d7f-a289b28df222", 0, "65eab6bf-6567-41c1-84f9-98b2eb67a165", "ApplicationUser", "bitcav@gmail.com", true, false, null, "BITCAV@GMAIL.COM", "ALEX", null, null, false, "2f225759-4e40-4142-9e3c-cc0587a1e55a", false, "bitcav@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                columns: new[] { "CreateurID", "DateCreation" },
                values: new object[] { "7cc96785-8933-4eac-8d7f-a289b28df222", new DateTime(2024, 1, 18, 2, 30, 24, 448, DateTimeKind.Local).AddTicks(3489) });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                columns: new[] { "CreateurID", "DateCreation" },
                values: new object[] { "7cc96785-8933-4eac-8d7f-a289b28df222", new DateTime(2024, 1, 18, 2, 30, 24, 448, DateTimeKind.Local).AddTicks(3533) });

            migrationBuilder.CreateIndex(
                name: "IX_Cliniques_CreateurID",
                table: "Cliniques",
                column: "CreateurID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliniques_AspNetUsers_CreateurID",
                table: "Cliniques",
                column: "CreateurID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliniques_AspNetUsers_CreateurID",
                table: "Cliniques");

            migrationBuilder.DropIndex(
                name: "IX_Cliniques_CreateurID",
                table: "Cliniques");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df222");

            migrationBuilder.DropColumn(
                name: "CreateurID",
                table: "Cliniques");

            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "Cliniques");

            migrationBuilder.DropColumn(
                name: "DateModification",
                table: "Cliniques");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Adresses");

            migrationBuilder.UpdateData(
                table: "Adresses",
                keyColumn: "AdresseID",
                keyValue: 1,
                column: "Rue",
                value: "123 rue de la clinique");

            migrationBuilder.UpdateData(
                table: "Adresses",
                keyColumn: "AdresseID",
                keyValue: 2,
                column: "Rue",
                value: "777 rue de la Cegep");
        }
    }
}
