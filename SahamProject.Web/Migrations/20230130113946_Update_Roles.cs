using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahamProject.Web.Migrations
{
    public partial class Update_Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Width",
                table: "ShipmentsProducts",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "ShipmentsProducts",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Length",
                table: "ShipmentsProducts",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "ShipmentsProducts",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67da6857-770f-4bb7-89b6-ea74d068522c", "b964f375-6c2a-480f-a4c6-d3df5dbaf8bf", "Merchant", "MERCHANT" },
                    { "a5761da7-a17f-48fa-bcd3-aa25d7b75d15", "0bc1cca7-2639-48db-a5f6-c6170c127a84", "Customer ", "CUSTOMER" },
                    { "c3a2cde1-caac-4a6c-a24f-1b5d35b47f59", "71a00493-b5ea-46da-8d57-89686a308847", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Area", "BuildingNumber", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "IsActive", "Location", "LocationMap", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "ShortAddress", "StoreNo", "StreetName1", "StreetName2", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a18be9c0-aa65-4af8-bd17-00bd4354e575", 0, null, null, null, "9fc10f5f-abb1-4894-b6bd-1f26594207a1", null, "customer@saham.com", true, true, null, null, false, null, "Customer", "customer@saham.com", "customer", "AQAAAAEAACcQAAAAEJ8tn5goWtbknKgYHhI0hqkHm9jUyCOjHnAZy8NxSU8WWtNcWH3heoomYqDOFLdFrg==", null, false, "", null, null, null, null, false, "customer" },
                    { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, null, null, null, "b39a2313-a7d8-490e-a83f-b53eea96c667", null, "admin@saham.com", true, true, null, null, false, null, "Admin", "admin@saham.com", "adminNew", "AQAAAAEAACcQAAAAEAnoeAFdYM+pRmXZ/xnJd+eEBvs7mWJQbNrjRSwGkrntgYb4OWp5JDFt33hFHTMvJA==", null, false, "", null, null, null, null, false, "adminNew" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a5761da7-a17f-48fa-bcd3-aa25d7b75d15", "a18be9c0-aa65-4af8-bd17-00bd4354e575" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c3a2cde1-caac-4a6c-a24f-1b5d35b47f59", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67da6857-770f-4bb7-89b6-ea74d068522c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a5761da7-a17f-48fa-bcd3-aa25d7b75d15", "a18be9c0-aa65-4af8-bd17-00bd4354e575" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c3a2cde1-caac-4a6c-a24f-1b5d35b47f59", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5761da7-a17f-48fa-bcd3-aa25d7b75d15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3a2cde1-caac-4a6c-a24f-1b5d35b47f59");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd4354e575");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575");

            migrationBuilder.AlterColumn<string>(
                name: "Width",
                table: "ShipmentsProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Weight",
                table: "ShipmentsProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Length",
                table: "ShipmentsProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Height",
                table: "ShipmentsProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

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
    }
}
