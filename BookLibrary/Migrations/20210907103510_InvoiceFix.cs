using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibrary.Migrations
{
    public partial class InvoiceFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd7a3e77-bcd0-4495-b3ad-933b8feb975f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0be786b-4221-4cd9-98b6-ed7297e426c8");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "d0be786b-4221-4cd9-98b6-ed7297e426c8", "ec40821d-26d9-449c-872f-e9218259cf59", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd7a3e77-bcd0-4495-b3ad-933b8feb975f", "a2f158e6-2bd9-449b-9029-7766b6eb38f1", "Administrator", "ADMINISTRATOR" });
        }
    }
}
