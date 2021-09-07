using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibrary.Migrations
{
    public partial class UserAddedToInvoiceRemoved : Migration
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
                keyValue: "886c36a9-8d08-48b5-9d36-06760d167a69");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd92376d-12ce-48ee-8dc1-2e900b3089af");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Invoices");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd88ce53-31ad-4ef2-94bd-3dbcf3c025e8", "78fdbdc1-5de2-458d-a0bb-c9606086b956", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ebfc4ac-7a03-4d08-8634-9dea6badee72", "0ab0389f-44e7-4114-92e4-108f0d3d09eb", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ebfc4ac-7a03-4d08-8634-9dea6badee72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd88ce53-31ad-4ef2-94bd-3dbcf3c025e8");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Invoices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd92376d-12ce-48ee-8dc1-2e900b3089af", "eb9512af-b156-49ea-86d3-dcb34be68cf5", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "886c36a9-8d08-48b5-9d36-06760d167a69", "987e7fad-585d-4c63-804b-04fd0a090107", "Administrator", "ADMINISTRATOR" });

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
