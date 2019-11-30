using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Recyclops.Migrations
{
    public partial class allDomains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlasticSpoolId",
                table: "PrintableObjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PrintCost",
                table: "PrintableObjects",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "PrintTime",
                table: "PrintableObjects",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<double>(
                name: "SellValue",
                table: "PrintableObjects",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "AbpUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TotalCost = table.Column<double>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    ClientId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AbpUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlasticSpool",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TimeToManufacture = table.Column<TimeSpan>(nullable: false),
                    Mass = table.Column<int>(nullable: false),
                    ManufactureCost = table.Column<double>(nullable: false),
                    SellValue = table.Column<double>(nullable: false),
                    PlasticId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlasticSpool", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlasticSpool_Plastic_PlasticId",
                        column: x => x.PlasticId,
                        principalTable: "Plastic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrintableOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DerivedTotal = table.Column<double>(nullable: false),
                    PrintableObjectId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintableOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrintableOrder_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrintableOrder_PrintableObjects_PrintableObjectId",
                        column: x => x.PrintableObjectId,
                        principalTable: "PrintableObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlasticOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DerivedTotal = table.Column<double>(nullable: false),
                    PlasticSpoolId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlasticOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlasticOrder_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlasticOrder_PlasticSpool_PlasticSpoolId",
                        column: x => x.PlasticSpoolId,
                        principalTable: "PlasticSpool",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrintableObjects_PlasticSpoolId",
                table: "PrintableObjects",
                column: "PlasticSpoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientId",
                table: "Order",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticOrder_OrderId",
                table: "PlasticOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticOrder_PlasticSpoolId",
                table: "PlasticOrder",
                column: "PlasticSpoolId");

            migrationBuilder.CreateIndex(
                name: "IX_PlasticSpool_PlasticId",
                table: "PlasticSpool",
                column: "PlasticId");

            migrationBuilder.CreateIndex(
                name: "IX_PrintableOrder_OrderId",
                table: "PrintableOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PrintableOrder_PrintableObjectId",
                table: "PrintableOrder",
                column: "PrintableObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrintableObjects_PlasticSpool_PlasticSpoolId",
                table: "PrintableObjects",
                column: "PlasticSpoolId",
                principalTable: "PlasticSpool",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrintableObjects_PlasticSpool_PlasticSpoolId",
                table: "PrintableObjects");

            migrationBuilder.DropTable(
                name: "PlasticOrder");

            migrationBuilder.DropTable(
                name: "PrintableOrder");

            migrationBuilder.DropTable(
                name: "PlasticSpool");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropIndex(
                name: "IX_PrintableObjects_PlasticSpoolId",
                table: "PrintableObjects");

            migrationBuilder.DropColumn(
                name: "PlasticSpoolId",
                table: "PrintableObjects");

            migrationBuilder.DropColumn(
                name: "PrintCost",
                table: "PrintableObjects");

            migrationBuilder.DropColumn(
                name: "PrintTime",
                table: "PrintableObjects");

            migrationBuilder.DropColumn(
                name: "SellValue",
                table: "PrintableObjects");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "AbpUsers");
        }
    }
}
