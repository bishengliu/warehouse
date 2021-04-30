using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Entities.Migrations
{
    public partial class addarticleprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "ProductDefinition",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 23, 23, 30, 3, DateTimeKind.Utc).AddTicks(315),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 30, 21, 29, 46, 662, DateTimeKind.Utc).AddTicks(9150));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 23, 23, 29, 995, DateTimeKind.Utc).AddTicks(2399),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 30, 21, 29, 46, 655, DateTimeKind.Utc).AddTicks(4413));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Article",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 23, 23, 29, 994, DateTimeKind.Utc).AddTicks(1030),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 30, 21, 29, 46, 654, DateTimeKind.Utc).AddTicks(3885));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Article",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Article");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "ProductDefinition",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 21, 29, 46, 662, DateTimeKind.Utc).AddTicks(9150),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 30, 23, 23, 30, 3, DateTimeKind.Utc).AddTicks(315));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 21, 29, 46, 655, DateTimeKind.Utc).AddTicks(4413),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 30, 23, 23, 29, 995, DateTimeKind.Utc).AddTicks(2399));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Article",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 21, 29, 46, 654, DateTimeKind.Utc).AddTicks(3885),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 30, 23, 23, 29, 994, DateTimeKind.Utc).AddTicks(1030));
        }
    }
}
