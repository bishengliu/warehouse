using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Warehouse.Entities.Migrations
{
    public partial class changetablenameproductdefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductComposition");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 20, 12, 30, 369, DateTimeKind.Utc).AddTicks(1491),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 30, 20, 0, 27, 812, DateTimeKind.Utc).AddTicks(4518));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Article",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 20, 12, 30, 368, DateTimeKind.Utc).AddTicks(1641),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 30, 20, 0, 27, 811, DateTimeKind.Utc).AddTicks(551));

            migrationBuilder.CreateTable(
                name: "ProductDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    ArticleId = table.Column<int>(nullable: false),
                    ArticleAmount = table.Column<int>(nullable: false, defaultValue: 1),
                    UpdateAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 4, 30, 20, 12, 30, 377, DateTimeKind.Utc).AddTicks(5885)),
                    UpdateBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_ProductCompositions",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductCompositions",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDefinition_ArticleId",
                table: "ProductDefinition",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDefinition_ProductId_ArticleId",
                table: "ProductDefinition",
                columns: new[] { "ProductId", "ArticleId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDefinition");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 20, 0, 27, 812, DateTimeKind.Utc).AddTicks(4518),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 30, 20, 12, 30, 369, DateTimeKind.Utc).AddTicks(1491));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                table: "Article",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 30, 20, 0, 27, 811, DateTimeKind.Utc).AddTicks(551),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 30, 20, 12, 30, 368, DateTimeKind.Utc).AddTicks(1641));

            migrationBuilder.CreateTable(
                name: "ProductComposition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleAmount = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
    }
}
