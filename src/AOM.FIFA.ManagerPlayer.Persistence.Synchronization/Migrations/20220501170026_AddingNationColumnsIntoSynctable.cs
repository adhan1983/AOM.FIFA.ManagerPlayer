using Microsoft.EntityFrameworkCore.Migrations;

namespace AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Migrations
{
    public partial class AddingNationColumnsIntoSynctable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sync",
                columns: new[] { "Id", "Name", "Synchronized", "TotalItems", "TotalItemsPerPage", "TotalPages" },
                values: new object[] { 4, "Nations", false, 160, 20, 8 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sync",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
