using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityWasp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    model = table.Column<string>(nullable: true),
                    manufacturer = table.Column<string>(nullable: true),
                    coordinates = table.Column<string>(nullable: true),
                    mileage = table.Column<string>(nullable: true),
                    techincal = table.Column<DateTime>(nullable: false),
                    value = table.Column<decimal>(nullable: false),
                    currentValue = table.Column<decimal>(nullable: false),
                    state = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}
