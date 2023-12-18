using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ok.Migrations
{
    /// <inheritdoc />
    public partial class nome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appunti_Login_UtentiidUtente",
                table: "Appunti");

            migrationBuilder.DropIndex(
                name: "IX_Appunti_UtentiidUtente",
                table: "Appunti");

            migrationBuilder.DropColumn(
                name: "UtentiidUtente",
                table: "Appunti");

            migrationBuilder.CreateIndex(
                name: "IX_Appunti_idUtente",
                table: "Appunti",
                column: "idUtente");

            migrationBuilder.AddForeignKey(
                name: "FK_Appunti_Login_idUtente",
                table: "Appunti",
                column: "idUtente",
                principalTable: "Login",
                principalColumn: "idUtente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appunti_Login_idUtente",
                table: "Appunti");

            migrationBuilder.DropIndex(
                name: "IX_Appunti_idUtente",
                table: "Appunti");

            migrationBuilder.AddColumn<int>(
                name: "UtentiidUtente",
                table: "Appunti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appunti_UtentiidUtente",
                table: "Appunti",
                column: "UtentiidUtente");

            migrationBuilder.AddForeignKey(
                name: "FK_Appunti_Login_UtentiidUtente",
                table: "Appunti",
                column: "UtentiidUtente",
                principalTable: "Login",
                principalColumn: "idUtente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
