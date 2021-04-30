using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Entities.Migrations
{
    public partial class adddefaultvalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "DemoUser");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 19, 42, 58, 953, DateTimeKind.Utc).AddTicks(6762),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 30, 19, 31, 32, 989, DateTimeKind.Utc).AddTicks(5191));

            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "Article",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "DemoUser");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Article",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 19, 42, 58, 952, DateTimeKind.Utc).AddTicks(6579),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 30, 19, 31, 32, 988, DateTimeKind.Utc).AddTicks(3534));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "DemoUser",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 19, 31, 32, 989, DateTimeKind.Utc).AddTicks(5191),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 30, 19, 42, 58, 953, DateTimeKind.Utc).AddTicks(6762));

            migrationBuilder.AlterColumn<string>(
                name: "UpdateBy",
                table: "Article",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "DemoUser",
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Article",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 19, 31, 32, 988, DateTimeKind.Utc).AddTicks(3534),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 30, 19, 42, 58, 952, DateTimeKind.Utc).AddTicks(6579));
        }
    }
}
