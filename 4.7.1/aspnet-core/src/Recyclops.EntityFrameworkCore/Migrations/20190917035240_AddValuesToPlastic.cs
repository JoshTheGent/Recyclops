using Microsoft.EntityFrameworkCore.Migrations;

namespace Recyclops.Migrations
{
    public partial class AddValuesToPlastic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HeatedBed",
                table: "Plastic",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LocationSourceId",
                table: "Plastic",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Plastic_LocationSourceId",
                table: "Plastic",
                column: "LocationSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plastic_LocationSource_LocationSourceId",
                table: "Plastic",
                column: "LocationSourceId",
                principalTable: "LocationSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plastic_LocationSource_LocationSourceId",
                table: "Plastic");

            migrationBuilder.DropIndex(
                name: "IX_Plastic_LocationSourceId",
                table: "Plastic");

            migrationBuilder.DropColumn(
                name: "HeatedBed",
                table: "Plastic");

            migrationBuilder.DropColumn(
                name: "LocationSourceId",
                table: "Plastic");
        }
    }
}
