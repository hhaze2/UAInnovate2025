using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Data.Migrations
{
    /// <inheritdoc />
    public partial class modelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Office_OfficeLocationId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRequests_Office_OfficeLocationId",
                table: "MaintenanceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRequests_UserModels_UserId",
                table: "MaintenanceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeSupplyRequests_Office_OfficeLocationId",
                table: "OfficeSupplyRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeSupplyRequests_UserModels_UserId",
                table: "OfficeSupplyRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Suggestions_Office_OfficeLocationId",
                table: "Suggestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Suggestions_UserModels_UserId",
                table: "Suggestions");

            migrationBuilder.DropIndex(
                name: "IX_Suggestions_OfficeLocationId",
                table: "Suggestions");

            migrationBuilder.DropIndex(
                name: "IX_Suggestions_UserId",
                table: "Suggestions");

            migrationBuilder.DropIndex(
                name: "IX_OfficeSupplyRequests_OfficeLocationId",
                table: "OfficeSupplyRequests");

            migrationBuilder.DropIndex(
                name: "IX_OfficeSupplyRequests_UserId",
                table: "OfficeSupplyRequests");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceRequests_OfficeLocationId",
                table: "MaintenanceRequests");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceRequests_UserId",
                table: "MaintenanceRequests");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_OfficeLocationId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "OfficeLocationId",
                table: "Suggestions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Suggestions");

            migrationBuilder.DropColumn(
                name: "OfficeLocationId",
                table: "OfficeSupplyRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OfficeSupplyRequests");

            migrationBuilder.DropColumn(
                name: "OfficeLocationId",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "OfficeLocationId",
                table: "Inventory");

            migrationBuilder.AddColumn<string>(
                name: "OfficeLocation",
                table: "Suggestions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Suggestions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfficeLocation",
                table: "OfficeSupplyRequests",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "OfficeSupplyRequests",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfficeLocation",
                table: "MaintenanceRequests",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "MaintenanceRequests",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfficeLocation",
                table: "Inventory",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfficeLocation",
                table: "Suggestions");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Suggestions");

            migrationBuilder.DropColumn(
                name: "OfficeLocation",
                table: "OfficeSupplyRequests");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "OfficeSupplyRequests");

            migrationBuilder.DropColumn(
                name: "OfficeLocation",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "OfficeLocation",
                table: "Inventory");

            migrationBuilder.AddColumn<int>(
                name: "OfficeLocationId",
                table: "Suggestions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Suggestions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfficeLocationId",
                table: "OfficeSupplyRequests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "OfficeSupplyRequests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfficeLocationId",
                table: "MaintenanceRequests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MaintenanceRequests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfficeLocationId",
                table: "Inventory",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_OfficeLocationId",
                table: "Suggestions",
                column: "OfficeLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Suggestions_UserId",
                table: "Suggestions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeSupplyRequests_OfficeLocationId",
                table: "OfficeSupplyRequests",
                column: "OfficeLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeSupplyRequests_UserId",
                table: "OfficeSupplyRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_OfficeLocationId",
                table: "MaintenanceRequests",
                column: "OfficeLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_UserId",
                table: "MaintenanceRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_OfficeLocationId",
                table: "Inventory",
                column: "OfficeLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Office_OfficeLocationId",
                table: "Inventory",
                column: "OfficeLocationId",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRequests_Office_OfficeLocationId",
                table: "MaintenanceRequests",
                column: "OfficeLocationId",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRequests_UserModels_UserId",
                table: "MaintenanceRequests",
                column: "UserId",
                principalTable: "UserModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeSupplyRequests_Office_OfficeLocationId",
                table: "OfficeSupplyRequests",
                column: "OfficeLocationId",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeSupplyRequests_UserModels_UserId",
                table: "OfficeSupplyRequests",
                column: "UserId",
                principalTable: "UserModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suggestions_Office_OfficeLocationId",
                table: "Suggestions",
                column: "OfficeLocationId",
                principalTable: "Office",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suggestions_UserModels_UserId",
                table: "Suggestions",
                column: "UserId",
                principalTable: "UserModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
