using Microsoft.EntityFrameworkCore.Migrations;

namespace Recyclops.Migrations
{
    public partial class remove_totals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DerivedTotal",
                table: "PrintableOrder");

            migrationBuilder.DropColumn(
                name: "DerivedTotal",
                table: "PlasticOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DerivedTotal",
                table: "PrintableOrder",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DerivedTotal",
                table: "PlasticOrder",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
