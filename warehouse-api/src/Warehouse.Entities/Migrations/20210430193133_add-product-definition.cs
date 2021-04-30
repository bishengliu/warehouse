using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Entities.Migrations
{
    public partial class addproductdefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 19, 31, 32, 989, DateTimeKind.Utc).AddTicks(5191));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Product",
                nullable: true,
                defaultValue: "DemoUser");

            migrationBuilder.AlterColumn<int>(
                name: "Stock",
                table: "Article",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Article",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Article",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Article",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 19, 31, 32, 988, DateTimeKind.Utc).AddTicks(3534));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Article",
                nullable: true,
                defaultValue: "DemoUser");

            migrationBuilder.CreateTable(
                name: "ProductComposition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false),
                    ArticleAmount = table.Column<int>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComposition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductComposition_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductComposition_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductComposition_ArticleId",
                table: "ProductComposition",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComposition_ProductId",
                table: "ProductComposition",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductComposition");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Article");

            migrationBuilder.AlterColumn<int>(
                name: "Stock",
                table: "Article",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Article",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);
        }
    }
}
