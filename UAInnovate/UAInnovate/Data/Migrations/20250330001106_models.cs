using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Data.Migrations
{
    /// <inheritdoc />
    public partial class models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemName = table.Column<string>(type: "TEXT", nullable: false),
                    OfficeLocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    AvgAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    LastOrdered = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Office_OfficeLocationId",
                        column: x => x.OfficeLocationId,
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficeSupplyRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    OfficeLocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemName = table.Column<string>(type: "TEXT", nullable: false),
                    CurrStock = table.Column<int>(type: "INTEGER", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "TEXT", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeSupplyRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficeSupplyRequests_Office_OfficeLocationId",
                        column: x => x.OfficeLocationId,
                        principalTable: "Office",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficeSupplyRequests_UserModels_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_OfficeLocationId",
                table: "Inventory",
                column: "OfficeLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeSupplyRequests_OfficeLocationId",
                table: "OfficeSupplyRequests",
                column: "OfficeLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeSupplyRequests_UserId",
                table: "OfficeSupplyRequests",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "OfficeSupplyRequests");
        }
    }
}
