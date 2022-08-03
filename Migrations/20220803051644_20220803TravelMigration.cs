using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.Migrations
{
    public partial class _20220803TravelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyTrips_Users_MCreatedUsersUserId",
                table: "MyTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_MyTrips_ReviewersId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ReviewersId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewersId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "Reviewer",
                table: "Reviews",
                newName: "MyTripId");

            migrationBuilder.AlterColumn<int>(
                name: "MCreatedUsersUserId",
                table: "MyTrips",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MyTripId",
                table: "Reviews",
                column: "MyTripId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyTrips_Users_MCreatedUsersUserId",
                table: "MyTrips",
                column: "MCreatedUsersUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_MyTrips_MyTripId",
                table: "Reviews",
                column: "MyTripId",
                principalTable: "MyTrips",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyTrips_Users_MCreatedUsersUserId",
                table: "MyTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_MyTrips_MyTripId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_MyTripId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "MyTripId",
                table: "Reviews",
                newName: "Reviewer");

            migrationBuilder.AddColumn<int>(
                name: "ReviewersId",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MCreatedUsersUserId",
                table: "MyTrips",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewersId",
                table: "Reviews",
                column: "ReviewersId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyTrips_Users_MCreatedUsersUserId",
                table: "MyTrips",
                column: "MCreatedUsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_MyTrips_ReviewersId",
                table: "Reviews",
                column: "ReviewersId",
                principalTable: "MyTrips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
