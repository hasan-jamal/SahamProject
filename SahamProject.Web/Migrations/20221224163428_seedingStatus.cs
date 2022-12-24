using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahamProject.Web.Migrations
{
    public partial class seedingStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "870e8495-9241-4a59-a93d-ac3755cd8881");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b721f8a1-3de8-49fe-be4e-97df7e421647");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6d2cabb-aa5d-4eba-a393-aa55f389b104");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a3c5505-4655-49b9-9cb4-7ab858705185", "aff9bcd9-8073-4b6e-a95f-a2e75dd8f197", "Admin", "ADMIN" },
                    { "589ce15f-9786-4d41-9f37-5e18461cde02", "c1ae68ae-a77c-4d6d-a833-69bc09b33be1", "Customer ", "CUSTOMER" },
                    { "b3ffb635-fddb-4004-aa8e-3896df7d144a", "0fe3fea7-0463-4b14-99b3-0e4d76983364", "Merchant", "MERCHANT" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Begin" },
                    { 2, "InPrgoress" },
                    { 3, "Done" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a3c5505-4655-49b9-9cb4-7ab858705185");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "589ce15f-9786-4d41-9f37-5e18461cde02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3ffb635-fddb-4004-aa8e-3896df7d144a");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "870e8495-9241-4a59-a93d-ac3755cd8881", "78e61fe5-4776-4756-8d0b-d6ce3d337aed", "Merchant", "MERCHANT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b721f8a1-3de8-49fe-be4e-97df7e421647", "24c3c2d2-a5e2-4b8a-abe2-dc138dd7fab1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c6d2cabb-aa5d-4eba-a393-aa55f389b104", "f2164389-ece7-495c-b8dd-4b192442ceb1", "Customer ", "CUSTOMER" });
        }
    }
}
