using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Data.Migrations
{
    /// <inheritdoc />
    public partial class userModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserModels_Office_WorkLocationId",
                table: "UserModels");

            migrationBuilder.DropIndex(
                name: "IX_UserModels_WorkLocationId",
                table: "UserModels");

            migrationBuilder.DropColumn(
                name: "WorkLocationId",
                table: "UserModels");

            migrationBuilder.AddColumn<string>(
                name: "WorkLocation",
                table: "UserModels",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkLocation",
                table: "UserModels");

            migrationBuilder.AddColumn<int>(
                name: "WorkLocationId",
                table: "UserModels",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserModels_WorkLocationId",
                table: "UserModels",
                column: "WorkLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserModels_Office_WorkLocationId",
                table: "UserModels",
                column: "WorkLocationId",
                principalTable: "Office",
                principalColumn: "Id");
        }
    }
}
