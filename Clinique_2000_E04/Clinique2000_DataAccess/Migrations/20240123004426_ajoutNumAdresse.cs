using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class ajoutNumAdresse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                column: "Numero",
                value: "123");

            migrationBuilder.UpdateData(
                table: "Adresses",
                keyColumn: "AdresseID",
                keyValue: 2,
                column: "Numero",
                value: "456");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Adresses");
        }
    }
}
