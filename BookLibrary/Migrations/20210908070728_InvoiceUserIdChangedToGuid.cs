using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibrary.Migrations
{
    public partial class InvoiceUserIdChangedToGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ebfc4ac-7a03-4d08-8634-9dea6badee72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd88ce53-31ad-4ef2-94bd-3dbcf3c025e8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f580308-6ac2-4646-a5f0-7e2a332e11d4", "989f5151-c3ce-4679-9adf-fda203aca8a5", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6cad01da-a4e3-4ea9-a250-99fe181e2a22", "fd5714dd-4e11-431d-a392-938b19690efc", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cad01da-a4e3-4ea9-a250-99fe181e2a22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f580308-6ac2-4646-a5f0-7e2a332e11d4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd88ce53-31ad-4ef2-94bd-3dbcf3c025e8", "78fdbdc1-5de2-458d-a0bb-c9606086b956", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ebfc4ac-7a03-4d08-8634-9dea6badee72", "0ab0389f-44e7-4114-92e4-108f0d3d09eb", "Administrator", "ADMINISTRATOR" });
        }
    }
}
