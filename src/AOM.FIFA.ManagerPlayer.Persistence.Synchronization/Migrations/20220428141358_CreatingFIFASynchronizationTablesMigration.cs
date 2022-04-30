using Microsoft.EntityFrameworkCore.Migrations;

namespace AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Migrations
{
    public partial class CreatingFIFASynchronizationTablesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sync",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TotalItems = table.Column<int>(type: "int", nullable: false),
                    TotalPages = table.Column<int>(type: "int", nullable: false),
                    TotalItemsPerPage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sync", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SyncPage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Page = table.Column<int>(type: "int", nullable: false),
                    TotalSynchronized = table.Column<int>(type: "int", nullable: false),
                    TotalDosNotSynchronized = table.Column<int>(type: "int", nullable: false),
                    SyncPageSuccess = table.Column<bool>(type: "bit", nullable: false),
                    SyncId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncPage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SyncPage_Sync_SyncId",
                        column: x => x.SyncId,
                        principalTable: "Sync",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SourceWithoutSync",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    SyncPageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceWithoutSync", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SourceWithoutSync_SyncPage_SyncPageId",
                        column: x => x.SyncPageId,
                        principalTable: "SyncPage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SourceWithoutSync_SyncPageId",
                table: "SourceWithoutSync",
                column: "SyncPageId");

            migrationBuilder.CreateIndex(
                name: "IX_SyncPage_SyncId",
                table: "SyncPage",
                column: "SyncId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SourceWithoutSync");

            migrationBuilder.DropTable(
                name: "SyncPage");

            migrationBuilder.DropTable(
                name: "Sync");
        }
    }
}
