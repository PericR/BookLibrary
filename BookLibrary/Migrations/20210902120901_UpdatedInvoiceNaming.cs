using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibrary.Migrations
{
    public partial class UpdatedInvoiceNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_UserId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Books_BookId",
                table: "Invoices");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "910bd8a2-ea48-4d5a-96fa-317792a6c8f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed5f07b8-b7db-4738-8095-44d146427587");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Invoices",
                newName: "UserIdId");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Invoices",
                newName: "BookIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                newName: "IX_Invoices_UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_BookId",
                table: "Invoices",
                newName: "IX_Invoices_BookIdId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "36dd8de5-290a-46b5-90bf-84a4809ac292", "1eb91c64-39ed-483c-ae9f-d57abe15eeea", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84d6657c-c69d-4817-97f4-920e4de52fb2", "48118d08-93d1-46c6-b139-2288452225d3", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_UserIdId",
                table: "Invoices",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Books_BookIdId",
                table: "Invoices",
                column: "BookIdId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_UserIdId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Books_BookIdId",
                table: "Invoices");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36dd8de5-290a-46b5-90bf-84a4809ac292");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84d6657c-c69d-4817-97f4-920e4de52fb2");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "Invoices",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "BookIdId",
                table: "Invoices",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_UserIdId",
                table: "Invoices",
                newName: "IX_Invoices_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_BookIdId",
                table: "Invoices",
                newName: "IX_Invoices_BookId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed5f07b8-b7db-4738-8095-44d146427587", "cdbad278-4115-4d5f-afc4-9ceada7c9117", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "910bd8a2-ea48-4d5a-96fa-317792a6c8f1", "515656fe-b92f-46eb-a05a-a0042d414555", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_UserId",
                table: "Invoices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Books_BookId",
                table: "Invoices",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
