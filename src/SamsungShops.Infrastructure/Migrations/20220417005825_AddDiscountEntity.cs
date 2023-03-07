using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamsungShops.Infrastructure.Migrations
{
    public partial class AddDiscountEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 17, 2, 58, 25, 112, DateTimeKind.Local).AddTicks(3499)),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discount_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "0b1dbd73-3a25-48f7-9395-160f6696922d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "899ee179-2767-4bc1-8386-88d479875dd5");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_ProductId",
                table: "Discount",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f8b77d5b-5c98-427d-b172-3a4da98092cc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "b53c12f4-34fd-4e51-807a-5a9caa08f493");
        }
    }
}
