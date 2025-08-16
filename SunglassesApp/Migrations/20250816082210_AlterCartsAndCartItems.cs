using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class AlterCartsAndCartItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "Carts",
                newName: "UserId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7700ff9b-8646-4813-b20d-ad27d6894c7e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d8373a0-8c5f-4eca-b7e0-5b64f8fdf014", "AQAAAAIAAYagAAAAEHelLi2hiGfrgAP5b5y1l5WncuBSUoRXBMKpnV1TzFdFjFfdJsjIEIUncqILaV08Qw==", "71f18d97-5653-4de4-bd54-299b99849180" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0f3556e-bb32-4115-9314-a112ff7bb605",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bef1f217-e797-42c7-b296-548493597814", "AQAAAAIAAYagAAAAEBI4dmbxdzzmVt910/Mc6MoixBol3Rnwpe4GIOUkJRNJmlrybdDwlpsPQnv4hdY42A==", "7c4279fd-2f73-4b1c-a581-64c29ba9d618" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Carts",
                newName: "SessionId");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "CartItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7700ff9b-8646-4813-b20d-ad27d6894c7e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "141e1eab-5116-42e6-9158-07481e49e166", "AQAAAAIAAYagAAAAEMPGXl3pd/52ojSBPJRT0pfQBwkZCjfa56bWCl7KDXwACB0EHMqqTw1D3W8VNzey4g==", "c35f5557-0042-4980-92e8-b3448cb0de83" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0f3556e-bb32-4115-9314-a112ff7bb605",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fb7bbcb-2f34-4695-86c4-515b5fb6adb0", "AQAAAAIAAYagAAAAEN6QJFenrnZpJjmjSuDjbnQ1AAeVVDADG0BA106LXyYXPDXKnUMFTEQv1Zce+Ztc9Q==", "35588080-7e86-49dd-a7db-0ec51e462014" });
        }
    }
}
