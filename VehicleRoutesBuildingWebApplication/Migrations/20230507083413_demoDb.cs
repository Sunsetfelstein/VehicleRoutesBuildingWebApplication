using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleRoutesBuildingWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class demoDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductWeight",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    FuelConsumption = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ProductWeight",
                table: "Clients");
        }
    }
}
