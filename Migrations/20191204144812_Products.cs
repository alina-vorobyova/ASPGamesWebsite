using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesSearchAsp.Migrations
{
    public partial class Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GamePlatforms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlatforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    GamePlatformId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameProducts_GamePlatforms_GamePlatformId",
                        column: x => x.GamePlatformId,
                        principalTable: "GamePlatforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameProducts_GamePlatformId",
                table: "GameProducts",
                column: "GamePlatformId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameProducts");

            migrationBuilder.DropTable(
                name: "GamePlatforms");
        }
    }
}
