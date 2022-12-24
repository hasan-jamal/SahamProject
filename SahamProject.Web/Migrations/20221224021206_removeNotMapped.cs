using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahamProject.Web.Migrations
{
    public partial class removeNotMapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07c152d2-516e-4a4f-a134-94b4387a279f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dd627d1-1e39-43f2-aaa1-831bd4cd4f44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afd1936b-cab3-4221-80ea-9280e3cd2bde");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1127b487-8f0a-42c9-af21-70bf0f3afee5", "3a13268c-f40f-467b-8adb-4be623fa2b44", "Customer ", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7c89c6c2-9082-4090-8bf1-4703433c0815", "60d0d409-2548-437f-969f-17cdca48c507", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f622993b-0419-47ae-8afb-86106e5d57e1", "2eacf917-7950-4431-bca4-4550cd068d75", "Merchant", "MERCHANT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1127b487-8f0a-42c9-af21-70bf0f3afee5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c89c6c2-9082-4090-8bf1-4703433c0815");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f622993b-0419-47ae-8afb-86106e5d57e1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07c152d2-516e-4a4f-a134-94b4387a279f", "f177cd37-3dbb-4c36-aa2a-0f52d7ff414b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5dd627d1-1e39-43f2-aaa1-831bd4cd4f44", "bf6efae4-75a8-48e5-893c-38029870f966", "Merchant", "MERCHANT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "afd1936b-cab3-4221-80ea-9280e3cd2bde", "c1635f17-d33d-442f-8a77-2dbe727ce602", "Customer ", "CUSTOMER" });
        }
    }
}
