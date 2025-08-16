using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class AddCartsAndCartItemsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "38ba0b14-cd93-4e0f-a74f-b1080e7e4c48", "80c32529-9d23-4d53-a0b3-89c710f5fd96" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "218f1a02-f071-4468-b646-48a24e11e1d8", "e1976e68-c98a-46f6-9f1e-c0a87ef94609" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c32529-9d23-4d53-a0b3-89c710f5fd96");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1976e68-c98a-46f6-9f1e-c0a87ef94609");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7700ff9b-8646-4813-b20d-ad27d6894c7e", 0, "141e1eab-5116-42e6-9158-07481e49e166", "admin@gmail.com", true, "Admin", "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN_ITS", "AQAAAAIAAYagAAAAEMPGXl3pd/52ojSBPJRT0pfQBwkZCjfa56bWCl7KDXwACB0EHMqqTw1D3W8VNzey4g==", null, false, "c35f5557-0042-4980-92e8-b3448cb0de83", false, "Admin_ITS" },
                    { "e0f3556e-bb32-4115-9314-a112ff7bb605", 0, "8fb7bbcb-2f34-4695-86c4-515b5fb6adb0", "test@gmail.com", true, "FirstName", "LastName", false, null, "TEST@GMAIL.COM", "USER_ITS", "AQAAAAIAAYagAAAAEN6QJFenrnZpJjmjSuDjbnQ1AAeVVDADG0BA106LXyYXPDXKnUMFTEQv1Zce+Ztc9Q==", null, false, "35588080-7e86-49dd-a7db-0ec51e462014", false, "user_ITS" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "218f1a02-f071-4468-b646-48a24e11e1d8", "7700ff9b-8646-4813-b20d-ad27d6894c7e" },
                    { "38ba0b14-cd93-4e0f-a74f-b1080e7e4c48", "e0f3556e-bb32-4115-9314-a112ff7bb605" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "218f1a02-f071-4468-b646-48a24e11e1d8", "7700ff9b-8646-4813-b20d-ad27d6894c7e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "38ba0b14-cd93-4e0f-a74f-b1080e7e4c48", "e0f3556e-bb32-4115-9314-a112ff7bb605" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7700ff9b-8646-4813-b20d-ad27d6894c7e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0f3556e-bb32-4115-9314-a112ff7bb605");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "80c32529-9d23-4d53-a0b3-89c710f5fd96", 0, "a73695db-598d-444d-8178-3ae8f4c1ec58", "test@gmail.com", true, "FirstName", "LastName", false, null, "TEST@GMAIL.COM", "USER35", "AQAAAAIAAYagAAAAEGwJXrCC8pB94xAaSHFLVIoSqqKTEEOFy3f+V3XqaxJMuzGb0NoRKcmP+7xpielifQ==", null, false, "78271570-d9a9-4486-906e-ffc61fee67d5", false, "user35" },
                    { "e1976e68-c98a-46f6-9f1e-c0a87ef94609", 0, "6a733402-dd68-4069-a8c6-cb35910232ae", "admin02@gmail.com", true, "Admin", "Admin", false, null, "ADMIN02@GMAIL.COM", "ADMIN02", "AQAAAAIAAYagAAAAEEZlRXqv7xgbsSwlae6UclDrejOZ+BI/f7lcl1bZu3xnVz70tryrAIUWUYOZK92/9Q==", null, false, "c7990905-d7e7-47b6-bdc0-23fd6b9ee7e0", false, "Admin02" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "38ba0b14-cd93-4e0f-a74f-b1080e7e4c48", "80c32529-9d23-4d53-a0b3-89c710f5fd96" },
                    { "218f1a02-f071-4468-b646-48a24e11e1d8", "e1976e68-c98a-46f6-9f1e-c0a87ef94609" }
                });
        }
    }
}
