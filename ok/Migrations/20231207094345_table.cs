using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ok.Migrations
{
    /// <inheritdoc />
    public partial class table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "aziende",
                newName: "titolo");

            migrationBuilder.AddColumn<int>(
                name: "UtentiidUtente",
                table: "aziende",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "data",
                table: "aziende",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "descrizione",
                table: "aziende",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idUtente",
                table: "aziende",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    idUtente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.idUtente);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aziende_UtentiidUtente",
                table: "aziende",
                column: "UtentiidUtente");

            migrationBuilder.AddForeignKey(
                name: "FK_aziende_Login_UtentiidUtente",
                table: "aziende",
                column: "UtentiidUtente",
                principalTable: "Login",
                principalColumn: "idUtente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aziende_Login_UtentiidUtente",
                table: "aziende");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropIndex(
                name: "IX_aziende_UtentiidUtente",
                table: "aziende");

            migrationBuilder.DropColumn(
                name: "UtentiidUtente",
                table: "aziende");

            migrationBuilder.DropColumn(
                name: "data",
                table: "aziende");

            migrationBuilder.DropColumn(
                name: "descrizione",
                table: "aziende");

            migrationBuilder.DropColumn(
                name: "idUtente",
                table: "aziende");

            migrationBuilder.RenameColumn(
                name: "titolo",
                table: "aziende",
                newName: "name");
        }
    }
}
