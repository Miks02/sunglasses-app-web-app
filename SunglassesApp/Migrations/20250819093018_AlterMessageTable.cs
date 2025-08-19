using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class AlterMessageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7700ff9b-8646-4813-b20d-ad27d6894c7e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2cba44a-3e19-4f88-bbab-1ebccbd2f1c0", "AQAAAAIAAYagAAAAEPbxL7avz92Q1SgprfyxXbDHX1TVsEzelAu4qEkKACKqjwteoMeKfg7FtkWu3ktxxA==", "48ed5da9-2941-4332-bd9b-9ea92ad1798f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0f3556e-bb32-4115-9314-a112ff7bb605",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7abdd0d2-5cac-4562-9cb7-addc9ed36479", "AQAAAAIAAYagAAAAEIZ1FdPLC+O3W4A/ZdOOfNbsGbyZV3iIgy/1dRt6cnUA5Oqw0bleQGnnAwoL/17uxQ==", "a4db6045-1a00-48a2-92b2-850b262bc3ee" });
        }
    }
}
