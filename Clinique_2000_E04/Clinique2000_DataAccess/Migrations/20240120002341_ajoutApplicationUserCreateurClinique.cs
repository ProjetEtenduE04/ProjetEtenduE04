using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ajoutApplicationUserCreateurClinique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df222");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7cc96785-8933-4eac-8d7f-a289b28df223", 0, "7a8bb752-85ce-4b61-90f6-364e3116f03e", "ApplicationUser", "bit@gmail.com", true, false, null, "BIT@GMAIL.COM", "BIT@GMAIL.COM", null, null, false, "c6b83a5e-fd3a-4e6f-a2ec-1aed9ebac37c", false, "bit@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 1, 19, 19, 23, 41, 430, DateTimeKind.Local).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 1, 19, 19, 23, 41, 430, DateTimeKind.Local).AddTicks(3647));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7cc96785-8933-4eac-8d7f-a289b28df222", 0, "f6477bb8-8c64-4a89-80bd-834fa6938274", "ApplicationUser", "bit@gmail.com", true, false, null, "BIT@GMAIL.COM", "BITV@GMAIL.COM", null, null, false, "da87f73e-79f4-442a-80ec-798247e9d36e", false, "bit@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 1, 19, 19, 10, 51, 304, DateTimeKind.Local).AddTicks(17));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 1, 19, 19, 10, 51, 304, DateTimeKind.Local).AddTicks(69));
        }
    }
}
