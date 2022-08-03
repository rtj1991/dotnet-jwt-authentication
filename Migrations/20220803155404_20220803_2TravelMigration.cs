using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.Migrations
{
    public partial class _20220803_2TravelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_MyTrips_MyTripsId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_MyTripsId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "MyTripsId",
                table: "Places");

            migrationBuilder.CreateIndex(
                name: "IX_Places_TripId",
                table: "Places",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_MyTrips_TripId",
                table: "Places",
                column: "TripId",
                principalTable: "MyTrips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_MyTrips_TripId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_TripId",
                table: "Places");

            migrationBuilder.AddColumn<int>(
                name: "MyTripsId",
                table: "Places",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Places_MyTripsId",
                table: "Places",
                column: "MyTripsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_MyTrips_MyTripsId",
                table: "Places",
                column: "MyTripsId",
                principalTable: "MyTrips",
                principalColumn: "Id");
        }
    }
}
