using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.Migrations
{
    public partial class _20220803_1TravelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_MyTrips_MyTripId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_FCreatedUsersUserId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "MyTripId",
                table: "Reviews",
                newName: "ReviewersId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_MyTripId",
                table: "Reviews",
                newName: "IX_Reviews_ReviewersId");

            migrationBuilder.AlterColumn<int>(
                name: "FCreatedUsersUserId",
                table: "Reviews",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "Reviewer",
                table: "Reviews",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "Places",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_MyTrips_ReviewersId",
                table: "Reviews",
                column: "ReviewersId",
                principalTable: "MyTrips",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_FCreatedUsersUserId",
                table: "Reviews",
                column: "FCreatedUsersUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_MyTrips_ReviewersId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_FCreatedUsersUserId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Reviewer",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ReviewersId",
                table: "Reviews",
                newName: "MyTripId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_ReviewersId",
                table: "Reviews",
                newName: "IX_Reviews_MyTripId");

            migrationBuilder.AlterColumn<int>(
                name: "FCreatedUsersUserId",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "Places",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_MyTrips_MyTripId",
                table: "Reviews",
                column: "MyTripId",
                principalTable: "MyTrips",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_FCreatedUsersUserId",
                table: "Reviews",
                column: "FCreatedUsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
