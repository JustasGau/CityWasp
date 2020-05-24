using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityWasp.Migrations
{
    public partial class TripMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "assignedDiscountid",
                table: "Trip",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "Trip",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "distance",
                table: "Trip",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "length",
                table: "Trip",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "Trip",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "state",
                table: "Trip",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tripCarid",
                table: "Trip",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trip_assignedDiscountid",
                table: "Trip",
                column: "assignedDiscountid");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_tripCarid",
                table: "Trip",
                column: "tripCarid");

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Discount_assignedDiscountid",
                table: "Trip",
                column: "assignedDiscountid",
                principalTable: "Discount",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trip_Car_tripCarid",
                table: "Trip",
                column: "tripCarid",
                principalTable: "Car",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Discount_assignedDiscountid",
                table: "Trip");

            migrationBuilder.DropForeignKey(
                name: "FK_Trip_Car_tripCarid",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Trip_assignedDiscountid",
                table: "Trip");

            migrationBuilder.DropIndex(
                name: "IX_Trip_tripCarid",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "assignedDiscountid",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "date",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "distance",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "length",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "price",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "state",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "tripCarid",
                table: "Trip");
        }
    }
}
