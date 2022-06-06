using Microsoft.EntityFrameworkCore.Migrations;

namespace AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Migrations
{
    public partial class SynchronizedColumInTableSyncMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Synchronized",
                table: "Sync",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Synchronized",
                table: "Sync");
        }
    }
}
