using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleRoutesBuildingWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class CoordinateOwned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Coordinates_CoordinateId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "Coordinates");

            migrationBuilder.DropIndex(
                name: "IX_Locations_CoordinateId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CoordinateId",
                table: "Locations");

            migrationBuilder.AddColumn<double>(
                name: "Coordinate_Latitude",
                table: "Locations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Coordinate_Longitude",
                table: "Locations",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coordinate_Latitude",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Coordinate_Longitude",
                table: "Locations");

            migrationBuilder.AddColumn<Guid>(
                name: "CoordinateId",
                table: "Locations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Coordinates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CoordinateId",
                table: "Locations",
                column: "CoordinateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Coordinates_CoordinateId",
                table: "Locations",
                column: "CoordinateId",
                principalTable: "Coordinates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
