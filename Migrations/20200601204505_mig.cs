using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityWasp.Migrations
{
    public partial class mig : Migration
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
                    value = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    currentValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    state = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    percent = table.Column<int>(nullable: false),
                    startDate = table.Column<DateTime>(nullable: false),
                    endDate = table.Column<DateTime>(nullable: false),
                    code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    length = table.Column<int>(nullable: false),
                    distance = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    state = table.Column<int>(nullable: false),
                    discountApplied = table.Column<int>(nullable: false),
                    tripCarid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.id);
                    table.ForeignKey(
                        name: "FK_Trip_Car_tripCarid",
                        column: x => x.tripCarid,
                        principalTable: "Car",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trip_tripCarid",
                table: "Trip",
                column: "tripCarid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}
