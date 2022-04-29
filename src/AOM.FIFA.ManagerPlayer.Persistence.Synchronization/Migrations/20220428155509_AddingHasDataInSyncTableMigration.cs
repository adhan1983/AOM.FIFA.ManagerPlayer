using Microsoft.EntityFrameworkCore.Migrations;

namespace AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Migrations
{
    public partial class AddingHasDataInSyncTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sync",
                columns: new[] { "Id", "Name", "TotalItems", "TotalItemsPerPage", "TotalPages" },
                values: new object[] { 1, "League", 49, 20, 3 });

            migrationBuilder.InsertData(
                table: "Sync",
                columns: new[] { "Id", "Name", "TotalItems", "TotalItemsPerPage", "TotalPages" },
                values: new object[] { 2, "Club", 674, 20, 34 });

            migrationBuilder.InsertData(
                table: "Sync",
                columns: new[] { "Id", "Name", "TotalItems", "TotalItemsPerPage", "TotalPages" },
                values: new object[] { 3, "Players", 20617, 20, 1031 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sync",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sync",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sync",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
