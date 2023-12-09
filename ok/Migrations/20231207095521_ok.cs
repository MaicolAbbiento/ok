using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ok.Migrations
{
    /// <inheritdoc />
    public partial class ok : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aziende_Login_UtentiidUtente",
                table: "aziende");

            migrationBuilder.DropPrimaryKey(
                name: "PK_aziende",
                table: "aziende");

            migrationBuilder.RenameTable(
                name: "aziende",
                newName: "Appunti");

            migrationBuilder.RenameIndex(
                name: "IX_aziende_UtentiidUtente",
                table: "Appunti",
                newName: "IX_Appunti_UtentiidUtente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appunti",
                table: "Appunti",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appunti_Login_UtentiidUtente",
                table: "Appunti",
                column: "UtentiidUtente",
                principalTable: "Login",
                principalColumn: "idUtente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appunti_Login_UtentiidUtente",
                table: "Appunti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appunti",
                table: "Appunti");

            migrationBuilder.RenameTable(
                name: "Appunti",
                newName: "aziende");

            migrationBuilder.RenameIndex(
                name: "IX_Appunti_UtentiidUtente",
                table: "aziende",
                newName: "IX_aziende_UtentiidUtente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_aziende",
                table: "aziende",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_aziende_Login_UtentiidUtente",
                table: "aziende",
                column: "UtentiidUtente",
                principalTable: "Login",
                principalColumn: "idUtente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
