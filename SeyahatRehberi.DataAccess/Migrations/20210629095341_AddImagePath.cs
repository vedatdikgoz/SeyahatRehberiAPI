using Microsoft.EntityFrameworkCore.Migrations;

namespace SeyahatRehberi.DataAccess.Migrations
{
    public partial class AddImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CityId",
                table: "Articles",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Cities_CityId",
                table: "Articles",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Cities_CityId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Users_UserId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_CityId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_UserId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Articles");
        }
    }
}
