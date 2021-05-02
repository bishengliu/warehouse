using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Entities.Migrations
{
    public partial class addproductstock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "ProductDefinition",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 21, 29, 46, 662, DateTimeKind.Utc).AddTicks(9150),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 30, 20, 12, 30, 377, DateTimeKind.Utc).AddTicks(5885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 21, 29, 46, 655, DateTimeKind.Utc).AddTicks(4413),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 30, 20, 12, 30, 369, DateTimeKind.Utc).AddTicks(1491));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Article",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 21, 29, 46, 654, DateTimeKind.Utc).AddTicks(3885),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 30, 20, 12, 30, 368, DateTimeKind.Utc).AddTicks(1641));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "ProductDefinition",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 20, 12, 30, 377, DateTimeKind.Utc).AddTicks(5885),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 30, 21, 29, 46, 662, DateTimeKind.Utc).AddTicks(9150));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 20, 12, 30, 369, DateTimeKind.Utc).AddTicks(1491),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 30, 21, 29, 46, 655, DateTimeKind.Utc).AddTicks(4413));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Article",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 20, 12, 30, 368, DateTimeKind.Utc).AddTicks(1641),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 30, 21, 29, 46, 654, DateTimeKind.Utc).AddTicks(3885));
        }
    }
}
