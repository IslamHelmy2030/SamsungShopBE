using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamsungShops.Infrastructure.Migrations
{
    public partial class AddSeedDataToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "eeafe50b-b546-41dd-ada8-d51d3b0afffe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "f6b9a23b-a916-48c3-b06b-0002dc976e2f");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsVisible", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Category", true, null, null, "Mobile" },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Category", true, null, null, "Refrigerator" },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Microwave Category", true, null, null, "Microwave" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "6616b2ac-9dff-4971-89ad-d7d8382ca7c7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "89f5b455-3e13-41db-989a-d60a8f96d188");
        }
    }
}
