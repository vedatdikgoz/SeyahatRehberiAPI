using Microsoft.EntityFrameworkCore.Migrations;

namespace SeyahatRehberi.DataAccess.Migrations
{
    public partial class DefaultInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Articles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
