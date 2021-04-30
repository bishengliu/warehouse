using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Entities.Migrations
{
    public partial class changeproductname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 20, 0, 27, 812, DateTimeKind.Utc).AddTicks(4518),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 30, 19, 57, 4, 516, DateTimeKind.Utc).AddTicks(7708));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Article",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 20, 0, 27, 811, DateTimeKind.Utc).AddTicks(551),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 30, 19, 57, 4, 515, DateTimeKind.Utc).AddTicks(6037));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 19, 57, 4, 516, DateTimeKind.Utc).AddTicks(7708),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 30, 20, 0, 27, 812, DateTimeKind.Utc).AddTicks(4518));

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Product",
                type: "int",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Article",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 19, 57, 4, 515, DateTimeKind.Utc).AddTicks(6037),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 30, 20, 0, 27, 811, DateTimeKind.Utc).AddTicks(551));
        }
    }
}
