using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinique2000_DataAccess.Migrations
{
    public partial class FixPropNav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListeAttenteID",
                table: "Consultations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_ListeAttenteID",
                table: "Consultations",
                column: "ListeAttenteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_ListeAttentes_ListeAttenteID",
                table: "Consultations",
                column: "ListeAttenteID",
                principalTable: "ListeAttentes",
                principalColumn: "ListeAttenteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_ListeAttentes_ListeAttenteID",
                table: "Consultations");

            migrationBuilder.DropIndex(
                name: "IX_Consultations_ListeAttenteID",
                table: "Consultations");

            migrationBuilder.DropColumn(
                name: "ListeAttenteID",
                table: "Consultations");
        }
    }
}
