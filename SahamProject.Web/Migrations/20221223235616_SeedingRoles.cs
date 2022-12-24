using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahamProject.Web.Migrations
{
    public partial class SeedingRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d40046c-019a-4ac8-ad48-ce8e1a527ba5", "66bde893-2bd0-46a7-9738-85112c0ea243", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e59ce90-ed76-4fbc-b2b9-32b088bab7f5", "b375b965-ba3b-4f21-b382-0ae01d0251a0", "Merchant", "MERCHANT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c112637d-caa7-4393-a321-bcede9b59627", "c397e973-295e-42d0-853e-c9cfe827fc3a", "Customer ", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d40046c-019a-4ac8-ad48-ce8e1a527ba5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e59ce90-ed76-4fbc-b2b9-32b088bab7f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c112637d-caa7-4393-a321-bcede9b59627");
        }
    }
}
