using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SunglassesApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMesagesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieverId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7700ff9b-8646-4813-b20d-ad27d6894c7e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9546eb2a-4657-46ca-9962-b328784d5fd8", "AQAAAAIAAYagAAAAEMwMyLmMc73DwLrHRUoG9E2YU2rghUDTLZMIV+UwMSylt0tWmVfukaNQtNDT5QBPSQ==", "658cd4c4-2c16-4302-91fb-45f72e9a65ee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e0f3556e-bb32-4115-9314-a112ff7bb605",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35dcef09-62d3-4d0c-bd16-653ee4f01fe6", "AQAAAAIAAYagAAAAEConE/mGL0fQsQCZj94YDTb/ReBFxLh5YUgCbqWbepShJ3GxamFK+lM5QKopHDtABA==", "b2c60cd4-9d5d-40f9-a420-f62d686ff4d0" });
        }
    }
}
