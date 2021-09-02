using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLibrary.Migrations
{
    public partial class AddedBookPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "915544de-6130-47cd-bc7a-9a15bf6db452");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8ffa38e-6b2c-4904-bac4-dbd95859a220");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Books",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "38b3cec5-8b98-4077-8bde-79fa371fc363", "1e549493-5225-43c8-bf12-25ddd661d350", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "717fc3f2-e789-48a2-a244-3f3fbcbbe21a", "fc96e8dd-2207-4a64-8ade-bd5e0ea44f6a", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b3cec5-8b98-4077-8bde-79fa371fc363");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "717fc3f2-e789-48a2-a244-3f3fbcbbe21a");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "915544de-6130-47cd-bc7a-9a15bf6db452", "575f6681-db60-4e05-8b3f-143caf958343", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8ffa38e-6b2c-4904-bac4-dbd95859a220", "62dc9123-c2a7-44b8-a8d9-1fb17d908670", "Administrator", "ADMINISTRATOR" });
        }
    }
}
