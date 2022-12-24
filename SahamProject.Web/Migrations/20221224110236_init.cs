using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahamProject.Web.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "IdentityUserRole<Guid>",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<Guid>", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<Guid>_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "163652e5-9812-4463-b3fc-8991dbc73bb0", "76b531c8-f1d3-4df0-bc46-fabb4cf7b4af", "Merchant", "MERCHANT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ce83e41-be4b-40ee-847b-8d36b4cffa92", "6e614d3f-3c07-4711-b47d-57c9a8dc2eb1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad21a843-e9f7-4718-9d6f-06504e5cc949", "8bb12032-1a39-4785-970c-26980b3f2549", "Customer ", "CUSTOMER" });

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserRole<Guid>_ApplicationUserId",
                table: "IdentityUserRole<Guid>",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUserRole<Guid>");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "163652e5-9812-4463-b3fc-8991dbc73bb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ce83e41-be4b-40ee-847b-8d36b4cffa92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad21a843-e9f7-4718-9d6f-06504e5cc949");

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
    }
}
