using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamsungShops.Infrastructure.Migrations
{
    public partial class AddHotDealEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiryDate",
                table: "Discount",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 17, 2, 58, 25, 112, DateTimeKind.Local).AddTicks(3499));

            migrationBuilder.CreateTable(
                name: "HotDeal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImageFile = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    Discount = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    IsVisible = table.Column<bool>(type: "bit", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotDeal", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "cb91c776-62b3-400a-98fe-9dfd402bb944");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "fb978f0d-8b72-4a4a-9129-9fdcb0b84d27");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotDeal");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpiryDate",
                table: "Discount",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 17, 2, 58, 25, 112, DateTimeKind.Local).AddTicks(3499),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
        }
    }
}
