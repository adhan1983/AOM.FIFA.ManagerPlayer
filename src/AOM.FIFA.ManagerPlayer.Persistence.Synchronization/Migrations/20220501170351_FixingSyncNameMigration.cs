using Microsoft.EntityFrameworkCore.Migrations;

namespace AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Migrations
{
    public partial class FixingSyncNameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sync",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Player");

            migrationBuilder.UpdateData(
                table: "Sync",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Nation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sync",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Players");

            migrationBuilder.UpdateData(
                table: "Sync",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Nations");
        }
    }
}
