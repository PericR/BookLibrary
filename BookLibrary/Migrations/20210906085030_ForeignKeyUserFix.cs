using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibrary.Migrations
{
    public partial class ForeignKeyUserFix : Migration
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
                keyValue: "1dd1e7b3-9c47-4154-af72-ce6ed12999e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "368ea4a4-b63a-4e3a-aa17-8f8b214e5010");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Invoices");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97002723-5517-4af8-b438-42db2a356894", "d8dc090d-0751-4479-99f1-c4bb247172ac", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5d93512-4601-47a0-a7d5-17dcc82c4d85", "0ef48828-5218-473c-9f8f-4cd47d68a1a3", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97002723-5517-4af8-b438-42db2a356894");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5d93512-4601-47a0-a7d5-17dcc82c4d85");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Invoices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1dd1e7b3-9c47-4154-af72-ce6ed12999e4", "b5badf59-3d2d-4059-afd8-bfd93b10b9eb", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "368ea4a4-b63a-4e3a-aa17-8f8b214e5010", "bc8d3f8d-912d-4a3f-b974-275a31df64ac", "Administrator", "ADMINISTRATOR" });

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
