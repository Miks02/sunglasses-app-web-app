using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class SwitchToEf9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7700ff9b-8646-4813-b20d-ad27d6894c7e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0f3556e-bb32-4115-9314-a112ff7bb605");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7700ff9b-8646-4813-b20d-ad27d6894c7e", 0, "11a529e6-5635-41db-9e17-023c9f5b73a9", "admin@gmail.com", true, "Admin", "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN_ITS", "AQAAAAIAAYagAAAAEKLH4xwzmJxK1vsxhFlwBGmEQqPChzoApdvVlGy73Q4ssOyi6ZjT7ASNnB3oBO6F5Q==", null, false, "01c6d259-5788-46aa-a02a-d4bd096d9c40", false, "Admin_ITS" },
                    { "e0f3556e-bb32-4115-9314-a112ff7bb605", 0, "91f2d31d-3616-4575-93e1-1b5c436ac290", "test@gmail.com", true, "FirstName", "LastName", false, null, "TEST@GMAIL.COM", "USER_ITS", "AQAAAAIAAYagAAAAEKzuj1mxbQkvfef6zeQyhiyucNA2sOG7NEHmeAfPR0Ne6/3AN2sCHyDkluBqu4Dc7g==", null, false, "f478a1a0-4ccc-4683-b406-e992fc20f00c", false, "user_ITS" }
                });
        }
    }
}
