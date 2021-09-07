using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibrary.Migrations
{
    public partial class InvoiceFixRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_UserId1",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_UserId1",
                table: "Invoices");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b16ba85-69d8-491e-955d-a922cd576b77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84171cbb-f128-45b0-9f7a-4b9fdc4e35f7");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Invoices");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c09ccea7-f255-4270-a6e8-1b5d10f131a2", "71ff0f5f-968d-4ae8-b4ea-d71b50b70e39", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3a33c36-d535-47ae-ab7d-97e880c46b53", "e59dd1aa-4aa4-46a9-9d4d-e083843489f4", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c09ccea7-f255-4270-a6e8-1b5d10f131a2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3a33c36-d535-47ae-ab7d-97e880c46b53");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Invoices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2b16ba85-69d8-491e-955d-a922cd576b77", "2f9b3ea8-dc13-4374-b781-3c33727ef2f2", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84171cbb-f128-45b0-9f7a-4b9fdc4e35f7", "257a43cc-2c70-4da9-add7-ff9cf171497e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserId1",
                table: "Invoices",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_UserId1",
                table: "Invoices",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
