using Microsoft.EntityFrameworkCore.Migrations;

namespace Recyclops.Migrations
{
    public partial class URL_For_LocationSource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "LocationSource",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "URL",
                table: "LocationSource");
        }
    }
}
