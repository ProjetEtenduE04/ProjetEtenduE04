using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "636181b7-361f-4197-85ca-bc9edc93327a", "35fb0ad9-baaf-45aa-a0d4-e9bd7fd0a747" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 1, 19, 22, 17, 40, 482, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 1, 19, 22, 17, 40, 482, DateTimeKind.Local).AddTicks(3381));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cc96785-8933-4eac-8d7f-a289b28df223",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "dd968801-caf3-46bd-b8f0-7778be901e36", "15a9d36b-2d49-4ac2-8572-35ab457e5fdb" });

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 1,
                column: "DateCreation",
                value: new DateTime(2024, 1, 19, 22, 13, 33, 226, DateTimeKind.Local).AddTicks(3782));

            migrationBuilder.UpdateData(
                table: "Cliniques",
                keyColumn: "CliniqueID",
                keyValue: 2,
                column: "DateCreation",
                value: new DateTime(2024, 1, 19, 22, 13, 33, 226, DateTimeKind.Local).AddTicks(3852));
        }
    }
}
