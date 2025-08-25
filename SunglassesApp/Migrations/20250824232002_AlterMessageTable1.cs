using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class AlterMessageTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Messages",
                newName: "MessageContent");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7700ff9b-8646-4813-b20d-ad27d6894c7e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11a529e6-5635-41db-9e17-023c9f5b73a9", "AQAAAAIAAYagAAAAEKLH4xwzmJxK1vsxhFlwBGmEQqPChzoApdvVlGy73Q4ssOyi6ZjT7ASNnB3oBO6F5Q==", "01c6d259-5788-46aa-a02a-d4bd096d9c40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0f3556e-bb32-4115-9314-a112ff7bb605",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91f2d31d-3616-4575-93e1-1b5c436ac290", "AQAAAAIAAYagAAAAEKzuj1mxbQkvfef6zeQyhiyucNA2sOG7NEHmeAfPR0Ne6/3AN2sCHyDkluBqu4Dc7g==", "f478a1a0-4ccc-4683-b406-e992fc20f00c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessageContent",
                table: "Messages",
                newName: "Content");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7700ff9b-8646-4813-b20d-ad27d6894c7e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f2216e8-7e8a-4aa3-939b-01f7ccabe0bd", "AQAAAAIAAYagAAAAEPc3ZxYbdVWWZstdiWDkekUCt8D+CX/aS5R3bjwVreYOfFMvFupIw1RTSocXWGnPrw==", "4c045774-c9bf-49ec-ac2e-1def458cdf4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0f3556e-bb32-4115-9314-a112ff7bb605",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "722978f0-65e3-4fb2-a7dd-540e8ddc1572", "AQAAAAIAAYagAAAAEFxlbERG98mYe9Xghaj0YWcbTzFaUJspwIX96OyAPik5XpQhNwXBabYqDZVr8wY9Dw==", "d768abc8-31f3-47d6-a252-23f0441469c5" });
        }
    }
}
