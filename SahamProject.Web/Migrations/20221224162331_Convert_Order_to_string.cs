using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SahamProject.Web.Migrations
{
    public partial class Convert_Order_to_string : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<Guid>_AspNetUsers_ApplicationUserId",
                table: "IdentityUserRole<Guid>");

            migrationBuilder.DropIndex(
                name: "IX_IdentityUserRole<Guid>_ApplicationUserId",
                table: "IdentityUserRole<Guid>");

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

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "IdentityUserRole<Guid>");

            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                table: "Shipments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "OrderNumber",
                table: "Shipments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "IdentityUserRole<Guid>",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<Guid>_AspNetUsers_ApplicationUserId",
                table: "IdentityUserRole<Guid>",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
