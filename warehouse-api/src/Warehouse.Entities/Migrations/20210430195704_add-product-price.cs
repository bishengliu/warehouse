using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Entities.Migrations
{
    public partial class addproductprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ProductComposition",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 19, 57, 4, 516, DateTimeKind.Utc).AddTicks(7708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 30, 19, 42, 58, 953, DateTimeKind.Utc).AddTicks(6762));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Article",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 19, 57, 4, 515, DateTimeKind.Utc).AddTicks(6037),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 30, 19, 42, 58, 952, DateTimeKind.Utc).AddTicks(6579));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductComposition");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 19, 42, 58, 953, DateTimeKind.Utc).AddTicks(6762),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 30, 19, 57, 4, 516, DateTimeKind.Utc).AddTicks(7708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Article",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 19, 42, 58, 952, DateTimeKind.Utc).AddTicks(6579),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 30, 19, 57, 4, 515, DateTimeKind.Utc).AddTicks(6037));
        }
    }
}
