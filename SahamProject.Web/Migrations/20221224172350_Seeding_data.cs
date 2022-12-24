using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahamProject.Web.Migrations
{
    public partial class Seeding_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "043114d0-4fb6-4f25-ac30-e0a1b32ddfbf", "54cfe117-ba81-4483-86d2-ba2d08d54107", "Merchant", "MERCHANT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31ce0219-ccea-44e7-b714-ed5b6a20e2b9", "a43ba216-a58c-42de-ad9a-13ac9e2e82f0", "Customer ", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49683740-9f88-43d3-9083-49370dee79ef", "75932473-6b49-4247-b010-8a4fec0da355", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "043114d0-4fb6-4f25-ac30-e0a1b32ddfbf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31ce0219-ccea-44e7-b714-ed5b6a20e2b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49683740-9f88-43d3-9083-49370dee79ef");
        }
    }
}
