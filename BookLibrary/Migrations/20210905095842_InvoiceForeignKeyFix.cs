using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibrary.Migrations
{
    public partial class InvoiceForeignKeyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b9002c4-4666-435b-9fe5-c2e876d0f1ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f82bb9f0-9308-4517-a9ee-449681895d6b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "14ac530d-ae38-4d87-a1bb-347feb6cafba", "b481b48b-75bc-414c-b1d2-a6bc8c3a0cac", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cfc5d137-9fe5-4bf0-8e82-51e8c68d3d89", "152296f5-fa07-4fc4-ab52-75be6a3c7a7d", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "8b9002c4-4666-435b-9fe5-c2e876d0f1ac", "6b6c2ca8-5e44-4ac0-9604-322d1308f326", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f82bb9f0-9308-4517-a9ee-449681895d6b", "c3538c16-b983-4945-9895-e0c59ccf1017", "Administrator", "ADMINISTRATOR" });
        }
    }
}
