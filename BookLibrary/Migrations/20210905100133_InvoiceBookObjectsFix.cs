using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibrary.Migrations
{
    public partial class InvoiceBookObjectsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14ac530d-ae38-4d87-a1bb-347feb6cafba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfc5d137-9fe5-4bf0-8e82-51e8c68d3d89");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c18eec7-91e2-4052-8cf8-7808eb9a1747", "61d68504-6f32-49b0-a127-8055e3f455c5", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c5f8b28-0c72-42cd-9296-4180ba7c7c01", "c2eee848-a647-4817-b65c-fbbd1112ebb9", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c18eec7-91e2-4052-8cf8-7808eb9a1747");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c5f8b28-0c72-42cd-9296-4180ba7c7c01");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "14ac530d-ae38-4d87-a1bb-347feb6cafba", "b481b48b-75bc-414c-b1d2-a6bc8c3a0cac", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cfc5d137-9fe5-4bf0-8e82-51e8c68d3d89", "152296f5-fa07-4fc4-ab52-75be6a3c7a7d", "Administrator", "ADMINISTRATOR" });
        }
    }
}
