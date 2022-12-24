using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahamProject.Web.Migrations
{
    public partial class towForgenKeyForTheSameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "MerchanId",
                table: "Shipments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Shipments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_CustomerId",
                table: "Shipments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_MerchanId",
                table: "Shipments",
                column: "MerchanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_AspNetUsers_CustomerId",
                table: "Shipments",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_AspNetUsers_MerchanId",
                table: "Shipments",
                column: "MerchanId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_AspNetUsers_CustomerId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_AspNetUsers_MerchanId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_CustomerId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_MerchanId",
                table: "Shipments");

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

            migrationBuilder.AlterColumn<string>(
                name: "MerchanId",
                table: "Shipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Shipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
    }
}
