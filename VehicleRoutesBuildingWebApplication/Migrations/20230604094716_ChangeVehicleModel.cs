using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleRoutesBuildingWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class ChangeVehicleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Iterations",
                table: "Vehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iterations",
                table: "Vehicles");
        }
    }
}
