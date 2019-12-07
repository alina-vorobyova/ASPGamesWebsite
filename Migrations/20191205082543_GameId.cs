using Microsoft.EntityFrameworkCore.Migrations;

namespace GamesSearchAsp.Migrations
{
    public partial class GameId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "GameProducts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameId",
                table: "GameProducts");
        }
    }
}
